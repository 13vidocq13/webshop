using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using EntitiesAndMapping.Entities;

namespace EntitiesAndMapping.Mapping
{
    public class UserInfoMap : ClassMap<UserInfo>
    {
        public UserInfoMap()
        {
            Id(x => x.ID).GeneratedBy.Native();
            Map(x => x.LanguageIsEnglish);
            Map(x => x.Name);
            Map(x => x.SurName);
            Map(x => x.Address);
            Map(x => x.Code);
            Map(x => x.Phone);

            References(x => x.aspnet_Users);
        }
    }
}
