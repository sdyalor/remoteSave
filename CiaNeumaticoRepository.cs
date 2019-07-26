using Microsoft.EntityFrameworkCore;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;
using webapi4.Models;

namespace webapi4
{  
    public class CiaNeumaticoRepository : ICiaNeumaticoRepository
    {  
        private readonly NeumaticosContext _context;  
        public CiaNeumaticoRepository(NeumaticosContext context)  
        {  
            _context = context;  
        }  
  
        public Task<List<SnCiaNeumatico>> GetVehiculos()  
        {  
            return _context.SnCiaNeumatico.ToListAsync();  
        }  
    }  
}