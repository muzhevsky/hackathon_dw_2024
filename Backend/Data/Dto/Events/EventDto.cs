﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hackaton_DW_2024.Data.Dto.Achievements;
using Hackaton_DW_2024.Data.Dto.Users;

namespace Hackaton_DW_2024.Data.Dto.Events;

[Table("events")]
public class EventDto: Dto
{
    [Column("id")] 
    public int Id { get; set; }
    
    [Column("title")]
    [MaxLength(256)]
    public string Title { get; set; }
    
    [Column("start_date")]
    public DateTime StartDate { get; set; }
    
    [Column("end_date")]
    public DateTime EndDate { get; set; }
    
    [Column("status_id")]
    public int StatusId { get; set; }
    public EventStatusDto Status { get; set; }
    
    [Column("description")]
    public string Description { get; set; }


    public List<UserDto> Users { get; set; } = [];
    public List<UsersAndEventsDto> UsersAndEvents { get; set; } = [];
    public List<NewsDto> News { get; set; } = [];
    public List<NewsAndEventsDto> NewsAndEvents { get; set; } = [];
    public List<AchievementDto> Achievements { get; set; } = [];
    public List<AchievementsAndEventsDto> AchievementsAndEvents { get; set; } = [];

    static string _structureName = "events";
    public static string StructureName => _structureName;
}