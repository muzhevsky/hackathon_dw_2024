﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Hackaton_DW_2024.Data.Dto.Achievements;

[Table("requests")]
public class RequestDto: Dto
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("user_id")]
    public int UserId { get; set; }
    
    [Column("confirmed")]
    public bool Confirmed { get; set; }
    
    [Column("file_path")]
    public string? FilePath { get; set; }
    
    
    static string _structureName = "requests";
    public static string StructureName => _structureName;
}