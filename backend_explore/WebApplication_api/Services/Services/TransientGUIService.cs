using WebApplication_api.Services.Interface;

namespace WebApplication_api.Services.Services
{
    public class TransientGUIService : ITransientGUI
    {
        public Guid transientGUID { get; }

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
