using System;
using System.Collections.Generic;

#nullable disable

namespace Teleperformance.Model
{
    public partial class Municipio
    {
        public Municipio()
        {
            Contacts = new HashSet<Contact>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
