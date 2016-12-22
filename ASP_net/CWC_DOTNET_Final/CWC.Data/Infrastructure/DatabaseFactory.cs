using Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private MyCWCContexte dataContext;
        public MyCWCContexte DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new MyCWCContexte();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }

}
