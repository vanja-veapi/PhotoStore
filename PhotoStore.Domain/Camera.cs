using PhotoStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAPI.DataAccess.Entities
{
    public class Camera : Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public decimal? OldPrice { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
    }
}
