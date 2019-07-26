using System.Collections.Generic;  
using System.Threading.Tasks;
using webapi4.Models;

namespace webapi4
{  
    public interface ICiaNeumaticoRepository  
    {  
        Task<List<SnCiaNeumatico>> GetVehiculos();  
    }  
}