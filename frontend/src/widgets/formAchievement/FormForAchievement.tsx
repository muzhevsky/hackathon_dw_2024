import { AutoComplete, Input } from "antd";
import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import { AchConnected, AchCustom } from "../../entities/achievement/Achievement";
import { DataAchievementFromBack, FormAchievement } from "../../entities/achievement/FormAchievement";
import { Event } from "../../entities/event/Event";
import { EventForCabinet } from "../../entities/event/EventForCabinet";
import { EventResult } from "../../entities/event/EventResult";
import { ItemsEventLevel, ItemsTypeEvent } from "../../entities/event/TypeEvent";
import useInput from "../../hooks/UseInput";
import AchievementService from "../../servises/AchievementService";
import EventsService from "../../servises/EventsService";
import AutoCompleteInput from "../../shared/ui/autoComplete/AutoCompleteInput";
import PrimaryButton from "../../shared/ui/button/PrimaryButton";
import CustomizeSelect from "../../shared/ui/select/CustomizeSelect";
import styles from './FormForAchievement.module.css'

interface FormForAchievementProps{
    data: DataAchievementFromBack;
    closeHandler: () => void;
}

const FormForAchievement: React.FC<FormForAchievementProps> = observer(({ data, closeHandler }) => {
    const { userStore, achievementsRepository } = useContext(Context); 
    const { date, id, result, status, title } = data;

    const [nameEventState, setNameEventState] = useState<string>(title);
    const dateEventState = useInput(date);
    const placeState = useInput(result);
    const [eventLevelState, setEventLevelState] = useState<string>(ItemsEventLevel[0].value);
    const [typeEventState, setTypeEventState] = useState<string>(ItemsTypeEvent[0].value);
    const [event, setEvent] = useState<EventForCabinet | null>(null);
    const [events, setEvents] = useState<EventForCabinet[]>([]);

    const translate = (result: string, itemResult: EventResult[]) => {
        if(result.toLocaleLowerCase() === "1 место" || result.toLocaleLowerCase() === "победитель") return itemResult[0];
        if(result.toLocaleLowerCase() === "2 место" || result.toLocaleLowerCase() === "призер" || result.toLocaleLowerCase() === "3 место") return itemResult[1];
        return itemResult[2];
    }

    const clickHandler = async() => {
        const resultItems: EventResult[] = await EventsService.getEventResults();
        if(event){
            const dto: AchConnected = {
                id: Number(id),
                eventId: Number(event.id),
                resultId: translate(placeState.value, resultItems).id,
                withTeam: typeEventState.toLowerCase() === "командное" ? true : false
            }

            const response = await AchievementService.connect(dto);
            console.log(response);
        }
        else{
            const dto: AchCustom = {
                id: Number(id),
                title: nameEventState,
                date: dateEventState.value,
                statusId: Number(eventLevelState),
                resultId: translate(placeState.value, resultItems).id,
                withTeam: typeEventState.toLowerCase() === "командное" ? true : false
            }

            const response = await AchievementService.custom(dto);
            console.log(response);
        }
        achievementsRepository.getAchievements();
        // const form: Event = {
        //     title: nameEventState,
        //     userId: userStore.user?.id ?? 1,
        //     dateStart: dateEventState.value,
        //     dateEnd: dateEventState.value,
        //     eventStatus: eventLevelState,
        //     countEvent: typeEventState,
        //     place: placeState.value
        // }
        // console.log(form);

        // console.log(event);
        closeHandler();
    }

    const onSelectHandler = (str?: EventForCabinet) => {
        setEvent(str ?? null);
    }

    const changeNameEvent = (str: string) => {
        console.warn("hello");
        setNameEventState(str);
    }

    useEffect(() => {
        const response = EventsService.getEvents();
        response.then(response => {
            setEvents(response);
        })
    }, [])

    return (
        <div>
            <div>
                <p>Наименование мероприятия</p>
                <AutoCompleteInput 
                    items={events}
                    onSelectHandler={onSelectHandler}
                    placeholder={"Наименование мероприятия"}
                    defaultValue={nameEventState} 
                    changeHandler={changeNameEvent}/>
            </div>

            <div>
                <p>Дата проведения</p>
                <Input placeholder="Дата проведения" defaultValue={date} onChange={dateEventState.onChange}/>
            </div>

            <div>
                <p>Уровень мероприятия</p>
                <CustomizeSelect defaultValue={status} items={ItemsEventLevel} handleChange={(value: string) => {setEventLevelState(value)}} />
            </div>

            <div>
                <p>Личное/командное мероприятие</p>
                <CustomizeSelect items={ItemsTypeEvent} handleChange={(value: string) => {setTypeEventState(value)}} />
            </div>

            <div>
                <p>Статус участия/результат</p>
                <Input placeholder="Личное/командное мероприятие" defaultValue={result} onChange={placeState.onChange}/>
            </div>
            <div className={styles.buttonPos}>
                <PrimaryButton content={"Всё верно. Отправить"} clickHandler={clickHandler} size={"large"}/>
            </div>

        </div>
    )
})

export default FormForAchievement;