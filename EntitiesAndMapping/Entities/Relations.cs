using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities.Base;


namespace EntitiesAndMapping.Entities
{
    public class Relations : BaseEntity
    {
        public virtual int ID
        {
            get;
            protected set;
        }

        public virtual int CategoryID
        {
            get;
            set;
        }

        public virtual int ChildID
        {
            get;
            set;
        }

        public virtual Categories Categories
        {
            get;
            set;
        }
    }
}
