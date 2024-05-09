using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto;

[Table("pinned_news")]
[PrimaryKey("NewsId")]
public class PinnedNewsDto
{
    [Column("news_id")]
    public int NewsId { get; set; }
}