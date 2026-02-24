using WebApplication_api.Services.Interface;

namespace WebApplication_api.Services.Services
{
    public class TransientGUIService : ITransientGUI
    {
        public Guid transientGUID;

        public TransientGUIService()
        {
            transientGUID = Guid.NewGuid(); 
        }
        public Guid GetGuid()
        {
            return transientGUID;
        }

    }

}
