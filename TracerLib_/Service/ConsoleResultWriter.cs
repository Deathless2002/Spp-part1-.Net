using Spp1._0.Interface;

namespace TracerLib.Service
{
    public class ConsoleResultWriter : IResultWriter
    {
        public void WriteResult(string result)
        {
            Console.WriteLine(result);
        }
    }
}
