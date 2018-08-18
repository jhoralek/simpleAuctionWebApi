using System;
using SA.Core.Enums;

namespace SA.Application.Records
{
    public class GdprRecordTableDto
    {
        public virtual int Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string City { get; set; }
        public virtual GdprApplicationType Type { get; set; }
        public virtual bool IsProcessed { get; set; }
        public virtual DateTime Created { get; set; }
    }
}
