using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPagesServer
{
    internal class HelloService : Service
    {
        public HelloResponse Any()
        {
            return new HelloResponse { Result = "New message" };    
        }
    }
}
