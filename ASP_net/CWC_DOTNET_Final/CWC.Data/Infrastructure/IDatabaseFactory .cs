using Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Infrastructure

{
    public interface IDatabaseFactory : IDisposable
    {
        MyCWCContexte DataContext { get; }
    }

}
