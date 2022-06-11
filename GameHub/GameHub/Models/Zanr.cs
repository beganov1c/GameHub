using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GameHub.Models
{
    public enum Zanr
    {
        [Display(Name = "Akcija")]
        AKCIJA,
        [Display(Name = "Avantura")]
        AVANTURA,
        [Display(Name = "Sci-Fi")]
        SF,
        [Display(Name = "Horor")]
        HOROR,
        [Display(Name = "Strategija")]
        STRATEGIJA,
        [Display(Name = "Sportska")]
        SPORTSKA,
        [Display(Name = "Arkadna")]
        ARKADNA,
        [Display(Name = "RPG")]
        RPG,
        [Display(Name = "Party")]
        PARTY,
        [Display(Name = "Simulacija")]
        SIMULACIJA,
        [Display(Name = "Tekstualna")]
        TEKSTUALNA
    }
}
