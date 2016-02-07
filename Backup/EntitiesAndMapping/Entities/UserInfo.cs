using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesAndMapping.Entities
{
    [Serializable]
    public class UserInfo
    {
        public virtual int ID
        {
            get;
            set;
        }

        public virtual bool LanguageIsEnglish
        {
            get;
            set;
        }

        public virtual Guid UserId
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string SurName
        {
            get;
            set;
        }

        public virtual string Address
        {
            get;
            set;
        }

        public virtual string Code
        {
            get;
            set;
        }

        public virtual string Phone
        {
            get;
            set;
        }

        public virtual aspnet_Users aspnet_Users
        {
            get;
            set;
        }
    }
}
