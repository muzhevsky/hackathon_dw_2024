using Hackaton_DW_2024.Internal.Entities;

namespace Hackaton_DW_2024.Api.Auth;

public class StudentBasicDataResponse
{
    public int Id { get; set; }
    public string StudentId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? Telegram { get; set; }
    public string? PhoneNumber { get; set; }
    public int GroupId { get; set; }
}