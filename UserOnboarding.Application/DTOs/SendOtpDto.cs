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
    public class MigrationValidateDto
    {
        public string MobileNumber { get; set; }
        public string CNIC { get; set; }
    }
    public class OtpRequestDto
    {
        public string MobileNumber { get; set; }
    }
    public class OtpVerifyDto
    {
        public string MobileNumber { get; set; }
        public string Code { get; set; }
    }
   
}
