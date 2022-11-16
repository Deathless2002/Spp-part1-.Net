namespace Spp1._0.InfoModel
{
    public class MethodInfoModel
    {
        public MethodInfoModel(string name, string className)
        {
            Name = name;
            ClassName = className;
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string ClassName { get; set; }
        public long Time { get; set; }
    }
}
