using Microsoft.AspNetCore.Authorization;

namespace StoreProjectSystem_BackEnd.Authorization
{
    public class Employee : IAuthorizationRequirement
    {
        public Employee(bool hired) 
        {
            Hired = hired;
        }
        public bool Hired { get; set; }
    }
}
