using WebApplication_api.Services.Interface;

namespace WebApplication_api.Services.Services
{
    public class ScopedGUIService : IScopedGUI
    {
        public Guid scopedGUID { get; }

        public ScopedGUIService()
        {
            scopedGUID = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return scopedGUID; 
        }

    }

}
