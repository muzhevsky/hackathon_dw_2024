using System.ComponentModel.DataAnnotations.Schema;
using Hackaton_DW_2024.Data.Dto.Users.Hierarchy;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto.Users;

[Table("teachers")]
[Keyless]
public class TeacherDto
{
    [Column("user_id")] 
    public int UserId { get; set; }

    [Column("department_id")] 
    public int DepartmentId { get; set; }
    public DepartmentDto Department { get; set; }
}