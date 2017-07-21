using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight.Engine
{
    class SearchEngineManager
    {
        private ArrayList engineList;

        public SearchEngineManager()
        {
            GoogleSearchEngine google = new GoogleSearchEngine();
            BingSearchEngine bing = new BingSearchEngine();
            this.engineList = new ArrayList { google, bing };
        }

        public ArrayList EngineList { get => engineList; set => engineList = value; }
    }
}
