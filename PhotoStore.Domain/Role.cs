using PhotoStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAPI.DataAccess.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }

        // public int UserId { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
