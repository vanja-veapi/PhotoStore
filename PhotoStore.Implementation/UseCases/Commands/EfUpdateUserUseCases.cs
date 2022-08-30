using PhotoStore.Implementation.Validators;
using PhotoStore.Application.UseCases.Commands;
using PhotoStore.DataAccess;
using PhotoStore.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Implementation.UseCases.Commands
{
    public class EfUpdateUserUseCases : EfUseCase, IUpdateUserUseCasesCommand
    {
        private readonly UpdateUserUseCasesValidator _validator;
        public EfUpdateUserUseCases(
            PhotoContext context, 
            UpdateUserUseCasesValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Update user actions";

        public string Description => "";

        public void Execute(UpdateUserUseCasesDto request)
        {
            _validator.ValidateAndThrow(request);

            var userUseCases = Context.UserUseCases
                                      .Where(x => x.UserId == request.UserId)
                                      .ToList();

            Context.UserUseCases.RemoveRange(userUseCases);

            var useCasesToAdd = request.UseCaseIds.Select(x => new UserUseCase
            {
                UseCaseId = x,
                UserId = request.UserId.Value
            });

            Context.AddRange(useCasesToAdd);

            Context.SaveChanges();
        }
    }
}
