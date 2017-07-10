using System;
using System.Collections.Generic;
using System.Linq;
using api.Context.Transaction;
using domain;
using domain.Entities.Enum;
using domain.Entities.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace api
{
    public abstract class Operation<T> where T: Model
    {
        public readonly IUnitOfWork _unitOfWork;

        public Operation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public abstract AbstractValidator<T> GetValidation(T entity);

        public abstract object Process(T entity);

        public object Execute(T entity) {

            try
            {
                var validation = GetValidation(entity);

                if (validation != null) {
                 
                    var validationResult = validation.Validate(entity);
                    HandleErrors(validationResult.Errors);
                }

                var result = Process(entity);

                //validate if last operation
                _unitOfWork.Save();

                return result;
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        private void HandleErrors(IList<ValidationFailure> errors)
        {
            if (errors.Any())
            {
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
