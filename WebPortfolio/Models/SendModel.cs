using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebPortfolio.Models
{
    public class SendModel
    {
        [Display(Name = "Ваше имя")]
        public string Name { get; set; }
        [Display(Name = "Ваша почта")]
        public string Email { get; set; }
        [Display(Name = "Телефон для связи")]
        public string Telefone { get; set; }
        [Display(Name = "Опишите необходимый вам проект")]
        public string Text { get; set; }
        //public OneImageModel Image1 { get; set; }
    }
}