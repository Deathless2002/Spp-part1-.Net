using Spp1._0.InfoModel;

namespace TracerLib.Interface
{
    public interface ISerializer
    {
        public string Serialize(TraceResult result);
    }
}
