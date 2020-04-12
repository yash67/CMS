using AutoMapper;
using CMS.Business.Interface;
using CMS.BusinessEntities.ViewModel;
using CMS.Data.Database;
using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Manager
{
    public class UserManager:IUserManager
    {
        private IUserRepository _userRepository { get; set; }

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool UserRegistration(UserViewModel UserInfo)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserViewModel, CMS_UserInfo>();
            });

            IMapper mapper = config.CreateMapper();
            var source = UserInfo;
            var dest = mapper.Map<UserViewModel, CMS_UserInfo>(source);

            bool status = _userRepository.UserRegistration(dest);
            return status;
        }

        public bool CheckUserEmail(string chkemail)
        {
            // UserViewModel userViewModel = new UserViewModel();
            bool status = _userRepository.CheckUserEmail(chkemail);
            //!userViewModel.Email.Equals(chkemail, StringComparison.CurrentCultureIgnoreCase);
            return status;
        }

        //Functions
        public string Hash(string value)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(value))
                ).Replace('"', ' ');
        }

        public bool UpdateUser(String email)
        {
            CMS_UserInfo userInfo = _userRepository.GetUser(email);
            userInfo.IsActive = true;
            bool status = _userRepository.UpdateUser(userInfo);
            return status;
        }

        public CMS_UserInfo AuthorizeUser(string Email, string Password)
        {
            CMS_UserInfo status = _userRepository.AuthorizeUser(Email, Password);
            return status;
        }


    }
}
