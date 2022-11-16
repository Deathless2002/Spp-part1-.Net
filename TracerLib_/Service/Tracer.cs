using Spp1._0.InfoModel;
using Spp1._0.Interface;
using System.Diagnostics;

namespace TracerLib.Service
{
    public class Tracer : ITracer
    {
        private readonly ITracerService tracerService;
        private readonly ITrackService trackService;
        public Tracer(ITracerService _tracerService, ITrackService _trackService)
        {
            tracerService = _tracerService;
            trackService = _trackService;
        }

        public void StartTrace()
        {
            StackTrace _stackTrace = new StackTrace();
            var sf = _stackTrace.GetFrame(1);

            var method = sf?.GetMethod();
            var mInfo = new MethodInfoModel(method.Name, method.DeclaringType.Name);

            tracerService.AddMethodToTree(mInfo);

            trackService.Start(mInfo.Id);
        }

        public void StopTrace()
        {
            var method = tracerService.GetCurrentMethod();
            var time = trackService.Stop(method.Id);
            tracerService.AscendTree(time);
        }

        public TraceResult GetTraceResult()
        {
            return tracerService.GetResult();
        }
    }
}
