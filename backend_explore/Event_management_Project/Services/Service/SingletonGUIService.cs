using WebApplication_api.Services.Interface;

namespace WebApplication_api.Services.Service
{
    public class SingletonGUIService : ISingletonGUI
    {
        public Guid singletonGUID { get; }

        public SingletonGUIService()
        {
            singletonGUID = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return singletonGUID;
        }

    }

}
