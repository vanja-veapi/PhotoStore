using PhotoStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAPI.DataAccess.Entities
{
    public class Order : Entity
    {
        public int CameraId { get; set; }
        public int CartId { get; set; }
        public Camera Camera { get; set; }
        public Cart Cart { get; set; }
        public int Quantity { get; set; }
    }
}
