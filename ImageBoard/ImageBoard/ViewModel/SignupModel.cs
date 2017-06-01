using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ImageBoard.ViewModel
{
    public class SignupModel
    {
        [Required]
        [Display(Name = "Имя Пользователя")]
        [Remote("CheckUserName", "Account")]
        [MaxLength(20, ErrorMessage = "Превышена максимальная длина записи")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пожалуйста повторите пороль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите Пароль")]
        public string Password2 { get; set; }

        [Required]
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}