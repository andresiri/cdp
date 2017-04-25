using System;
using System.Collections.Generic;
using Domain.Entities.Validations;
using FluentValidation.Results;

namespace Domain.Entities
{
    public enum Position
    {
        Goleiro, Zagueiro, MeioCampo, Atacante
    }

    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public byte Number { get; set; }
        public Position? Position { get; set; }

        public IList<ValidationFailure> Validate()
        {
            var validator = new UserValidation();
            var results = validator.Validate(this);

            var failures = results.Errors;

            throw new Exception(failures[0].ErrorMessage);
        }
    }
}
