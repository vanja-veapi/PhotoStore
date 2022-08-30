using PhotoStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAPI.DataAccess.Entities
{
    public class Brand : Entity
    {
        public string Name { get; set; }
        public ICollection<Camera> Cameras { get; set; } = new List<Camera>();
    }

}