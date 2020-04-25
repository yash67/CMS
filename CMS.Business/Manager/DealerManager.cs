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



        public List<DealerViewModel> GetDealerCompanyList(long From, long To, long DealerProductId, long DealerServiceId)
        {
            List<DealerViewModel> Dealers = _dealerRepository.GetDealerCompanyList(From, To, DealerProductId, DealerServiceId);
            return Dealers;
        }

        public List<AddressDetailsViewModel> GetOrders()
        {
            List<AddressDetailsViewModel> Orders = _dealerRepository.GetOrders();
            return Orders;
        }
    }
}
