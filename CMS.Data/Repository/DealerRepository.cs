using CMS.Data.Database;
using CMS.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using CMS.BusinessEntities.ViewModel;

namespace CMS.Data.Repository
{
    public class DealerRepository : IDealerRepository
    {
        private CMSEntities CMSEntities;
        public DealerRepository()
        {
            CMSEntities = new CMSEntities();
        }

        public List<DealerViewModel> GetDealerCompanyList(long From, long To, long DealerProductId, long DealerServiceId)
        {
            //List<long> cMS_DealerCities = CMSEntities.CMS_DealerCity.Where(x => x.CityId == From || x.CityId == To).Select(x => x.CityId).ToList();
            List<long> cMS_DealerCities = new List<long> { From, To};
            List<CMS_DealerInfo> dealers = (from d in CMSEntities.CMS_DealerInfo join c in CMSEntities.CMS_DealerCity on d.DealerId equals
                                            c.DealerId where cMS_DealerCities.Contains(c.CityId) join p in CMSEntities.CMS_DealerProductCategory
                                            on d.DealerId equals p.DealerId where p.CategoryId == DealerProductId join s in CMSEntities.CMS_DealerService
                                            on d.DealerId equals s.DealerId where s.ServiceId == DealerServiceId select d).Include(x => x.CMS_DealerRate).ToList();
            //List<decimal> perkgprice = dealers[0].CMS_DealerRate.Cast<CMS_DealerRate>().Select(x => x.PerKgPrice).ToList();

            //dealers = dealers.Where(x => cMS_DealerCities.Contains(x.CMS_DealerCity.))
            dealers = dealers.Distinct().ToList();
            List<DealerViewModel> dealerViewModels = new List<DealerViewModel>();
            foreach(CMS_DealerInfo cMS_DealerInfo in dealers)
            {
                DealerViewModel dealerViewModel = new DealerViewModel();
                dealerViewModel.DealerId = cMS_DealerInfo.DealerId;
                dealerViewModel.RoleId = cMS_DealerInfo.RoleId;
                dealerViewModel.CompanyName = cMS_DealerInfo.CompanyName;
                dealerViewModel.CategoryName = CMSEntities.CMS_ProductCategoryMaster.Find(DealerProductId).CategoryName;
                dealerViewModel.ServiceName = CMSEntities.CMS_ServiceMaster.Find(DealerServiceId).ServiceName;
                
                dealerViewModel.PerCategoryPrice = cMS_DealerInfo.CMS_DealerRate.Cast<CMS_DealerRate>().FirstOrDefault().PerCategoryPrice;
                dealerViewModel.PerServicePrice = cMS_DealerInfo.CMS_DealerRate.Cast<CMS_DealerRate>().FirstOrDefault().PerServicePrice;
                dealerViewModel.PerKgPrice = cMS_DealerInfo.CMS_DealerRate.Cast<CMS_DealerRate>().FirstOrDefault().PerKgPrice;
                dealerViewModel.PerKmPrice = cMS_DealerInfo.CMS_DealerRate.Cast<CMS_DealerRate>().FirstOrDefault().PerKmPrice;
                dealerViewModels.Add(dealerViewModel);
            }
            return dealerViewModels;
        }

        public List<AddressDetailsViewModel> GetOrders()
        {
            List<AddressDetailsViewModel> addressDetailsViewModels = new List<AddressDetailsViewModel>();
            List<CMS_OrderInfo> Orders = CMSEntities.CMS_OrderInfo.ToList();
            foreach(CMS_OrderInfo cMS_OrderInfo in Orders)
            {
                AddressDetailsViewModel addressDetailsViewModel = new AddressDetailsViewModel();
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