using EF_CORE.DAY_1.DATA;
using Microsoft.EntityFrameworkCore;


namespace EF_CORE.DAY_1.Utils
{
    static  class HelperMethods
    {
        public static void DetachEntity<T>(T entity , AppDbContext _dbcontext)
        {
            if (entity!=null)
            {
                
                var entry = _dbcontext.Entry(entity);

                if (entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Detached;
                }
                
            }
        }
    }
}
