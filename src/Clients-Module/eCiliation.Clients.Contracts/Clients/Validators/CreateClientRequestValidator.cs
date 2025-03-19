using FastEndpoints;
using FluentValidation;

namespace eCiliation.Clients.Contracts.Clients.Validators;

public class CreateClientRequestValidator : Validator<CreateClientRequest>
{
  public CreateClientRequestValidator()
  {
    RuleFor(x => x.UserId)
      .NotEmpty()
      .WithMessage("user id is required!")
      .MinimumLength(2)
      .WithMessage("user id is too short!")
      .MaximumLength(50)
      .WithMessage("user id is too long!");

    RuleFor(x => x.Description)
      .NotEmpty()
      .WithMessage("client description is required!")
      .MinimumLength(2)
      .WithMessage("client description is too short!")
      .MaximumLength(100)
      .WithMessage("client description is too long!");

    RuleFor(x => x.Name)
      .NotEmpty()
      .WithMessage("client name is required!")
      .MinimumLength(2)
      .WithMessage("client name is too short!")
      .MaximumLength(100)
      .WithMessage("client name is too long!");
  }
}
