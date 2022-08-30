using PhotoStore.Application.UseCases;
using PhotoStore.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Application.UseCases.Queries
{
    public interface IFindSpecificationQuery : IQuery<int, SpecificationDto>
    {
    }
}
