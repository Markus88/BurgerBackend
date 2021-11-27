using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.User.Model
{
    [Table(name: "User")]
    public class User
    {
        [Key]
        [Column(name: "ID")]
        public int ID { get; set; }

        [Column(name: "UserName")]
        public string UserName { get; set; }

        [Column(name: "Email")]
        public string Email { get; set; }

    }
}