using GraphQL;  
using GraphQL.Types;  
  
namespace webapi4
{  
    public class VehiculosSchema : Schema  
    {  
        public VehiculosSchema(IDependencyResolver resolver) : base(resolver)  
        {  
            Query = resolver.Resolve<VehiculoQuery>();  
        }  
    }  
}  
