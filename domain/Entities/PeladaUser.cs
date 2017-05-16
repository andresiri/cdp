using System;
using System.Collections.Generic;
using FluentValidation.Results;
using domain.Entities.Validations;

namespace domain.Entities
{
    public class PeladaUser : BaseEntity
    {
        public int PeladaId { get; set; }
        public virtual Pelada Pelada { get; set; }
        public bool IsMonthly { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public override IList<ValidationFailure> GetModelErrors()
        {
            var validator = new PeladaUserValidation();
            var results = validator.Validate(this);

            return results.Errors;
        }
    }
}
