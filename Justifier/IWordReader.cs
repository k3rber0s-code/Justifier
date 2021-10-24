using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Justifier
{
    interface IWordReader
    {
        string ReadWord(char[] delimiters);
    }
}
