using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Int64 DOB { get; set; }
        public string Address { get; set; }
    }
}
