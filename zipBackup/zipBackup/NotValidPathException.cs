using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zipBackup
{
    public class NotValidPathException : Exception
    {
        public NotValidPathException(string message):base(message)
        {

        }
    }
}
