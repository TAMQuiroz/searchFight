using System;

namespace searchfight
{
    class Result
    {
        private string EngineName;
        private long ResultNumber;
        private string ArgumentName;

        public Result(int v = -1)
        {
            this.ResultNumber = v;
        }

        public string GetEngineName()
        {
            return EngineName;
        }

        public void SetEngineName(string value)
        {
            EngineName = value;
        }

        public long GetResultNumber()
        {
            return ResultNumber;
        }

        public void SetResultNumber(long value)
        {
            ResultNumber = value;
        }

        public string GetArgumentName()
        {
            return ArgumentName;
        }

        public void SetArgumentName(string value)
        {
            ArgumentName = value;
        }
    }
}
