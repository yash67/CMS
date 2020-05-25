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
    public class DealerManager : IDealerManager
    {
        private IDealerRepository _dealerRepository;

        public DealerManager(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }

        public bool CheckDealerEmail(string email)
        {
            bool status = _dealerRepository.CheckDealerEmail(email);
            return status;
        }

        public bool InsertDealer(DealerViewModel dealerViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DealerViewModel, CMS_DealerInfo>();
            });
            IMapper mapper = config.CreateMapper();
            var dealer = mapper.Map<DealerViewModel, CMS_DealerInfo>(dealerViewModel);
            return _dealerRepository.InsertDealer(dealer);
        }

        public bool UpdateDealer(string email)
        {
            CMS_DealerInfo dealerInfo = _dealerRepository.GetDealer(email);
            dealerInfo.IsActive = true;
            bool status =_dealerRepository.UpdateDealer(dealerInfo);
            return status;
        }

        public CMS_DealerInfo AuthorizeDealer(string email, string Password)
        {
            CMS_DealerInfo dealer = _dealerRepository.AuthorizeDealer(email, Password);
            return dealer;
        }

        public bool InsertDealerCities(List<DealerCityViewModel> dealerCityViewModels)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DealerCityViewModel, CMS_DealerCity>();
            });
            IMapper mapper = config.CreateMapper();
            var dealerCities = mapper.Map<List<DealerCityViewModel>, List<CMS_DealerCity>>(dealerCityViewModels);
            return _dealerRepository.InsertDealerCities(dealerCities);
        }

        public bool InsertDealerCategories(List<DealerCategoryViewModel> dealerCategoryViewModels)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DealerCategoryViewModel, CMS_DealerProductCategory>();
            });
            IMapper mapper = config.CreateMapper();
            var dealerCategories = mapper.Map<List<DealerCategoryViewModel>, List<CMS_DealerProductCategory>>(dealerCategoryViewModels);
            return _dealerRepository.InsertDealerCategories(dealerCategories);
        }

        public bool InsertDealerServices(List<DealerServiceViewModel> dealerServiceViewModels)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DealerServiceViewModel, CMS_DealerService>();
            });
            IMapper mapper = config.CreateMapper();
            var dealerServices = mapper.Map<List<DealerServiceViewModel>, List<CMS_DealerService>>(dealerServiceViewModels);
            return _dealerRepository.InsertDealerServices(dealerServices);
        }

        public List<AddressDetailsViewModel> GetOrders(long id)
        {
            List<AddressDetailsViewModel> Orders = _dealerRepository.GetOrders(id);
            return Orders;
        }

    }
}
