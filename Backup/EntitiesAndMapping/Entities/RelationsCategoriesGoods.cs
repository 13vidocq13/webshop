using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesAndMapping.Entities
{
    [Serializable]
    public class RelationsCategoriesGoods
    {
        public virtual int ID
        {
            get;
            protected set;
        }

        public virtual int GoodsID
        {
            get;
            set;
        }

        public virtual int CategoryID
        {
            get;
            set;
        }

        public virtual Categories Categories
        {
            get;
            set;
        }

        public virtual Goods Goods
        {
            get;
            set;
        }
    }
}
