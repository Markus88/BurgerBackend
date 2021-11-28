using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.StoredFileInformation.Model
{
    [Table(name: "StoredFileInformation")]
    public class StoredFileInformation
    {
        [Key]
        [Column(name: "ID")]
        public int ID { get; set; }
        [Column(name: "FileName")]
        public string FileName { get; set; }

        [Column(name: "FileLocation")]
        public string FileLocation { get; set; }
    }
}