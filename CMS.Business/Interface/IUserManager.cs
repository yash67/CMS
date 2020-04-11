using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.BusinessEntities.ViewModel;

namespace CMS.Business.Interface
{
    public interface IUserManager
    {
        bool UserRegistration(UserViewModel UserInfo);
        bool CheckUserEmail(string chkemail);
        string Hash(string value);
        bool UpdateUser(string email);


    }
}
