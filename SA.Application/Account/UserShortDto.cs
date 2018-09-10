using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Application.Account
{
    public class UserShortDto
    {
        public virtual int Id { get; set; }

        public virtual string UserName { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string Email { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string FullName { get; set; }

        public virtual string CompanyNumber { get; set; }

        public virtual string CompanyName { get; set; }

        public virtual string Street { get; set; }

        public virtual string City { get; set; }

        public virtual string PostCode { get; set; }
    }
}
