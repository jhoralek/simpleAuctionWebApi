using SA.Core.Model;
using System;
using System.Collections.Generic;


namespace SA.Application.Records
{
    public class RecordTableDto
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime ValidFrom { get; set; }
        public virtual DateTime ValidTo { get; set; }
        public virtual decimal MinimumBid { get; set; }
        public virtual decimal CurrentPrice { get; set; }
        public virtual int NumberOfBids { get; set; }
        public virtual string State { get; set; }
        public virtual ICollection<FileSimpleDto> Files { get; set; } = new List<FileSimpleDto>();        
    }
}
