using System;
using System.Collections.Generic;
using System.Text;

namespace UserOnboarding.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PinHash { get; set; }
        public bool IsMigrated { get; set; }
        public bool IsActive { get; set; }
    }
}
