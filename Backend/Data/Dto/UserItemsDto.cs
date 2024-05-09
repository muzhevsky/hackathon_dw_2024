using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto;

[Table("user_items")]
[Keyless]
public class UserItemsDto
{
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("item_id")]
    public int ItemId { get; set; }
    
    [Column("count")]
    public int Count { get; set; }
}