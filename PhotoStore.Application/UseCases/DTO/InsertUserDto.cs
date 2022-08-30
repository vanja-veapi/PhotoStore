using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStore.Application.UseCases.DTO
{
    public class InsertUserDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ProfileImage { get; set; }
        public bool isActive { get; set; }
        public int RoleId{ get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
