using System;

namespace DocumentGenerator.Api.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }

        
    }
}
