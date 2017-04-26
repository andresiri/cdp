using System.Collections.Generic;
using FluentValidation.Results;

namespace domain.Entities
{
    public class Arena : BaseEntity
    {
        public string Description { get; set; }
		public string Name { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }		

        public override IList<ValidationFailure> GetModelErrors()
        {
            return new ValidationFailure[]{};
        }
    }
}
