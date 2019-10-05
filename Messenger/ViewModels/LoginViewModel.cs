using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Messenger.ViewModels
{
    public class LoginViewModel : ValidableViewModel
    {
        public LoginViewModel()
        {
            Email = "b.bullert@gmail.com";
        }

        private string email;
        [Required(ErrorMessage = "This field cannot be empty.This field cannot be empty.This field cannot be empty.")]
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
    }
}
