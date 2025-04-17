using Invoice.Roles.Dto;
using System.Collections.Generic;

namespace Invoice.Web.Models.Common;

public interface IPermissionsEditViewModel
{
    List<FlatPermissionDto> Permissions { get; set; }
}