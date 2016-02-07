using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities;
using Data_Access_Layer.CRUD;

namespace Business_Logic_Layer
{
    public class SearchActions
    {
        public List<Goods> SearchByName(string name)
        {
            SearchActions search = new SearchActions();
            return search.SearchByName(name);
        }

        public IList<Goods> SearchByName(string searchingName,
            string sortName, int resultCount)
        {
            Search search = new Search();
            return search.SearchByName(searchingName, sortName, resultCount);
        }

        public IList<Goods> SearchByDateTime(DateTime start, DateTime end,
            string sortName, int resultCount)
        {
            Search search = new Search();
            return search.SearchByDateTime(start, end, sortName, resultCount);
        }
    }
}
