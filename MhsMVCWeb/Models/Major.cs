using System.ComponentModel.DataAnnotations;

namespace MhsMVCWeb.Models
{
    public class Major
    {
        [Key]
        public int MajorId { get; set; }
        public string MajorName { get; set; }
    }
}
