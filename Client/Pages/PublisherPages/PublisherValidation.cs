using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Client.Shared;

namespace Test.Client.Pages.PublisherPages
{
    public class PublisherValidation : ComponentBase
    {

        protected bool HandleValidSubmit(CustomValidator customValidator, Test.Shared.Publisher _publisher)
        {
            customValidator.ClearErrors();

            var errors = new Dictionary<string, List<string>>();
            string message;
            if (_publisher.YearClosed < _publisher.YearFunded)
            {
                message = "Year closed must not be less than year founded.";
                errors = ErrorsAdding(errors, message, _publisher);
            }
            if (_publisher.YearClosed < 0 || _publisher.YearClosed > DateTime.Now.Year)
            {
                message = $"Year closed must be between 0 and {DateTime.Now.Year}";
                errors = ErrorsAdding(errors, message, _publisher);
            }
            if (_publisher.YearFunded < 0 || _publisher.YearFunded > DateTime.Now.Year)
            {
                message = $"Year founded must be between 0 and {DateTime.Now.Year}";
                errors = ErrorsAdding(errors, message, _publisher);
            }
            if (errors.Count() > 0)
            {
                customValidator.DisplayErrors(errors);
                return false;
            }
            return true;
        }

        protected Dictionary<string, List<string>> ErrorsAdding(Dictionary<string, List<string>> errors, string message, Test.Shared.Publisher _publisher)
        {
            if (errors.ContainsKey(_publisher.PublisherName))
            {
                errors[_publisher.PublisherName].Add(message);
            }
            else
            {
                errors.Add(_publisher.PublisherName, new List<string>() { message });
            }
            return errors;
        }
    }
}
