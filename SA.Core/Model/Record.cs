using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SA.Core.Model
{
    [MySqlCharset("utf8")]
    [MySqlCollation("utf8_general_ci")]
    public class Record : Entity<int>
    {
        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Name { get; set; }

        [Required]
        [DefaultValue(false)]
        public virtual bool IsActive { get; set; }

        [MaxLength(200)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Color { get; set; }

        [MaxLength(50)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Mileage { get; set; }

        [MaxLength(45)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string EngineCapacity { get; set; }

        [MaxLength(100)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Body { get; set; }

        [MaxLength(45)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Power { get; set; }

        [MaxLength(10)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Fuel { get; set; }

        [MaxLength(45)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Transmission { get; set; }

        [MaxLength(45)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Axle { get; set; }

        [MaxLength(100)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string RegistrationCheck { get; set; }

        [MaxLength(100)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string ContactToAppointment { get; set; }

        [Required]
        public virtual Decimal MinimumBid { get; set; }

        [Required]
        public virtual Decimal StartingPrice { get; set; }

        [Required]
        public virtual DateTime ValidFrom { get; set; }

        [Required]
        public virtual DateTime ValidTo { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Defects { get; set; }

        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string MoreDescription { get; set; }

        [MaxLength(100)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string State { get; set; }

        [MaxLength(250)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Equipment { get; set; }

        [MaxLength(45)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Vin { get; set; }

        public virtual int? NumberOfSeets { get; set; }

        [MaxLength(10)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string EuroNorm { get; set; }

        public virtual int? Doors { get; set; }

        public virtual DateTime? DateOfFirstRegistration { get; set; }

        public virtual DateTime? Stk { get; set; }

        [MaxLength(250)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Dimensions { get; set; }

        [MaxLength(250)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string OperationWeight { get; set; }

        [MaxLength(250)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string MostTechnicallyAcceptableWeight { get; set; }

        [MaxLength(100)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string MaximumWeight { get; set; }

        [MaxLength(100)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string MostTechnicallyWeightOfRide { get; set; }

        [MaxLength(100)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string MaximumWeightOfRide { get; set; }

        [MaxLength(100)]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Place { get; set; }

        [Required]
        public virtual int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<File> Files { get; set; } = new List<File>();

        public virtual ICollection<Bid> Bids { get; set; } = new List<Bid>();

        [Required]
        public virtual int AuctionId { get; set; }

        public virtual Auction Auction { get; set; }
    }
}
