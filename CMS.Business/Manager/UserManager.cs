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
    }
}
