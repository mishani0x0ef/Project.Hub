using Microsoft.EntityFrameworkCore;

namespace Project.Hub.Data.Contexts
{
    /// <summary>
    /// Represent context of the Hub internal database.
    /// </summary>
    public class HubContext : DbContext
    {
        /// <summary>
        /// Create new instance of the context.
        /// </summary>
        public HubContext(DbContextOptions<HubContext> options) : base(options)
        {
        }
    }
}
