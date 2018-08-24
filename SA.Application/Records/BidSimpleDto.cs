using System;

namespace SA.Application.Records
{
    public class BidSimpleDto
    {
        public virtual int Id { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int RecordId { get; set; }
        public virtual int UserId { get; set; }
        public virtual DateTime Created {get; set; }
        public virtual string UserName {get; set; }
    }
}
