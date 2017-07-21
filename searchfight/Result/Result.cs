using System;

namespace searchfight
{
    class Result
    {
        private string engineName;
        private long resultNumber;
        private string argumentName;

        public Result(int v = -1)
        {
            this.resultNumber = v;
        }

        public string EngineName { get => engineName; set => engineName = value; }
        public long ResultNumber { get => resultNumber; set => resultNumber = value; }
        public string ArgumentName { get => argumentName; set => argumentName = value; }
    }
}
