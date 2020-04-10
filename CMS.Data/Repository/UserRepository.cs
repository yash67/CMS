﻿using CMS.Data.Database;
using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Repository
{
    public class UserRepository:IUserRepository
    {
        private CMSEntities cMSEntities;

        public UserRepository()
        {
            cMSEntities = new CMSEntities();
        }

        public bool UserRegistration(CMS_UserInfo UserInfo)
        {
            bool Status = false;
            cMSEntities.CMS_UserInfo.Add(UserInfo);
            if (cMSEntities.SaveChanges() > 0)
            {
                Status = true;
            }
            return Status;
        }

    }
}
