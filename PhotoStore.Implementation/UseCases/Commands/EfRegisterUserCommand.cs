using PhotoStore.Implementation.Validators;
using PhotoStore.Application.Emails;
using PhotoStore.Application.UseCases.Commands;
using PhotoStore.Application.UseCases.DTO;
using PhotoStore.DataAccess;
using PhotoStore.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAPI.DataAccess.Entities;
using PhotoStore.Implementation.UseCases;

namespace PhotoAPI.Implementation.UseCases.Commands
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;

        public EfRegisterUserCommand(PhotoContext context, RegisterUserValidator validator, IEmailSender sender) : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public void Execute(RegisterDto request)
        {
            _validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = hash,
                Name = request.Name,
                LastName = request.LastName
            };

            Context.Users.Add(user);
            Context.SaveChanges();

            //slanje email-a za verifikaciju

            _sender.Send(new MessageDto
            {
                To = request.Email,
                Title = "Successfull registration!",
                Body = "Dear " + request.Username + "\n Please activate your account...."
            });
        }

        public int Id => 4;

        public string Name => "User reigstration (Using EF)";

        public string Description => "";
    }
}
