using PhotoStore.Implementation.Validators;
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

namespace PhotoStore.Implementation.UseCases.Commands
{
    //public class EfCreateSpecificationCommand : EfUseCase, ICreateSpecificationCommand
    //{
    //    //private readonly CreateSpecificationValidator _validator;
    //    //public EfCreateSpecificationCommand(
    //    //    PhotoContext context,
    //    //    CreateSpecificationValidator validator) : base(context)
    //    //{
    //    //    _validator = validator;
    //    //}

    //    //public int Id => 7;

    //    //public string Name => "Ef Create Command";

    //    //public string Description => "";

    //    //public void Execute(CreateSpecificationDto request)
    //    //{
    //    //    _validator.ValidateAndThrow(request);
    //    //}
    //}
}
