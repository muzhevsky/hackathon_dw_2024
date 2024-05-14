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
                content: "orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
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