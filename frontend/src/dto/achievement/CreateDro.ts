export interface AchievementCreateDto{
    EventId?: number | string;
    StatusId?: number | string;
    TeamSize?: number;
    File?: string | File;
}