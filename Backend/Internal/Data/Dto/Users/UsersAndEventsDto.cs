using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Internal.Data.Dto.Users;

[Table("users_and_events")]
[Keyless]
public class UsersAndEventsDto: Dto
{
    [Column("user_id")] 
    public int UserId { get; set; }
    
    [Column("event_id")]
    public int EventId { get; set; }

    static string _structureName = "users_and_events";
    public static string StructureName { get => _structureName;}
}