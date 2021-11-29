using System.ComponentModel.DataAnnotations;

namespace User.Domain.Interface.Model
{
    public interface IUserModel
    {
        [Required]
        int ID { get; set; }

        [Required]
        [StringLength(50)]
        string UserName { get; set; }

        [Required]
        [StringLength(255)]
        string Email { get; set; }
    }
}