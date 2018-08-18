using System;
using System.ComponentModel.DataAnnotations;
using MySql.Data.EntityFrameworkCore.DataAnnotations;
using SA.Core.Enums;

namespace SA.Core.Model
{
    [MySqlCharset("utf8")]
    [MySqlCollation("utf8_general_ci")]
    public class GdprRecord : Entity<int>
    {
        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string FirstName { get; set; }

        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Email { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string CompanyNumber { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string BirthNumber { get; set; }        

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string CompanyName { get; set; }

        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string PhoneNumber { get; set; }

        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Street { get; set; }

        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string City { get; set; }

        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string PostCode { get; set; }

        [Required]
        public virtual int CountryId { get; set; }

        public virtual Country Country { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Description { get; set; }

        [Required]
        public virtual GdprApplicationType Type { get; set; }

        [Required]
        public virtual bool IsProcessed { get; set; }
    }
}
