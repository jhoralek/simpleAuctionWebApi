using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SA.Core.Model
{
    [MySqlCharset("utf8")]
    [MySqlCollation("utf8_general_ci")]
    public class Auction : Entity<int>
    {
        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Name { get; set; }

        [Required]
        [DefaultValue(false)]
        public virtual bool IsActive { get; set; }

        [Required]
        public virtual DateTime ValidFrom { get; set; }

        [Required]
        public virtual DateTime ValidTo { get; set; }

        [Required]
        [DefaultValue(false)]
        public virtual bool IsEnded { get; set; }

        public virtual ICollection<Record> Records { get; set; } = new List<Record>();
    }
}
