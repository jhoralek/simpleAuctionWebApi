using System;

namespace SA.Application.Records
{
    public class AuctionLookupDto
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }
    }
}
