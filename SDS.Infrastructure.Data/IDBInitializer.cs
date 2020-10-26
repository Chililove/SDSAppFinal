using System;
using System.Collections.Generic;
using System.Text;

namespace SDS.Infrastructure.Data
{
    public interface IDBInitializer
    {

        public void InitData(Context ctx);

    }
}
