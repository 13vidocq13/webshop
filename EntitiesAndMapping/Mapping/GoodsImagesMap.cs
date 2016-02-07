using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities;
using FluentNHibernate.Mapping;

namespace EntitiesAndMapping.Mapping
{
    public class GoodsImagesMap : ClassMap<GoodsImages>
    {
        public GoodsImagesMap()
        {
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.Image);
            Map(x => x.MiniImage);

            References(x => x.Goods);
        }
    }
}
