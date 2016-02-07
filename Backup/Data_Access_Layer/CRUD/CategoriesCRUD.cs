using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Data_Access_Layer.SessionManager;
using EntitiesAndMapping.Entities.Base;
using EntitiesAndMapping.Entities;
using NHibernate.Linq;

namespace Data_Access_Layer.CRUD
{
    public class CategoriesCRUD
    {
        public int CreateCategory(Categories categories, int parentID)
        {
            int createdID; 
            
            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                using (var transaction = Sessions.NewSession.BeginTransaction())
                {
                    Sessions.NewSession.SaveOrUpdate(categories);
                    Sessions.NewSession.Flush();
                    createdID = categories.ID;

                    Relations relations = new Relations();
                    relations.ChildID = createdID;
                    relations.Categories = Sessions.NewSession.Get<Categories>(parentID);
                    Sessions.NewSession.SaveOrUpdate(relations);
                    Sessions.NewSession.Flush();

                    transaction.Commit();
                }
            }
            return createdID;
        }

        public void UpdateCategory(int categotyID, string categoryName)
        {
            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                var entity = Sessions.NewSession.Get<Categories>(categotyID);
                entity.Name = categoryName;

                Sessions.NewSession.SaveOrUpdate(entity);
                Sessions.NewSession.Flush();
            }
        }

        public void DeleteCategory(int categotyID)
        {
            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                List<int> result = new List<int>();
                HashSet<int> processedParents = new HashSet<int>();

                RecursiveGetChildren(categotyID, result, processedParents);
                result.Add(categotyID);

                int rootParentID = GetRelationID(categotyID);
    
                using (var transaction = Sessions.NewSession.BeginTransaction())
                {

                    //удаление из таблицы категорий
                    foreach (var item in result)
                    {
                        var entity = Sessions.NewSession.Get<Categories>(item);
                        
                        Sessions.NewSession.Delete(entity);
                        Sessions.NewSession.Flush();
                    }

                    var entityRoot = Sessions.NewSession.Get<Relations>(rootParentID);

                    Sessions.NewSession.Delete(entityRoot);
                    Sessions.NewSession.Flush();
                    
                    transaction.Commit();
                }
            }
        }

        public string FindCategoryName(int categoryID)
        {
            return (from q in Sessions.NewSession.Linq<Categories>()
                    where q.ID == categoryID
                    select q.Name).FirstOrDefault<string>();
        }

        public Categories FindCategory(int categoryID)
        {
            return (from q in Sessions.NewSession.Linq<Categories>()
                    where q.ID == categoryID
                    select q).FirstOrDefault<Categories>();
        }

        public List<Categories> GetCategories(int ParentID)
        {
            List<int> relationsIDs = GetChildren(ParentID);
            List<Categories> tempCategories = new List<Categories>();

            using (Sessions.NewSession = Sessions.SessionFactory.OpenSession())
            {
                foreach (int item in relationsIDs)
                {
                    var query = from q in Sessions.NewSession.Linq<Categories>()
                                where q.ID == item
                                select q;
                    tempCategories.Add(query.FirstOrDefault<Categories>());
                }
                return tempCategories;
            }
        }

        public bool isHaveChildren(int categoryID)
        {
            if (GetChildren(categoryID).Count > 0)
                return true;

            return false;
        }

        int GetRelationID(int ID)
        {
            return(from q in Sessions.NewSession.Linq<Relations>()
                       where q.ChildID == ID
                       select q.ID).FirstOrDefault<int>();
        }

        void RecursiveGetChildren(int parentId, List<int> result, HashSet<int> processedParents)
        {
            var children = GetChildren(parentId);

            processedParents.Add(parentId);

            foreach (var child in children)
            {
                if (processedParents.Contains(child))
                    continue;

                result.Add(child);
                processedParents.Add(child);

                RecursiveGetChildren(child, result, processedParents);
            }
        }

        List<int> GetChildren(int parentID)
        {
            return (from q in Sessions.NewSession.Linq<Relations>()
                    where q.Categories.ID == parentID
                    select q.ChildID).ToList<int>();
        }
    }
}
