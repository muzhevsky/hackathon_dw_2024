using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Users;

[Table("teachers")]
public class EfTeacherDto
{
    [Column("id")] public int Id { get; set; }
    [Column("user_id")] public int UserId { get; set; }
    [Column("department_id")] public int DepartmentId { get; set; }
    
    public EfUserDto User { get; set; }
}