using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Events;

[Table("news")]
public class NewsDto: Dto
{
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [MaxLength(256)]
    public string Title { get; set; }
    
    [Column("content")]
    public string Content { get; set; }
    
    [Column("publication_date")]
    public DateTime PublicationDate { get; set; }

    public List<EventDto> Events { get; set; } = [];
    public List<NewsAndEventsDto> NewsAndEvents { get; set; } = [];
    
    static string _structureName = "news";
    public static string StructureName => _structureName;
}