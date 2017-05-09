using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace domain.Entities
{
    public class Pelada : BaseEntity
    {
        public string Name { get; set; }
        public int CreatedByUserId { get; set; }

        public User CreatedByUser { get; set; }
        public List<PeladaUser> PeladaUsers { get; set; }

        public override IList<ValidationFailure> GetModelErrors()
        {
            return new ValidationFailure[] { };
        }
    }
}