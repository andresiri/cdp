using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public abstract IList<ValidationFailure> GetModelErrors();

        public void Validate()
        {
            var errorsText = "";
            var errors = GetModelErrors();

            foreach (var error in errors)
            {
                errorsText += error.ErrorMessage + "\n";
            }

            if (!string.IsNullOrEmpty(errorsText))
            {
                throw new Exception(errorsText);
            }
        }
    }
}
