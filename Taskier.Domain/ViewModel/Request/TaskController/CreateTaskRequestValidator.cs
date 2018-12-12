using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Taskier.Domain.ViewModel.Request.TaskController
{
    public class CreateTaskRequestValidator: AbstractValidator<CreateTaskRequest>
    {
        public CreateTaskRequestValidator()
        {
            RuleFor(x => x.Subject).NotNull().NotEmpty().MinimumLength(5).MaximumLength(255);
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Today);
            RuleFor(x => x.EndDate).GreaterThan(DateTime.Today);
            RuleFor(x => x.AssignedTo).Empty();
        }
    }
}
