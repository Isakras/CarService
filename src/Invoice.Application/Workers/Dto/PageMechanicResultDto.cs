using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;

namespace Invoice.Workers.Dto
{
    public class PageMechanicResultDto : PagedResultRequestDto, IShouldNormalize
    {
        public string Keyword { get; set; }
        public string Sorting { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrWhiteSpace(Sorting))
            {
                Sorting = "FullName";
            }
            Keyword = Keyword?.Trim();
        }
    }
}