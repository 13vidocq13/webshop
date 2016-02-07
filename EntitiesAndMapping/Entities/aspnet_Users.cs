using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesAndMapping.Entities
{
    [Serializable]
    public class aspnet_Users 
    {
        public virtual Guid UserId
        {
            get;
            protected set;
        }

        public virtual string UserName
        {
            get;
            set;
        }
        
        public virtual IList<UserInfo> UserInfo
        {
            get;
            set;
        }

        public virtual IList<Purchases> Purchases
        {
            get;
            set;
        }
    }
}
