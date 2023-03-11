using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KPI_vol2.Models
{
    /*
 *   id int [pk, increment]
posting_time timestamp
posted_by int [ref: > public.users.id]
comment varchar(max)
 */
    public class Comments
    {
        public int Id { get; set; }
        public int? AttachedToTaskId { get; set; }
        public Zgloszenie? AttachedToTask { get; set; }
        public string? CommentedById { get; set; }
        public AppUser? CommentedBy { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CommentedOn { get; set; }
        public string? Comment { get; set; }
    }
}
