using CookComputing.XmlRpc;
using Edith.chat.contoller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Edith.chat
{
    class ChatController
    {
        public void test()
        {
            ProxyInterface proxy = (ProxyInterface)XmlRpcProxyGen.Create(typeof(ProxyInterface));

            MessageBox.Show(proxy.sayHello());
            Console.WriteLine(proxy.sayHello());
            Console.ReadLine();
        }
    }
}
