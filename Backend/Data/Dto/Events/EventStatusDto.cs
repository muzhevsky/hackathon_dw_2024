﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Events;

[Table("event_statuses")]
public class EventStatusDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("title")]
    [MaxLength(32)]
    public string Title { get; set; }
    
    [Column("score_percentage")]
    public int ScorePercentage { get; set; }
    
    static string _structureName = "event_statuses";
    public static string StructureName => _structureName;
}