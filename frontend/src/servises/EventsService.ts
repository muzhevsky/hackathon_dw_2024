import { Event } from "../entities/event/Event";
import { EventForCabinet } from "../entities/event/EventForCabinet";
import $api, { API_URL } from "../shared/utils/Api";

class EventsService{
    public static async getEvents(): Promise<EventForCabinet[]>{
        // return (await $api.get(`${API_URL}/events`)).data;
        return [
            {
                id: 1,
                title: "Event1",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                id: 2,
                title: "Event2",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                id: 3,
                title: "Event3",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                id: 4,
                title: "Event4",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            }
        ];
    }
}

export default EventsService;