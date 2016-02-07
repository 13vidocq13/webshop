using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using EntitiesAndMapping.Entities;

namespace EntitiesAndMapping.Mapping
{
    public class RelationsMap : ClassMap<Relations>
    {
        public RelationsMap()
        {
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.ChildID);

            References(x => x.Categories);
                //.ForeignKey("ID").Column("ID")
                //.Access.CamelCaseField(Prefix.Underscore)
                //.Fetch.Join();
       }
    }
}
