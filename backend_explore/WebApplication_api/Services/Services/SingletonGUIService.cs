using WebApplication_api.Services.Interface;

namespace WebApplication_api.Services.Services
{
    public class SingletonGUIService : ISingletonGUI
    {
        public Guid singletonGUI;

        public SingletonGUIService()
        {
            singletonGUI = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return singletonGUI;
        }

    }

}
