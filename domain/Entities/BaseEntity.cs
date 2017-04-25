using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Domain.Entities
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
                Console.WriteLine(error.PropertyName + " " + error.AttemptedValue + "/n");
                string.Concat(errorsText, error.PropertyName + " " + error.ErrorCode + "/n");
            }

            if (!string.IsNullOrEmpty(errorsText))
            {
                throw new Exception(errorsText);
            }
        }
    }
}
