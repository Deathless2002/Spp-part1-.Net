using Spp1._0.InfoModel;

namespace Spp1._0.Interface
{
    public interface ITracer
    {
        void StartTrace();
        void StopTrace();

        TraceResult GetTraceResult();
    }
}
