using System;
using System.Collections.Generic;

namespace SA.Application.Records
{
    public class RecordMinimumDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime ValidFrom { get; set; }
        public decimal CurrentPrice { get; set; }
        public bool WithVat { get; set; }
        public int WinningUserId { get; set; }
        public List<int> BiddingUserIds { get; set; } = new List<int>();
    }
}
