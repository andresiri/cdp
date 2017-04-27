using System.Collections.Generic;
using domain.Entities.Validations;
using FluentValidation.Results;

namespace domain.Entities
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
        public byte? Number { get; set; }
        public Position? Position { get; set; }

        public List<PeladaUser> PeladaUsers { get; set; }
        public List<Pelada> Peladas { get; set; }

        public override IList<ValidationFailure> GetModelErrors()
        {
            var validator = new UserValidation();
            var results = validator.Validate(this);

            return results.Errors;
        }
    }
}
