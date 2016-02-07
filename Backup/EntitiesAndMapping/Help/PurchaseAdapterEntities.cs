using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities;

namespace EntitiesAndMapping.Help
{
    public class PurchaseAdapterEntities
    {
        public Guid UserID
        {
            get;
            set;
        }

        public DateTime PurchaseDateTime
        {
            get;
            set;
        }

        public bool MethodOfPayment
        {
            get;
            set;
        }

        public IList<int> GoodsIDs
        {
            get;
            set;
        }
    }
}
