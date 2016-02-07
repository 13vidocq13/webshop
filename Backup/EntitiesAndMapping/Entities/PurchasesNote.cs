using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesAndMapping.Entities
{
    public class PurchasesNote
    {
        public virtual int ID
        {
            get;
            protected set;
        }

        public virtual int PurchasesID
        {
            get;
            set;
        }

        public virtual int GoodsID
        {
            get;
            set;
        }

        public virtual Goods Goods
        {
            get;
            set;
        }

        public virtual Purchases Purchases
        {
            get;
            set;
        }
    }
}
