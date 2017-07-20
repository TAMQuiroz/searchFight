namespace searchfight
{
    class Result
    {
        public Result(int v = -1)
        {
            this.ResultNumber = v;
        }

        private string EngineName;
        private int ResultNumber;
        private string ArgumentName;

        public string GetEngineName()
        {
            return EngineName;
        }

        public void SetEngineName(string value)
        {
            EngineName = value;
        }

        public int GetResultNumber()
        {
            return ResultNumber;
        }

        public void SetResultNumber(int value)
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
