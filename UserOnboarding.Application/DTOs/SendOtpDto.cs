using System;
using System.Collections.Generic;
using System.Text;

namespace UserOnboarding.Application.DTOs
{
    public class SendOtpDto
    {
        public string MobileNumber { get; set; }
    }

    public class VerifyOtpDto
    {
        public string MobileNumber { get; set; }
        public string Otp { get; set; }
    }

    public class RegisterDto
    {
        public string MobileNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }

    public class SetPinDto
    {
        public string MobileNumber { get; set; }
        public string Pin { get; set; }
    }
}
