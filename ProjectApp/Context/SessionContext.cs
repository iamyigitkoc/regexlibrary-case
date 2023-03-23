using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectApp.Context
{
    class SessionContext
    {
        public string? Bearer { get; set; }

        public DateTime? Expires { get; set; }

        public int? UserId { get; set; }

        public string? UserName { get; set;}

        public bool IsValid() {
            if (!string.IsNullOrEmpty(Bearer) && UserId != null)
            {
                DateTime now = DateTime.Now;
                if (Expires != null)
                {
                    if (Expires > now)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
