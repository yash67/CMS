using CMS.BusinessEntities.ViewModel;
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
    public class DealerRepository : IDealerRepository
    {
        private CMSEntities _cMSEntities;

        public DealerRepository(CMSEntities cMSEntities)
        {
            _cMSEntities = cMSEntities;
        }

        public bool CheckDealerEmail(string email)
        {
            bool status = true;
            var result = !_cMSEntities.CMS_DealerInfo.ToList().Exists(x => x.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));
            if (result == false)
            {
                status = false;
            }
            return status;
        }
        public bool InsertDealer(CMS_DealerInfo dealer)
        {
            bool status = false;
            _cMSEntities.CMS_DealerInfo.Add(dealer);
            if (_cMSEntities.SaveChanges() > 0)
            {
                status = true;
            }
            return status;
        }

        public CMS_DealerInfo GetDealer(string email)
        {
            CMS_DealerInfo dealer = _cMSEntities.CMS_DealerInfo.FirstOrDefault(x => x.Email == email);
            return dealer;
        }

        public bool UpdateDealer(CMS_DealerInfo dealer)
        {
            bool status = false;
            _cMSEntities.Entry(dealer).State = EntityState.Modified;
            if (_cMSEntities.SaveChanges() > 0)
            {
                status = true;
            }
            return status;
        }

        public CMS_DealerInfo AuthorizeDealer(string email, string password)
        {
            CMS_DealerInfo dealer = _cMSEntities.CMS_DealerInfo.Where(x => x.Email == email && x.Password == password && x.IsActive == true).FirstOrDefault();
            return dealer;
        }

        public List<AddressDetailsViewModel> GetOrders(long id)
        {
            List<CMS_OrderInfo> Orders = _cMSEntities.CMS_OrderInfo.Where(x=>x.DealerId==id).ToList();
            List<AddressDetailsViewModel> addressDetailsViewModels = new List<AddressDetailsViewModel>();
            AddressDetailsViewModel addressDetailsViewModel = new AddressDetailsViewModel();
            foreach (CMS_OrderInfo cMS_OrderInfo in Orders)
            {
                addressDetailsViewModel.OrderId = cMS_OrderInfo.OrderId;
                addressDetailsViewModel.CreatedDate = cMS_OrderInfo.CreatedDate;
                addressDetailsViewModel.FromName = cMS_OrderInfo.FromName;
                addressDetailsViewModel.FromAddressLine = cMS_OrderInfo.FromAddressLine;
                addressDetailsViewModel.FromAreaName = cMS_OrderInfo.FromAreaName;
                addressDetailsViewModel.FromCityName = cMS_OrderInfo.FromCityName;
                addressDetailsViewModel.FromPinCode = cMS_OrderInfo.FromPinCode;
                addressDetailsViewModel.FromMobileNo = cMS_OrderInfo.FromMobileNo;
                addressDetailsViewModel.FromEmail = cMS_OrderInfo.FromEmail;
                addressDetailsViewModel.ToName = cMS_OrderInfo.ToName;
                addressDetailsViewModel.ToAddressLine = cMS_OrderInfo.ToAddressLine;
                addressDetailsViewModel.ToAreaName = cMS_OrderInfo.ToAreaName;
                addressDetailsViewModel.ToCityName = cMS_OrderInfo.ToCityName;
                addressDetailsViewModel.ToPinCode = cMS_OrderInfo.ToPinCode;
                addressDetailsViewModel.ToMobileNo = cMS_OrderInfo.ToMobileNo;
                addressDetailsViewModel.ToEmail = cMS_OrderInfo.ToEmail;
                addressDetailsViewModel.PackageWeight = cMS_OrderInfo.PackageWeight;
                addressDetailsViewModel.DealerProductId = cMS_OrderInfo.DealerProductId;
                addressDetailsViewModel.DealerServiceId = cMS_OrderInfo.DealerServiceId;
                addressDetailsViewModel.Price = cMS_OrderInfo.Price;

                addressDetailsViewModels.Add(addressDetailsViewModel);
            }
            return addressDetailsViewModels;
        }
    }
}
