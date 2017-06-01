using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ImageBoard.ViewModel
{
    public class ProfileModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Пожалуйста Введите Ваш Email Адрес.")]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста Введите Вашу Фамилию")]
        [Display(Name = "Фамилия")]
        [MaxLength(20, ErrorMessage = "Превышена максимальная длина записи")]
        public string SubName { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите ваше Имя")]
        [Display(Name = "Имя")]
        [MaxLength(20, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }
                
        [Required(ErrorMessage = "Пожайлуйста выберите ваш пол")]
        [Display(Name = "Пол")]
        public bool Sex { get; set; }

        [Required(ErrorMessage = "Введите Вашу Дату Рождения")]
        [Display(Name = "Дата Рождения")]
        public DateTime Birthday { get; set; }
    }
}