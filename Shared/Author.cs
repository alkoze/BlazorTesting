using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
    public class Author : IValidatableObject
    {
        
        public Guid AuthorId { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "YearFunded can not be less than 0.")]
        public int YearBorn{ get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "YearFunded can not be less than 0.")]
        public int? YearDied { get; set; } = null;

        [Required]
        [StringLength(32, ErrorMessage = "Name length can`t be more than 32.", MinimumLength = 1)]
        public string FirstName{ get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "Name length can`t be more than 32.", MinimumLength = 1)]
        public string LastName{ get; set; }

        public ICollection<BookAuthor>? BookAuthors{ get; set; }

        public ICollection<Book>? Books { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (YearDied < YearBorn)
            {
                yield return new ValidationResult("YearBorn must not be less than YearDied");
            }
            if (YearDied > DateTime.Now.Year || YearBorn > DateTime.Now.Year)
            {
                yield return new ValidationResult($"YearBorn and YearDied must be less than {DateTime.Now.Year + 1}");
            }
        }
    }
}
