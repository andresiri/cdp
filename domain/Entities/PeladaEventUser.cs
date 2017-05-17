using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace domain.Entities
{
    public class PeladaEventUser : BaseEntity
    {
        public int PeladaEventId { get; set; }
        public int UserId { get; set; }
        public bool UserConfirmed { get; set; }

        public virtual PeladaEvent PeladaEvent { get; set; }
        public virtual User User { get; set; }

        public override IList<ValidationFailure> GetModelErrors()
        {
            throw new NotImplementedException();
        }
    }
}
