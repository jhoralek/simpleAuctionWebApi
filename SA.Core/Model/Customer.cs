using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SA.Core.Model
{
    [MySqlCharset("utf8")]
    [MySqlCollation("utf8_general_ci")]
    public class Customer : Entity<int>
    {
        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string FirstName { get; set; }

        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string LastName { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string BirthNumber { get; set; }

        [Required]
        [Phone]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Email { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string TitleBefore { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string TitleAfter { get; set; }

        [Required]
        [DefaultValue(false)]
        public virtual bool IsDealer { get; set; }

        [Required]
        [DefaultValue(false)]
        public virtual bool IsFeePayed { get; set; }

        [Url]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string WebPageUrl { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string CompanyNumber { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string CompanyName { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string CompanyLegalNumber { get; set; }

        [Required]
        public virtual int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
