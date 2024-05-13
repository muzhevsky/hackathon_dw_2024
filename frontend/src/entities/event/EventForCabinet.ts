export interface EventForCabinet{
    type: "event";
    id: number | string;
    title: string;
    startDate: Date;
    endDate: Date;
    statusId: number | string;
    description: string;
}