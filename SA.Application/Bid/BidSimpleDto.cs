using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Application.Bid
{
    public class BidSimpleDto
    {
        public virtual int Id { get; set; }
        public virtual int RecordId { get; set; }
        public virtual int UserId { get; set; }
        public virtual decimal Price { get; set; }
    }
}
