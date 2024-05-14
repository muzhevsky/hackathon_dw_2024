import { Event } from "../entities/event/Event";
import { EventForCabinet } from "../entities/event/EventForCabinet";
import { EventResult } from "../entities/event/EventResult";
import { EventStatus } from "../entities/event/EventStatus";
import { testGroup } from "../entities/group/Group";
import { New } from "../entities/new/New";
import { Request } from "../entities/request/Request";
import $api, { API_URL } from "../shared/utils/Api";

class EventsService{
    public static async getEvents(): Promise<EventForCabinet[]>{
        return (await $api.get(`${API_URL}/events`)).data;
    }

    public static async getMyEvents(): Promise<EventForCabinet[]>{
        return (await $api.get(`${API_URL}/myEvents`)).data;
    }

    public static async getEventStatuses(): Promise<EventStatus[]>{
        return (await $api.get(`${API_URL}/event_statuses`)).data;
    }

    public static async getEventResults(): Promise<EventResult[]>{
        return (await $api.get(`${API_URL}/event_results`)).data;
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
                content: "orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                imageUrl:'../shared/assets/news/hakaton.jpg'
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

    public static async getNews(): Promise<(EventForCabinet | New | Request)[]>{
        return [
            {
                type: "new",
                id: 1,
                title: "Хакатон по веб-разработке!",
                publicationDate: new Date(),
                content: "Хакатон проводится  в рамках Международного конкурса компьютерных работ среди детей, юношества и студенческой молодежи «Цифровой ветер».\n" +
                    "\n" +
                    "Принять участие могут команды в составе до 4-х человек.\n" +
                    "\n" +
                    "Сроки проведения: 13-15 мая 2024 года.\n" +
                    "\n" +
                    "Место проведения: г. Саратов, ул. Политехническая, 122, СГТУ имени Гагарина Ю.А.\n" +
                    "\n" +
                    "Регистрация до 7 мая.",
                imageUrl:'hakaton.jpg'
            },
            {
                type: "new",
                id: 2,
                title: "Итоги «Первый полет».",
                publicationDate: new Date(),
                content: "Чемпионат организовали Движение Первых и  СГТУ имени Гагарина Ю.А., Институт прикладных информационных технологий и коммуникаций.\n" +
                    "\n" +
                "Участниками стали более 1800 студентов и школьников со всей Саратовской области.  Для ребят было организовано обучение  сборке и пилотированию БПЛА, открыт доступ к политеховскому онлайн-курсу «Беспилотные летательные аппараты».\n" +
                    "\n" + "3 мая в Политехе соревновались 150 финалистов, прошедших отборочные туры. Юные инженеры продемонстрировали свои знания в сборке и конструировании дронов, пилоты - в пилотировании на симуляторах и в прохождении реальной трассы.\n" +
                    "\n" +

            "В перерывах между соревнованиями финалисты посетили  медиацентр «Сделано в СГТУ» и лабораторию виртуальной и дополненной реальности ИнПИТ, а также познакомились с технологиями VR на площадке, организованной парком The Deep VR в Саратове.",
                imageUrl:'win.jpg'
            },
            {
                type: "new",
                id: 1,
                title: "\n" +
                    "Победа в международном чемпионате «Cyber Trajectory»! ",
                publicationDate: new Date(),
                content: "Хакатон проводится  в рамках Международного конкурса компьютерных работ среди детей, юношества и студенческой молодежи «Цифровой ветер».\n" +
                    "\n" +
                    "Принять участие могут команды в составе до 4-х человек.\n" +
                    "\n" +
                    "Сроки проведения: 13-15 мая 2024 года.\n" +
                    "\n" +
                    "Место проведения: г. Саратов, ул. Политехническая, 122, СГТУ имени Гагарина Ю.А.\n" +
                    "\n" +
                    "Регистрация до 7 мая.",
                imageUrl:'dota.jpg'
            },
            {
                type: "new",
                id: 1,
                title: "\n" +
                    "Начинается ночь - просыпаются кодеры",
                publicationDate: new Date(),
                content: "Начинается ночь - просыпаются кодеры.\n" +
                    "\n" +

                "А в ночной дозор заступает специалист ИнПИТ по работе с молодежью Заид Дадашев.",
                imageUrl:'wind.jpg'
            },
            {
                type: "new",
                id: 4,
                title: "\n" +
                    "\n" +
                    "Первое заседание Молодёжного Правительства",
                publicationDate: new Date(),
                content: "Напомним,молодежным министром труда и социальной защиты Саратовской области Молодежного Правительства Саратовской области VI созыва была избрана Анастасия Щукина — председатель профбюро ФТИ.\n" +
                    "\n" +

                "Были подведены итоги двухлетней работы Молодежного Правительства Саратовской области V созыва и определили задачи и цели для нового состава.\n" +
                    "\n" +

                "Так же молодежным министрам были вручены удостоверения. И срок исполнения их обязанностей установлен на два года.",
                imageUrl:'cs.jpg'
            },
            {
                type: "event",
                id: 5,
                title: "Event4",
                startDate: new Date(),
                endDate: new Date(),
                statusId: "Международный",
                description: "Какое-то описание..."
            }
        ]
    }
}

export default EventsService;