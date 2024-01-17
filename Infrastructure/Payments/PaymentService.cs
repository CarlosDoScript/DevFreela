using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            return Task.FromResult(true);
        }
    }
}
