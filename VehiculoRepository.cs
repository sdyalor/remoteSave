using Microsoft.EntityFrameworkCore;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;
using webapi4.Models;

namespace webapi4
{  
    public class VehiculoRepository : IVehiculoRepository
    {  
        private readonly NeumaticosContext _context;  
        public VehiculoRepository(NeumaticosContext context)  
        {  
            _context = context;  
        }  
  
        public Task<List<SnVehiculo>> GetVehiculos()  
        {  
            return _context.SnVehiculo.ToListAsync();  
        }  
    }  
}