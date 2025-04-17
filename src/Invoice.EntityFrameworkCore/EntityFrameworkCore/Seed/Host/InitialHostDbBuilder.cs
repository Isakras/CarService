namespace Invoice.EntityFrameworkCore.Seed.Host;

public class InitialHostDbBuilder
{
    private readonly InvoiceDbContext _context;

    public InitialHostDbBuilder(InvoiceDbContext context)
    {
        _context = context;
    }

    public void Create()
    {
        new DefaultEditionCreator(_context).Create();
        new DefaultLanguagesCreator(_context).Create();
        new HostRoleAndUserCreator(_context).Create();
        new DefaultSettingsCreator(_context).Create();

        _context.SaveChanges();
    }
}
