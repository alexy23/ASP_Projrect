using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImageBoard.ViewModel
{
    public class PostModel
    {
        [Required]
        [MaxLength(24, ErrorMessage = "Превышена длина Имени Комментария")]
        public string PostName { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Превышена максимальная длина записи")]
        public string Status { get; set; }
    }
}