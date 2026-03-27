using System;
using System.Collections.Generic;
using System.Text;

namespace UserOnboarding.Domain.Entities
{
    public class OtpVerification
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string OtpCode { get; set; } = string.Empty;
        public DateTime Expiry { get; set; }
        public bool IsVerified { get; set; } = false;
    }
}
