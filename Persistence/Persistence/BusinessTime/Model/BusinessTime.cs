using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.BusinessTime.Model
{
    public class BusinessTime
    {
        [Key]
        [Column(name: "ID")]
        public int ID { get; set; }
        [Column(name: "Day")]
        public int Day { get; set; }
        [Column(name: "OpenTime")]
        public DateTime OpenTime { get; set; }
        [Column(name: "CloseTime")]
        public DateTime CloseTime { get; set; }
    }
}