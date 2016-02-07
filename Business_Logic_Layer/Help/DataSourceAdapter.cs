using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business_Logic_Layer.Help
{
    [Serializable]
    public class DataSourceAdapter
    {
        public int ID
        {
            get;
            set;
        }

        public string ImageURL
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Price
        {
            get;
            set;
        }

        public bool IsDiscount
        {
            get;
            set;
        }

        public string Discount
        {
            get;
            set;
        }

        public string AdditionDate
        {
            get;
            set;
        }

        public float Cost
        {
            get;
            set;
        }

        public int Count
        {
            get;
            set;
        }
    }
}
