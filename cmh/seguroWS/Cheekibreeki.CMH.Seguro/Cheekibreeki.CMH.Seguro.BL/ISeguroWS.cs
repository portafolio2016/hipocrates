using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace Cheekibreeki.CMH.Seguro.BL
{
    [ServiceContract]
    public interface ISeguroWS
    {
        [OperationContract]
        string helloWorld(string name);
        
    }
}
