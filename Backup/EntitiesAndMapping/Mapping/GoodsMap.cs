using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using EntitiesAndMapping.Entities;

namespace EntitiesAndMapping.Mapping
{
    public class GoodsMap : ClassMap<Goods>
    {
        public GoodsMap()
        {
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.Name);
            Map(x => x.Price);
            Map(x => x.IsDiscount);
            Map(x => x.Discount);
            Map(x => x.AdditionDate);

            HasMany(x => x.RelationsCategoriesGoods)
                .KeyColumn("GoodsID")
                .Cascade
                .AllDeleteOrphan()
                .Inverse();
            HasMany(x => x.GoodsImages)
                .KeyColumn("GoodsID")
                .Cascade
                .AllDeleteOrphan()
                .Inverse();
            HasMany(x => x.PurchasesNote)
                .KeyColumn("GoodsID")
                .Cascade
                .AllDeleteOrphan()
                .Inverse();    

            //HasManyToMany(x => x.Categories)
            //    .Cascade
            //    .AllDeleteOrphan()
            //    .Inverse()
            //    .Table("RelationsCategoriesGoods");
        }
    }
}
