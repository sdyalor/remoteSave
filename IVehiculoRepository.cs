using System.Collections.Generic;  
using System.Threading.Tasks;
using webapi4.Models;

namespace webapi4
{  
    public interface IVehiculoRepository  
    {  
        Task<List<SnVehiculo>> GetVehiculos();  
    }  
}