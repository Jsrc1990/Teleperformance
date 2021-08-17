﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Teleperformance.Model
{
    public partial class Vium
    {
        public Vium()
        {
            Contacts = new HashSet<Contact>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
