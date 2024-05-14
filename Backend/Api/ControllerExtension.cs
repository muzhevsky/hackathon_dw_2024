using Hackaton_DW_2024.Api.Student;
using Hackaton_DW_2024.Data.Dto.Users;
using Hackaton_DW_2024.Internal.Entities;
using Hackaton_DW_2024.Internal.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hackaton_DW_2024.Api;

public static class ControllerExtension
{
    public static int? UserId(this ControllerBase controller)
    {
        var id = controller.User.Claims.FirstOrDefault(claim => claim.Type == "id");
        if (id == null) return null;
        return int.Parse(id.Value);
    }
}