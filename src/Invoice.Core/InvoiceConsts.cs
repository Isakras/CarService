using Invoice.Debugging;

namespace Invoice;

public class InvoiceConsts
{
    public const string LocalizationSourceName = "Invoice";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "d91101c882544484895f6e8c0742e4c9";
}
