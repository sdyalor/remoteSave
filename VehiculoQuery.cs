using GraphQL.Types;  
  
namespace webapi4
{  
    public class VehiculoQuery : ObjectGraphType  
    {  
        public VehiculoQuery(IVehiculoRepository vehiculoRepository)  
        {  
            Field<ListGraphType<VehiculoType>>(  
                "vehiculo",  
                resolve: context => vehiculoRepository.GetVehiculos()  
                );  
        }  
    }  
}  
