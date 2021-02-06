using FluentValidation;
using SM.Core.DTOs;
using System;

namespace SM.Infraestructure.Validator
{
  public  class EventValidator:AbstractValidator<EventDto>
    {
        public EventValidator()
        {
            RuleFor(x => x.Date).NotNull().GreaterThan(DateTime.Now);
        }
     
    }
}
