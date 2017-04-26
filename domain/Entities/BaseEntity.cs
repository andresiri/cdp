﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            var errors = GetModelErrors();

            if (errors.Any()) {

                var errorsText = "";

                foreach (var error in errors)
                {
                    errorsText += error.ErrorMessage + "\n";
                }

                throw new Exception(errorsText);
            }
        }
    }
}
