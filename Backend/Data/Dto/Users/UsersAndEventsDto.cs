using System.ComponentModel.DataAnnotations.Schema;
using Hackaton_DW_2024.Data.Dto.Events;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto.Users;

[Table("users_and_events")]
public class UsersAndEventsDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("user_id")] 
    public int UserId { get; set; }
    public UserDto User { get; set; }
    
    [Column("event_id")]
    public int EventId { get; set; }
    public EventDto Event { get; set; }
    
    
    static string _structureName = "users_and_events";
    public static string StructureName { get => _structureName;}
}