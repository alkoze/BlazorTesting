using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Test.Shared
{
    public class Publisher : IValidatableObject
    {
        public Guid PublisherId { get; set; }

        [Required(ErrorMessage = "Publisher name is required")]
        [StringLength(32, ErrorMessage ="Name length can`t be more than 32.", MinimumLength = 1)]
        public string PublisherName { get; set; } = default!;

        [Required(ErrorMessage = "Year of creation is required")]
        [Range(0, int.MaxValue, ErrorMessage = "YearFunded can not be less than 0.")]
        public int YearFunded { get; set; } = default!;

        [Range(0, int.MaxValue, ErrorMessage = "YearClosed can not be less than 0.")]
        public int? YearClosed { get; set; } = null;
        public ICollection<Book> PublisherBooks { get; set; } = new List<Book>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (YearFunded > YearClosed)
            {
                yield return new ValidationResult("YearClosed must not be less than YearFunded");
            }
            if (YearClosed > DateTime.Now.Year || YearFunded > DateTime.Now.Year)
            {
                yield return new ValidationResult($"Yearclosed and YearFunded must be less than {DateTime.Now.Year + 1}");
            }
        }
    }
}
