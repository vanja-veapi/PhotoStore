using PhotoStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoAPI.DataAccess.Entities
{
    public class Cart : Entity
    {
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
