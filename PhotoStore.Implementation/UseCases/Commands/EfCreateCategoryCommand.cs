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
    //public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    //{
    //    private CreateCategoryValidator _validator;
    //    public EfCreateCategoryCommand(
    //        PhotoContext context, 
    //        CreateCategoryValidator validator) : base(context)
    //    {
    //        _validator = validator;
    //    }

    //    public int Id => 3;

    //    public string Name => "Create Category (EF)";

    //    public string Description => "Create category using entity framework.";

    //    public void Execute(CreateCategoryDto request)
    //    {
    //        _validator.ValidateAndThrow(request);

           
    //    }
    //}
}
