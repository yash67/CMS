﻿using AutoMapper;
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
    public class QuotationManger : IQuotationManager
    {
        private IQuotationRepository _dealerRepository;

        public QuotationManger(IQuotationRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }



        public List<QuotationViewModel> GetDealerCompanyList(long From, long To, long DealerProductId, long DealerServiceId)
        {
            List<QuotationViewModel> Dealers = _dealerRepository.GetDealerCompanyList(From, To, DealerProductId, DealerServiceId);
            return Dealers;
        }

       
    }
}
