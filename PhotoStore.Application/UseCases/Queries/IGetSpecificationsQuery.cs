using PhotoStore.Application.UseCases;
using PhotoStore.Application.UseCases.DTO;
using PhotoStore.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Application.UseCases.Queries
{
    public interface IGetSpecificationsQuery : IQuery<BaseSearch, IEnumerable<SpecificationDto>>
    {
    }
}
