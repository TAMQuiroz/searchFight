using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight
{
    interface ISearchEngine
    {
        string Name { get; set; }
        long TotalResults { get; set; }

        void GenerateRequest(string searchArgument);
        
    }
}
