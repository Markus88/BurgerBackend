using System.ComponentModel.DataAnnotations;

namespace User.Domain.Interface.Model
{
    public interface IUserModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}