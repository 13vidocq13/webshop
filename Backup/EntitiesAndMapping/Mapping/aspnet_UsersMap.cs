using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using EntitiesAndMapping.Entities;

namespace EntitiesAndMapping.Mapping
{
    public class aspnet_UsersMap : ClassMap<aspnet_Users>
    {
        public aspnet_UsersMap()
        {
            Id(x => x.UserId).GeneratedBy.Guid();
            Map(x => x.UserName);

            HasMany(x => x.UserInfo)
                .KeyColumn("UserId")
                .Cascade
                .AllDeleteOrphan()
                .Inverse();
            HasMany(x => x.Purchases)
                .KeyColumn("UserId")
                .Cascade
                .AllDeleteOrphan()
                .Inverse();
        }
    }
}
