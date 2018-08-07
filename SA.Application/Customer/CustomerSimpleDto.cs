using SA.Core.Model;
using System;

namespace SA.Application.Customer
{
    public class CustomerSimpleDto
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string BirthNumber { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string TitleBefore { get; set; }
        public virtual string TitleAfter { get; set; }
        public virtual bool IsDealer { get; set; }
        public virtual bool IsFeePayed { get; set; }
        public virtual string WebPageUrl { get; set; }
        public virtual string CompanyNumber { get; set; }
        public virtual string CompanyLegalNumer { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual DateTime Created { get; set; }
    }
}
