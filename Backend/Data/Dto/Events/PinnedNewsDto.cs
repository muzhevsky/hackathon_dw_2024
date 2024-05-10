using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto.Events;

[Table("pinned_news")]
[PrimaryKey("NewsId")]
public class PinnedNewsDto: Dto
{
    [Column("news_id")]
    public int NewsId { get; set; }
    
    static string _structureName = "pinned_news";
    public static string StructureName => _structureName;
}