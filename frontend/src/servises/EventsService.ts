import { Event } from "../entities/event/Event";
import { EventForCabinet } from "../entities/event/EventForCabinet";
import { testGroup } from "../entities/group/Group";
import { New } from "../entities/new/New";
import { Request } from "../entities/request/Request";
import $api, { API_URL } from "../shared/utils/Api";

class EventsService{
    public static async getEvents(): Promise<EventForCabinet[]>{
        // return (await $api.get(`${API_URL}/events`)).data;
        return [
            {
                type: "event",
                id: 1,
                title: "Event1",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                type: "event",
                id: 2,
                title: "Event2",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                type: "event",
                id: 3,
                title: "Event3",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                type: "event",
                id: 4,
                title: "Event4",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            }
        ];
    }

    public static async getAllEvents(): Promise<(EventForCabinet | New | Request)[]>{
        // return (await $api.get(`${API_URL}/events`)).data;
        return [
            {
                type: "event",
                id: 1,
                title: "Event1",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                type: "new",
                id: 2,
                title: "Новость 1",
                publicationDate: new Date(),
                content: "Какая-то информация"
            },
            {
                type: "event",
                id: 3,
                title: "Event2",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                type: "event",
                id: 4,
                title: "Event3",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                type: "event",
                id: 5,
                title: "Event4",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            },
            {
                type: "request",
                id: 6,
                eventId: 1,
                groups: [testGroup],
                firstPlace: "ничего",
                secondPlace: "ничего 2",
                thirdPlace: "ничего 3",
                participation: "совсем нечего",
                additionalRequirements: "2 часа ночи"
            }
        ];
    }
}

export default EventsService;