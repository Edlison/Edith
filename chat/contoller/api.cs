using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edith.chat.contoller
{

    [XmlRpcUrl("http://192.168.0.101:50051")]
    public interface ProxyInterface : IXmlRpcProxy
    {
        [XmlRpcMethod("SayHello")]
        String sayHello();
    }
}
