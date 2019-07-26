using GraphQL.Types;
using webapi4.Models;

namespace webapi4  
{  
    public class VehiculoType : ObjectGraphType<SnVehiculo>  
    {  
        public VehiculoType()  
        {  
            Field(a => a.CodCia);  
            Field(a => a.CodObra);  
            Field(a => a.CodVehiculo);  
            Field(a => a.Placa);  
            Field(a => a.Prefijo);
            Field(a => a.CodMarca);
            Field(a => a.CodCiaNavigation,false,typeof(CiaNeumaticoType)).Resolve(ResolveCodCiaNavigation);
        }
        private SnCiaNeumatico ResolveCodCiaNavigation(ResolveFieldContext<SnVehiculo> context)
        {
            var message = context.Source;
            return message.CodCiaNavigation;
        }

    }  
}  