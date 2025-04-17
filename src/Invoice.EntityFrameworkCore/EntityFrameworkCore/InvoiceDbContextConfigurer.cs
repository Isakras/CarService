using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Invoice.EntityFrameworkCore;

public static class InvoiceDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<InvoiceDbContext> builder, string connectionString)
    {
        builder.UseNpgsql(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<InvoiceDbContext> builder, DbConnection connection)
    {
        builder.UseNpgsql(connection);
    }
}
