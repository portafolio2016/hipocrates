using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Cheekibreeki.CMH.Seguro.DAL;
namespace Cheekibreeki.CMH.Seguro.WS
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            SeguroEntities entitities = new SeguroEntities();
            AFILIADO afiliado = new AFILIADO();
            afiliado.RUT = 1238901283;
            return afiliado.RUT.ToString();
        }
    }
}