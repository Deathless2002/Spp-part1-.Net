namespace Spp1._0.Interface
{
    public interface ITrackService
    {
        public bool Start(Guid id);
        public long Stop(Guid id);
    }
}
