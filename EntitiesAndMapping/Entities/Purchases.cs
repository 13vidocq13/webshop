using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntitiesAndMapping.Entities
{
    public class Purchases
    {
        public virtual int ID
        {
            get;
            protected set;
        }

        public virtual Guid UserId
        {
            get;
            set;
        }

        public virtual bool MethodOfPayment
        {
            get;
            set;
        }

        public virtual DateTime PurchaseDateTime
        {
            get;
            set;
        }

        public virtual IList<PurchasesNote> PurchasesNote
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
