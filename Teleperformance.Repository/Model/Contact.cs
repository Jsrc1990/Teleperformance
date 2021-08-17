using System;
using System.Collections.Generic;

#nullable disable

namespace Teleperformance.Model
{
    public partial class Contact
    {
        public Contact()
        {
            Users = new HashSet<User>();
        }

        public string Id { get; set; }
        public string ViaId { get; set; }
        public string Nro1 { get; set; }
        public string Letra1 { get; set; }
        public string Nro2 { get; set; }
        public string Letra2 { get; set; }
        public string NroyComplementos { get; set; }
        public string MunicipioId { get; set; }
        public string Telefono1 { get; set; }

        public virtual Municipio Municipio { get; set; }
        public virtual Vium Via { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
