using BettingSport.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettingSport.API.Validators
{
    public class SportEventValidator : AbstractValidator<SportEvent>
    {
        public SportEventValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.OddsForFirstTeam).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(m => m.OddsForDraw).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(m => m.OddsForSecondTeam).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
