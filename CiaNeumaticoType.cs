using GraphQL.Types;
using webapi4.Models;

namespace webapi4  
{  
    public class CiaNeumaticoType : ObjectGraphType<SnCiaNeumatico>  
    {  
        public CiaNeumaticoType()  
        {  
            Field(a => a.CodCia);  
            Field(a => a.Descripcion);  
            Field(a => a.Notas);  
            Field(a => a.Breve);  
            Field(a => a.Orden);
            Field(a => a.Estado);
        }  
    }  
}  