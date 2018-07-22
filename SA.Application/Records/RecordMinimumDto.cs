using System;
using System.Collections.Generic;
using System.Text;

namespace SA.Application.Records
{
    public class RecordMinimumDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ValidTo { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
