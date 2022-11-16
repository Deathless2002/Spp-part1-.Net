using Spp1._0.InfoModel;
using System.Text.Json;
using TracerLib.Interface;

namespace TracerLib.Serializers
{
    public class JsonSerializerService : ISerializer
    {
        public string Serialize(TraceResult result)
        {
            JsonSerializerOptions jso = new()
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(result, jso);
        }
    }
}
