using System;
using System.Collections.Generic;
using System.Text;

namespace UserOnboarding.Domain.Entities
{
    public class MigrationSession
    {
        public int Id { get; set; }
        public int OldCustomerId { get; set; }
        public bool OtpVerified { get; set; } = false;
        public bool PasswordUpdated { get; set; } = false;
    }
}
