using Comixer.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Comixer.Tests.Mocks
{
    public class DbMock
    {
        public static ApplicationDbContext Instance
        {
            get
            {
                return new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase($"Comixer-{Guid.NewGuid()}")
                    .Options);
            }
        }
    }
}
