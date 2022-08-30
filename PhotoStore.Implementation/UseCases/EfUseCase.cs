using PhotoStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(PhotoContext context)
        {
            Context = context;
        }

        protected PhotoContext Context { get; }
    }
}
