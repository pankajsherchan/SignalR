using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Models
{
  public  class User
    {

        [Key]
        public int UserID { get; set; }

        [Display(Name = "UserName")]
       // [CheckUserNameExists]
        //[Remote("CheckForDuplication", "UsersMVC", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }


        [Required]
        [Display(Name = "LastName")]
        public string LastName { get; set; }



        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Role { get; set; }

        //  public virtual Role Role { get; set; }

        //   public virtual ICollection<InventoryItem> InventoryItems { get; set; }


    }

    public class SignInViewModel
    {
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

