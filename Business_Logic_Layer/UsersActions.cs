using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data_Access_Layer.CRUD;
using EntitiesAndMapping.Entities;

namespace Business_Logic_Layer
{ 
    public class UsersActions
    {
        public void CreateUser(string userName, string pass, string email,
            string question, string answer, UserInfo userInfo)
        {
            UsersCRUD usersCRUD = new UsersCRUD();
            usersCRUD.CreateUser(userName, pass, email, question, answer, userInfo);
        }

        public Guid FindUserGuid(string userName)
        {
            UsersCRUD usersCRUD = new UsersCRUD();
            return usersCRUD.FindUserGuid(userName);
        }
    }
}
