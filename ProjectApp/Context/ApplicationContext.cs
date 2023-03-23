using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.Context
{
    /**
     * Singleton application context
     */
    class ApplicationContext
    {
        private static ApplicationContext? Instance;

        public static ApplicationContext GetContext()
        {
            Instance ??= new ApplicationContext();

            return Instance;
        }

        private ApplicationContext() { 
        }

        public SessionContext? Session { get; set; }

        public bool IsAuthenticated() {
            if (Session != null) { 
                if(Session.IsValid()) return true;
            }
            return false;
        }

    }
}
