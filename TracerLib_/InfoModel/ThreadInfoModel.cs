using System.Text.Json.Serialization;

namespace Spp1._0.InfoModel
{
    public class ThreadInfoModel
    {
        public ThreadInfoModel() { }
        public ThreadInfoModel(int threadId, long executionTime, IReadOnlyList<MethodInfoTreeModel> methods)
        {
            ThreadId = threadId;
            ExecutionTime = executionTime;
            Methods = methods;
        }

        [JsonPropertyName("id")]
        public int ThreadId { get; }

        [JsonPropertyName("time")]
        public long ExecutionTime { get; }

        [JsonPropertyName("methods")]
        public IReadOnlyList<MethodInfoTreeModel> Methods { get; }
    }
}
