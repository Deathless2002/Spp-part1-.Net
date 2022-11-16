using System.Text.Json.Serialization;

namespace Spp1._0.InfoModel
{
    public class TraceResult
    {
        public TraceResult(List<ThreadInfoModel> threads)
        {
            Threads = threads;
        }

        [JsonPropertyName("threads")]
        public List<ThreadInfoModel> Threads { get; }
    }
}
