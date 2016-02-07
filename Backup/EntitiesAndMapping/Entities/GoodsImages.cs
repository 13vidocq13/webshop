using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities.Base;

namespace EntitiesAndMapping.Entities
{
    [Serializable]
    public class GoodsImages : BaseEntity
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

        public virtual byte[] Image
        {
            get;
            set;
        }

        public virtual byte[] MiniImage
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
