namespace WebApplication_api.Services.Interface
{
    public interface IScopedGUI
    {
        public Guid scopedGUID { get; }
        public Guid GetGuid();
    }
}
