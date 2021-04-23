using FluentValidation;
using System;

namespace FluentValidationDemo.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Identity { get; set; }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Identity)
                .Must(x => x != 0)
                .WithMessage("cannot be zero");

            RuleFor(x => x.BirthDate)
                .Must(ValidateAgeOfMajority)
                .WithMessage("Minors are not allowed.");
        }

        private bool ValidateAgeOfMajority(DateTime birthDate) => Convert.ToDateTime(birthDate).AddYears(18) < DateTime.Now ? true : false;

    }
}
