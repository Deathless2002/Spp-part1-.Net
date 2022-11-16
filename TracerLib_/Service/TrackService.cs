using Spp1._0.Interface;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace TracerLib.Service
{
    public class TrackService : ITrackService
    {
        private readonly ConcurrentDictionary<Guid, Stopwatch> _stopwatches
             = new();

        public long Stop(Guid id)
        {
            if (_stopwatches.ContainsKey(id))
            {
                var stopwatch = _stopwatches[id];

                if (stopwatch.IsRunning)
                {
                    stopwatch.Stop();
                    return stopwatch.ElapsedMilliseconds;
                }
            }
            return -1;
        }

        public bool Start(Guid id)
        {
            bool result = _stopwatches.TryAdd(id, new Stopwatch());
            if (result)
            {
                _stopwatches[id].Start();
            }
            return result;
        }        
    }
}
