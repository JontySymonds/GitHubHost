using System.ComponentModel.DataAnnotations;

namespace GitHubHost.Models
{
    public class FormData
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Required, EarliestDate(ErrorMessage = "Date must be after 1970")]
        public DateTime Date { get; set; }

        public bool HighPriority { get; set; }

        [Required]
        public CategoryEnum Category { get; set; }



        
        public enum CategoryEnum
        {
            category1 = 1,
            category2 = 2,
            category3 = 3,
            category4 = 4

        }

    }

    public class EarliestDateAttribute : ValidationAttribute
    {
        public EarliestDateAttribute() { }

        public string GetErrorMessage() => "Date Must be after 1970";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            DateTime EarliestDate = new(1970, 1, 1);

            if (DateTime.Compare(date, EarliestDate) < 0)
            {
                return new ValidationResult(GetErrorMessage());
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
