using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using EntitiesAndMapping.Entities;

namespace EntitiesAndMapping.Mapping
{
    public class PurchasesMap : ClassMap<Purchases>
    {
        public PurchasesMap()
        {
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.PurchaseDateTime);
            Map(x => x.MethodOfPayment);

            References(x => x.aspnet_Users);
            HasMany(x => x.PurchasesNote)
                .KeyColumn("PurchasesID");
        }
    }
}
