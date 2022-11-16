using System.Text.Json.Serialization;

namespace Spp1._0.InfoModel
{
    public class MethodInfoTreeModel
    {
        public MethodInfoTreeModel() { }

        public MethodInfoTreeModel(Guid id, string name, string className, long time)
        {
            Id = id;
            Name = name;
            ClassName = className;
            Time = time;
        }

        [JsonIgnore]
        public Guid Id { get; }

        [JsonPropertyName("name")]
        public string Name { get; }

        [JsonPropertyName("class")]
        public string ClassName { get; }

        [JsonPropertyName("time")]
        public long Time { get; }

        private IReadOnlyList<MethodInfoTreeModel> _methods;

        [JsonPropertyName("methods")]
        public IReadOnlyList<MethodInfoTreeModel> Methods
        {
            get
            {
                return _methods;
            }
            set
            {
                if (_methods == null)
                {
                    _methods = value;
                }
                else
                {
                    throw new Exception("Method value is already set");
                }
            }
        }
    }
}
