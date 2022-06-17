using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace parafarmacia.Models
{
    public class UserRoles
    {
        public UserRoles()
        {
            UsersList = new HashSet<Users>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é de preenchimento obrigatório.")]
        [StringLength(40, ErrorMessage = "O nome não pode ter mais de {1} carateres.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        public ICollection<Users> UsersList { get; set; }

    }
}