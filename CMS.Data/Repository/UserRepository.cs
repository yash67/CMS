using CMS.Data.Database;
using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public bool CheckUserEmail(string chkemail)
        {
            bool status = true;
            var result = !cMSEntities.CMS_UserInfo.ToList().Exists(x => x.Email.Equals(chkemail, StringComparison.CurrentCultureIgnoreCase));
            if (result == false)
            {
                status = false;
            }
            return status;
            //return result.ToString();
        }
        public bool UpdateUser(CMS_UserInfo UserInfo)
        {
            bool status = false;
            cMSEntities.Entry(UserInfo).State = EntityState.Modified;
            if (cMSEntities.SaveChanges() > 0)
            {
                status = true;
            }
            return status;
        }

        public CMS_UserInfo GetUser(string email)
        {
            CMS_UserInfo user = cMSEntities.CMS_UserInfo.FirstOrDefault(u => u.Email == email);
            return user;
        }
        public CMS_UserInfo AuthorizeUser(string Email, string Password)
        {
            //bool status = false;
            //var result = cMSEntities.CMS_UserInfo.ToList().Exists(x => x.Email.Equals(Email, StringComparison.CurrentCultureIgnoreCase)
            //                 && x.Password.Equals(Password, StringComparison.CurrentCultureIgnoreCase));
            CMS_UserInfo result = cMSEntities.CMS_UserInfo.Where(x => x.Email == Email && x.Password == Password && x.IsActive == true).FirstOrDefault();
            //if (result != null)
            //{
            //    status = true;
            //}
            return result;
        }

        public bool InsertAddressDetails(CMS_OrderInfo OrderInfo)
        {
            bool Status = false;
            cMSEntities.CMS_OrderInfo.Add(OrderInfo);
            try
            {
                if (cMSEntities.SaveChanges() > 0)
                {
                    Status = true;
                }
            }
            catch (Exception e)
            {

            }
            return Status;
        }
    }
}
