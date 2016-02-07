using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntitiesAndMapping.Entities;
using Data_Access_Layer.CRUD;

namespace Business_Logic_Layer
{
    public class ProfileActions
    {
        public UserInfo GetUserInfo(Guid userId)
        {
            ProfileCRUD profileCRUD = new ProfileCRUD();
            return profileCRUD.GetUserInfo(userId);
        }

        public void AddInfo(Guid usersID, UserInfo userInfo)
        {
            ProfileCRUD profileCRUD = new ProfileCRUD();
            profileCRUD.AddInfo(usersID, userInfo);
        }
    }
}
