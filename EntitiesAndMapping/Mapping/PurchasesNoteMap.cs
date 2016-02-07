using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using EntitiesAndMapping.Entities;

namespace EntitiesAndMapping.Mapping
{
    public class PurchasesNoteMap : ClassMap<PurchasesNote>
    {
        public PurchasesNoteMap()
        {
            Id(x => x.ID).GeneratedBy.Native();
            //Map(x => x.GoodsID);

            References(x => x.Purchases);
            References(x => x.Goods);
        }
    }
}
