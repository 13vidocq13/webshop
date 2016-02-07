using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities.Base;

namespace EntitiesAndMapping.Entities
{
    [Serializable]
    public class Categories : BaseEntity
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

        public virtual IList<Relations> Relations
        {
            get;
            set;
        }

        public virtual IList<RelationsCategoriesGoods> RelationsCategoriesGoods
        {
            get;
            set;
        }
    }
}


