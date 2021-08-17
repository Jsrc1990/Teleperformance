using System;
using System.Collections.Generic;

#nullable disable

namespace Teleperformance.Model
{
    public partial class Kind
    {
        public Kind()
        {
            Users = new HashSet<User>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
