using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class EmployeeViewModel : IValidatableObject
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия обязательная")]
        [StringLength(255, MinimumLength=2, ErrorMessage = "Length  min 2 max 255 letters")]
        [RegularExpression(@"[А-ЯЁ][а-яё]+|([A-Z][a-z]+)", ErrorMessage = "Failed format")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        [Required]
        [StringLength(255, MinimumLength = 2, ErrorMessage = "Length  min 2 max 255 letters")]
        [RegularExpression(@"[А-ЯЁ][а-яё]+|([A-Z][a-z]+)", ErrorMessage = "Failed format")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(255, ErrorMessage = "Length max 255 letters")]
        [RegularExpression(@"[А-ЯЁ][а-яё]+|([A-Z][a-z]+)?", ErrorMessage = "Failed format")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст")]
        [Range(18, 80, ErrorMessage = "Age min 2 max 255")]
        public int Age { get; set; }

        [Display(Name = "Департамент")]
        public int Department { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext Context)
        {
            if (LastName.Length > 10)
            {
                yield return new ValidationResult("Lenght Last Name more 10 symbol");
            }

            yield return ValidationResult.Success!;
        }
    }
}
