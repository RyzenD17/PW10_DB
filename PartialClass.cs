﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW10_DB
{
    public partial class OrdersTable
    {
        public string Customer
        {
            get
            {
                BaseClass.Base.Users.Where(x => x.IDUser == IDUser);
                switch(Users.IDGender)
                {
                    case 1:
                        return "Заказчик - " + Users.Surname + Users.Name;
                    case 2:
                        return "Заказчица -  " + Users.Surname + Users.Name;
                    default:
                        return "Пол не определен" + Users.Surname + Users.Name;
                }
            }
        }

    }
}
