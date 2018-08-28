using System;
using System.Collections.Generic;

namespace SA.Application.Records
{
    public class AuctionDto
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsEnded { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }
        public virtual ICollection<RecordTableDto> Records { get; set; } = new List<RecordTableDto>();
    }
}
