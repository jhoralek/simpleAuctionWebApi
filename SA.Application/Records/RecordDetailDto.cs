using SA.Application.Customer;
using System;
using System.Collections.Generic;

namespace SA.Application.Records
{
    public class RecordDetailDto
    {   
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }     
        public virtual bool IsActive { get; set; }
        public virtual string Color { get; set; }
        public virtual string Mileage { get; set; }
        public virtual string EngineCapacity { get; set; }
        public virtual string Body { get; set; }        
        public virtual string Power { get; set; }
        public virtual string Fuel { get; set; }
        public virtual string Transmission { get; set; }
        public virtual string Axle { get; set; }
        public virtual string RegistrationCheck { get; set; }
        public virtual string ContactToAppointment { get; set; }
        public virtual Decimal MinimumBid { get; set; }
        public virtual Decimal StartingPrice { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }
        public virtual string Defects { get; set; }
        public virtual string MoreDescription { get; set; }
        public virtual string State { get; set; }
        public virtual string Equipment { get; set; }
        public virtual string Vin { get; set; }
        public virtual int? NumberOfSeets { get; set; }
        public virtual string EuroNorm { get; set; }
        public virtual int? Doors { get; set; }
        public virtual DateTime? DateOfFirstRegistration { get; set; }
        public virtual DateTime? Stk { get; set; }
        public virtual string Dimensions { get; set; }
        public virtual string OperationWeight { get; set; }
        public virtual string MostTechnicallyAcceptableWeight { get; set; }
        public virtual string MaximumWeight { get; set; }
        public virtual string MostTechnicallyWeightOfRide { get; set; }
        public virtual string MaximumWeightOfRide { get; set; }
        public virtual int UserId { get; set; }
        public virtual string Place { get; set; }
        public virtual ICollection<FileSimpleDto> Files { get; set; } = new List<FileSimpleDto>();
        public virtual ICollection<BidSimpleDto> Bids { get; set; } = new List<BidSimpleDto>();
    }
}
