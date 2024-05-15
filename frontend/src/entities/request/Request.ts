import { Group } from "../group/Group";

export interface Request{
    type: "request";
    id: number | string;
    eventId: number | string;
    courses?: number[];
    groups?: Group[];
    firstPlace?: string;
    secondPlace?: string;
    thirdPlace?: string;
    participation?: string;
    additionalRequirements: string;
}

export interface Quest{
    type: "quest";
    id?: number;
    teacherId?: number;
    eventId?: number;
    resultId?: number;
    groupId?: number;
    description?: string | null;
}
