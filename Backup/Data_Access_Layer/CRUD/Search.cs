using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities;
using Data_Access_Layer.SessionManager;
using NHibernate.Linq;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.LambdaExtensions;

namespace Data_Access_Layer.CRUD
{
    public class Search
    {
        public List<Goods> SearchByName(string name)
        {
            return (from q in Sessions.NewSession.Linq<Goods>()
                    where q.Name == name
                    orderby q.Price
                    select q).ToList<Goods>();
        }

        public IList<Goods> SearchByName(string searchingName,
            string sortName, int resultCount)
        {
            const string columnName = "Name";

            ICriteria criteria = Sessions.NewSession.CreateCriteria(typeof(Goods));

            criteria.Add(Restrictions.Like(columnName, searchingName, MatchMode.Anywhere));

            //criteria.Add<Goods>(x => x.Name.Contains(searchingName));
            
            criteria.SetMaxResults(resultCount);
            criteria.SetFirstResult(0);
            criteria.AddOrder(NHibernate.Criterion.Order.Asc(sortName));

            return criteria.List<Goods>();
        }

        public IList<Goods> SearchByDateTime(DateTime start, DateTime end,
            string sortName, int resultCount)
        {
            const string columnName = "AdditionDate";

            ICriteria criteria = Sessions.NewSession.CreateCriteria(typeof(Goods));

            criteria.Add(Restrictions.Between(columnName, start, end));
            criteria.SetFirstResult(0);
            criteria.SetMaxResults(resultCount);
            criteria.AddOrder(NHibernate.Criterion.Order.Asc(sortName));

            return criteria.List<Goods>();
        }

        //public IList<Goods> SearchByCategory(string categoryName, 
        //    string sortName, int resultcount)
        //{
        //    ICriteria criteria = Sessions.NewSession.CreateCriteria(typeof(Goods));


        //}
    }
}
