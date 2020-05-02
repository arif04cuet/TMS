using System;

namespace Module.Core.Shared
{
    public class BarcodeService : IBarcodeService
    {

        public BarcodeService()
        {
            //
        }

        public string Generate()
        {
            return DateTime.Now.Ticks.ToString();
        }
    }
}
