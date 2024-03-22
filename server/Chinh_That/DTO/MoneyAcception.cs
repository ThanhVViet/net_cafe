using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinh_That.DTO
{
    public delegate void MoneyAcception(Naptien nt);
    public class Naptien : EventArgs
    {
        public string money { get; set; }
    }
}
