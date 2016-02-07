using System;
using EntitiesAndMapping.Entities;
using FluentNHibernate.Mapping;

namespace EntitiesAndMapping.Mapping
{
    public class CategoriesMap : ClassMap<Categories>
    {
        public CategoriesMap()
        {
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.Name);

            HasMany(x => x.Relations)
                .KeyColumn("CategoryID")
                .Cascade
                .AllDeleteOrphan()
                .Inverse();
            HasMany(x => x.RelationsCategoriesGoods)
                .KeyColumn("CategoryID")
                .Cascade
                .AllDeleteOrphan()
                .Inverse();
            //HasManyToMany(x => x.Goods)
            //    .Cascade
            //    .AllDeleteOrphan()
            //    .Table("RelationsCategoriesGoods");
             //.KeyColumn("ChildID")
             //   .Cascade
             //   .AllDeleteOrphan()
             //   .Inverse();
            //HasManyToMany(x => x.Relations)
            //    .AsBag()
            //    .ParentKeyColumn("ID")
            //    .ChildKeyColumn("ChildID")
            //    .Cascade
            //    .AllDeleteOrphan()
            //    .Inverse();
        }
    }
}
