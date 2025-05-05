using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF配置DataAnnotations
{
    [Table("T_Books")]
    public class Book
    {
        public long Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Title { get; set; } = null!;
        public DateTime PubTime { get; set; }
        public double Price { get; set; }
        [MaxLength(20)]
        [Required]
        public string AuthorName { get; set; }

        public DateTime InsertDateTime { get; set; } = DateTime.Now;
    }
}
