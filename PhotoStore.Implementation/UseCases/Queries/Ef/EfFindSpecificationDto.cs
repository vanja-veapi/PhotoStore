using PhotoStore.Application.Exceptions;
using PhotoStore.Application.UseCases.DTO;
using PhotoStore.Application.UseCases.Queries;
using PhotoStore.DataAccess;
using PhotoStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Implementation.UseCases.Queries.Ef
{
    //public class EfFindSpecificationQuery : EfUseCase, IFindSpecificationQuery
    //{
    //    public EfFindSpecificationQuery(PhotoContext context) : base(context)
    //    {
    //    }

    //    public int Id => 6;

    //    public string Name => "Ef Find Specification";

    //    public string Description => "";

    //    public SpecificationDto Execute(int search)
    //    {
    //        var spec = Context.Specifications
    //                    .Include(x => x.SpecificationValues)
    //                    .FirstOrDefault(x => x.Id == search && x.IsActive);

    //        if(spec == null)
    //        {
    //            throw new EntityNotFoundException(nameof(Specification), search);
    //        }

    //        return new SpecificationDto
    //        {
    //            Id = spec.Id,
    //            Name = spec.Name,
    //            SpecificationValues = spec.SpecificationValues.Select(x => new SpecificationValueDto
    //            {
    //                Id = x.Id,
    //                Value = x.Value
    //            })
    //        };
    //    }
    //}
}
