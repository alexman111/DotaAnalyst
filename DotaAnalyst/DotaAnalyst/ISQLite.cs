using System;
using System.Collections.Generic;
using System.Text;

namespace DotaAnalyst
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
