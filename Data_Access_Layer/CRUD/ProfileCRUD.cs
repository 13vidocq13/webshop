using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities;
using Data_Access_Layer.SessionManager;
using NHibernate.Linq;

namespace Data_Access_Layer.CRUD
{
    public class ProfileCRUD
    {
        public void AddInfo(Guid userID, UserInfo userInfo)
        {
            var entity = Sessions.NewSession.Get<UserInfo>(FindID(userID));
            entity.Code = userInfo.Code;
            entity.Phone = userInfo.Phone;
            entity.Name = userInfo.Name;
            entity.SurName = userInfo.SurName;
            entity.Address = userInfo.Address;
            entity.aspnet_Users = Sessions.NewSession.Get<aspnet_Users>(userID);
            
            Sessions.NewSession.SaveOrUpdate(entity);
            Sessions.NewSession.Flush();
        }

        public UserInfo GetUserInfo(Guid userId)
        {
            return (from q in Sessions.NewSession.Linq<UserInfo>()
                    where q.aspnet_Users.UserId == userId
                    select q).FirstOrDefault<UserInfo>();
        }

        public int FindID(Guid userId)
        {
            return (from q in Sessions.NewSession.Linq<UserInfo>()
                    where q.aspnet_Users.UserId == userId
                    select q.ID).FirstOrDefault<int>();
        }
    }
}
