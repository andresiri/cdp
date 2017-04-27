using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace domain.Entities
{
    public class PeladaUser : BaseEntity
    {
        public int PeladaId { get; set; }
        public Pelada Pelada { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public override IList<ValidationFailure> GetModelErrors()
        {
            return new ValidationFailure[]{};
        }
    }
}
