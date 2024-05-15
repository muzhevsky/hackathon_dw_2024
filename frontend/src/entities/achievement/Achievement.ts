export interface Achievement{
    id: number | string;
    score: number | string;
    withTeam: boolean;
    userId: number | string;
    filePath: string;
    resultId: number;
}

export interface AchConnected{
    id: number;
    eventId: number;
    resultId: number;
    withTeam: boolean;
}

export interface AchCustom{
    id: number;
    title: string;
    date: string;
    statusId: number;
    resultId: number;
    withTeam: boolean;
}