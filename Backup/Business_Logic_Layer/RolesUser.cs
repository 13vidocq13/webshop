using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business_Logic_Layer
{
    public class RolesUser
    {
        public List<string> rolesList = new List<string>();

        public RolesUser()
        {
            rolesList.Add("Unregistered user");
            rolesList.Add("Registered user");
            rolesList.Add("Premium user");
            rolesList.Add("Administrator");
        }

        public void actionForRole()
        {
            foreach (var item in rolesList)
            {

                switch (item)
                {
                    case "Administrator":
                        break;

                    case "Premium user":
                        //1.	Функциональность зарегистрированного пользователя
                        //2.	Получение в два раза большей скидки,
                        //нежели просто зарегестрированный
                        break;

                    case "Registered user":
                        //2.	Возможность редактировать свой профиль
                        //a.	Предпочитаемый язык для сайта
                        //b.	Номер телефона(например (0572)-23-21-11)
                        //c.	Имя
                        //d.	Фамилия
                        //e.	Домашний адрес (должен по умолчанию показываться
                        //при подтверждении заказа
                        //, но там должна быть возможность его изменить)
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
