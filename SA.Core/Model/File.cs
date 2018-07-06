using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace SA.Core.Model
{
    [MySqlCharset("utf8")]
    [MySqlCollation("utf8_general_ci")]
    public class File : Entity<int>
    {
        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Name { get; set; }

        [Required]
        [MySqlCharset("utf8")]
        [MySqlCollation("utf8_general_ci")]
        public virtual string Path { get; set; }

        [Required]
        public virtual int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public virtual int RecordId { get; set; }

        public virtual Record Record { get; set; }
    }
}
