using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public Int64 DOB { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PIN { get; set; }
        public string LoginType { get; set; }

        public void SetLoginType(string loginType) => LoginType = loginType;
        public void HashPassword(string hashedPassword) => Password = hashedPassword;
            
    }
}
