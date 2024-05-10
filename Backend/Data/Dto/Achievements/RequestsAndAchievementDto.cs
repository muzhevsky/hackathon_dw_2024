﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hackaton_DW_2024.Data.Dto.Achievements;

[Table("requests_and_achievements")]
[Keyless]
public class RequestsAndAchievementDto: Dto
{
    [Column("request_id")]
    public int RequestId { get; set; }
    
    [Column("achievement_id")]
    public int AchievementId { get; set; }
}