using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.City.Model
{
    [Table(name: "City")]
    public class City
    {
        [Key]
        [Column(name: "ID")]
        public int ID { get; set; }
        [Column(name: "Name")]
        public string Name { get; set; }
        [Column(name: "Zipcode")]
        public int ZipCode { get; set; }
    }
}