using System.Collections.Generic;
using domain.Entities.Validations;
using FluentValidation.Results;
using System;

namespace domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime? Birthday { get; set; }
        public byte? Number { get; set; }
        public string Position { get; set; }

        public virtual List<PeladaUser> PeladaUsers { get; set; }
        public virtual List<Pelada> Peladas { get; set; }

        public override IList<ValidationFailure> GetModelErrors()
        {
            var validator = new UserValidation();
            var results = validator.Validate(this);

            return results.Errors;
        }
    }
}
