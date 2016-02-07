using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities.Base;

namespace EntitiesAndMapping.Entities
{
    [Serializable]
    public class Goods : BaseEntity
    {
        public virtual int ID
        {
            get;
            protected set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual float Price
        {
            get;
            set;
        }

        public virtual bool IsDiscount
        {
            get;
            set;
        }

        public virtual int? Discount
        {
            get;
            set;
        }

        public virtual DateTime AdditionDate
        {
            get;
            set;
        }
    
        public virtual IList<RelationsCategoriesGoods> RelationsCategoriesGoods
        {
            get;
            set;
        }

        public virtual IList<GoodsImages> GoodsImages
        {
            get;
            set;
        }

        public virtual IList<PurchasesNote> PurchasesNote
        {
            get;
            set;
        }
    }
}
