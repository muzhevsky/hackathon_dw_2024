using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Internal.Data.Dto.Customization;

[Table("user_items")]
[Keyless]
public class UserItemsDto: Dto
{
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("item_id")]
    public int ItemId { get; set; }
    
    [Column("count")]
    public int Count { get; set; }
    
    static string _structureName = "user_items";
    public static string StructureName => _structureName;
}