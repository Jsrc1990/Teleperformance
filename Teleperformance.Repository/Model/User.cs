using System;
using System.Collections.Generic;

#nullable disable

namespace Teleperformance.Model
{
    public partial class User
    {
        public string Id { get; set; }
        public string IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Email { get; set; }

        public virtual IdentificationType IdentificationType { get; set; }
    }
}
