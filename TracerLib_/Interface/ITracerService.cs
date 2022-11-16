using Spp1._0.InfoModel;

namespace Spp1._0.Interface
{
    public interface ITracerService
    {
        TraceResult GetResult();        
        void AddMethodToTree(MethodInfoModel info);

        void AscendTree(long time);
        MethodInfoModel GetCurrentMethod();
    }
}
