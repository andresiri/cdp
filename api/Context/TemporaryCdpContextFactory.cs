using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MySQL.Data.Entity.Extensions;

namespace api.Context
{
    public class TemporaryCdpContextFactory : IDbContextFactory<CdpContext>
    {
        public CdpContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<CdpContext>();
            builder.UseMySQL("User ID=root;Password=andresiri;Server=127.0.0.1;Database=cdp;");
            return new CdpContext(builder.Options, new HttpContextAccessor());
        }
    }
}