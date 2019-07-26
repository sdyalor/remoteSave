using System;
using System.Collections.Generic;

namespace webapi4.Models
{
    public partial class SnCiaNeumatico
    {
        public SnCiaNeumatico()
        {
            SnConfiguracion = new HashSet<SnConfiguracion>();
            SnModeloVehiculo = new HashSet<SnModeloVehiculo>();
            SnObraNeumatico = new HashSet<SnObraNeumatico>();
            SnTipoVehiculo = new HashSet<SnTipoVehiculo>();
            SnVehiculo = new HashSet<SnVehiculo>();
        }

        public string CodCia { get; set; }
        public string Descripcion { get; set; }
        public string Notas { get; set; }
        public string Breve { get; set; }
        public int Orden { get; set; }
        public string Estado { get; set; }
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }

        public virtual ICollection<SnConfiguracion> SnConfiguracion { get; set; }
        public virtual ICollection<SnModeloVehiculo> SnModeloVehiculo { get; set; }
        public virtual ICollection<SnObraNeumatico> SnObraNeumatico { get; set; }
        public virtual ICollection<SnTipoVehiculo> SnTipoVehiculo { get; set; }
        public virtual ICollection<SnVehiculo> SnVehiculo { get; set; }
    }
}
