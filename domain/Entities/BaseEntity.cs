using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using domain.Entities.Exceptions;
using domain.Entities.Enum;
using FluentValidation;

namespace domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public abstract IList<ValidationFailure> GetModelErrors();

        public void Validate()
        {            
            var errors = GetModelErrors();

            if (errors.Any()) {

                var info = new List<ExceptionInfo>();

                foreach (var error in errors)
                {
                    info.Add(new ExceptionInfo(error.PropertyName, error.ResourceName));
                }

                throw new CustomException(ExceptionType.CUSTOM_ERROR, info);
            }
        }
    }
}
