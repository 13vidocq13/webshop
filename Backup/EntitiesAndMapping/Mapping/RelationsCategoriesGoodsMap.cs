using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities;
using FluentNHibernate.Mapping;

namespace EntitiesAndMapping.Mapping
{
    public class RelationsCategoriesGoodsMap : ClassMap<RelationsCategoriesGoods>
    {
        public RelationsCategoriesGoodsMap()
        {
            Id(x => x.ID).GeneratedBy.Native();
            //Map(x => x.CategoryID);
            //Map(x => x.GoodsID);
            References(x => x.Categories);
            References(x => x.Goods);
        }
    }
}
