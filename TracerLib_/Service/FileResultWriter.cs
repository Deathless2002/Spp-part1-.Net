using Spp1._0.Interface;

namespace TracerLib.Service
{
    public class FileResultWriter : IResultWriter
    {
        private string Path;
        public FileResultWriter(string _path) { Path = _path; }
        public void WriteResult(string result)
        {
            using (var fileStream = new FileStream(Path, FileMode.Create))
            {
                using var writer = new StreamWriter(fileStream);
                writer.Write(result);
            }
        }
    }
}
