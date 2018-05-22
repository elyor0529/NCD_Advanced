

namespace NCD.Application
{

    using Foolproof;
    using System.ComponentModel.DataAnnotations;

    public class SearchViewModel
    {
        [Display(Name = "Enter person name")]
        [StringLength(50, ErrorMessage = "The '{0}' must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Range(12, 100, ErrorMessage = "'{0}' must be between 12 and 100.")]
        [Display(Name = "Age from")]
        public int? AgeFrom { get; set; }

        [Range(12, 100, ErrorMessage = "'{0}' must be between 12 and 100.")]
        [GreaterThanOrEqualTo("AgeFrom")]
        [Display(Name = "Age to")]
        public int? AgeTo { get; set; }

        [Range(50, 250, ErrorMessage = "'{0}' must be between 50 and 250.")]
        [Display(Name = "Height from")]
        public double? HeightFrom { get; set; }

        [Range(50, 250, ErrorMessage = "'{0}' must be between 50 and 250.")]
        [GreaterThanOrEqualTo("HeightFrom")]
        [Display(Name = "Height to")]
        public double? HeightTo { get; set; }

        [Range(50, 250, ErrorMessage = "'{0}' must be between 50 and 250.")]
        [Display(Name = "Weight from")]
        public double? WeightFrom { get; set; }

        [Range(50, 250, ErrorMessage = "{0} must be between 50 and 250.")]
        [GreaterThanOrEqualTo("WeightFrom")]
        [Display(Name = "Weight to")]
        public double? WeightTo { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(250, ErrorMessage = "The email is to long, it should not exced 250 characters.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Range(10, 500, ErrorMessage = "'{0}' must be between 10 and 500.")]
        [Display(Name = "Max number of results")]
        public int? MaxNumberResults { get; set; }

    }
}