using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Data
{
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "Datum rođenja")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Opis(neobavezno)")]
        public string Opis { get; set; }

        public string Slika { get; set; }

    }

}