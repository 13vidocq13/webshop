using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Data_Access_Layer.SessionManager;
using EntitiesAndMapping.Entities;
using NHibernate.Linq;

namespace Data_Access_Layer.CRUD
{
    public class UsersCRUD
    {
        public void CreateUser(string userName, string pass, string email,
            string question, string answer, UserInfo userInfo)
        {
            MembershipCreateStatus status;

            Membership.CreateUser(userName, pass, email, question, answer,
                    false, out status);

            if (status == MembershipCreateStatus.Success)
            {
                userInfo.aspnet_Users = Sessions.NewSession.Get<aspnet_Users>(FindUserGuid(userName));

                Sessions.NewSession.SaveOrUpdate(userInfo);
                Sessions.NewSession.Flush();
            }
        }

        public Guid FindUserGuid(string userName)
        {
            return (from q in Sessions.NewSession.Linq<aspnet_Users>()
                    where q.UserName == userName
                    select q.UserId).FirstOrDefault<Guid>();
        }
    }
}
