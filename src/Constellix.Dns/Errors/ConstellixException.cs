using System;

namespace Constellix.Dns
{
    public class ConstellixException : Exception
    {
        private readonly ErrorResult result;

        public ConstellixException(ErrorResult result)
            : base(result.Errors[0])
        {
            this.result = result;
        }

        public string[] Errors => result.Errors;
    }
}

// {"errors":["Record not found"]}