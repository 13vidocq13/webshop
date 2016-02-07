using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using EntitiesAndMapping.Entities;
using EntitiesAndMapping.Entities.Base;
using Data_Access_Layer.CRUD;


namespace Business_Logic_Layer
{
    public class CategoriesActions
    {
        const string tableName = "Categories";
        
        public int AddCategoty(Categories categories, int parentID)
        {
            CategoriesCRUD categoriesCRUD = new CategoriesCRUD();
            return categoriesCRUD.CreateCategory(categories, parentID);
        }

        public void UpdateCategory(int ID, string categoryName)
        {
            CategoriesCRUD categoriesCRUD = new CategoriesCRUD();
            categoriesCRUD.UpdateCategory(ID, categoryName);
        }
        
        public void DeleteCategory(int ID)
        {
            CategoriesCRUD categoriesCRUD = new CategoriesCRUD();
            categoriesCRUD.DeleteCategory(ID);
        }

        public List<Categories> GetCategories(int ParentID)
        {
            CategoriesCRUD categoriesCRUD = new CategoriesCRUD();
            return categoriesCRUD.GetCategories(ParentID);
        }

        public string FindCategoryName(int categoryID)
        {
            CategoriesCRUD categoriesCRUD = new CategoriesCRUD();
            return categoriesCRUD.FindCategoryName(categoryID);
        }

        public Categories FindCategory(int categoryID)
        {
            CategoriesCRUD categoriesCRUD = new CategoriesCRUD();
            return categoriesCRUD.FindCategory(categoryID);
        }

        public bool isHaveChildren(int categoryID)
        {
            CategoriesCRUD categoriesCRUD = new CategoriesCRUD();
            return categoriesCRUD.IsHaveChildren(categoryID);
        }
    }
}
