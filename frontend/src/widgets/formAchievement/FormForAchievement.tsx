import { Input } from "antd";
import { observer } from "mobx-react-lite";
import { useContext, useState } from "react";
import { Context } from "../..";
import { FormAchievement } from "../../entities/achievement/FormAchievement";
import { Event } from "../../entities/event/Event";
import { ItemsEventLevel, ItemsTypeEvent } from "../../entities/event/TypeEvent";
import useInput from "../../hooks/UseInput";
import PrimaryButton from "../../shared/ui/button/PrimaryButton";
import CustomizeSelect from "../../shared/ui/select/CustomizeSelect";
import styles from './FormForAchievement.module.css'

interface FormForAchievementProps{
    data: FormAchievement;
    closeHandler: () => void;
}

const FormForAchievement: React.FC<FormForAchievementProps> = observer(({ data, closeHandler }) => {
    const { userStore } = useContext(Context); 
    const { nameEvent, participant, dateEvent, place } = data;

    const nameEventState = useInput(nameEvent);
    const dateEventState = useInput(dateEvent);
    const placeState = useInput(place);
    const [eventLevelState, setEventLevelState] = useState<string>(ItemsEventLevel[0].value);
    const [typeEventState, setTypeEventState] = useState<string>(ItemsTypeEvent[0].value);

    const clickHandler = () => {
        const form: Event = {
            title: nameEventState.value,
            userId: userStore.user?.id ?? 1,
            dateStart: dateEventState.value,
            dateEnd: dateEventState.value,
            eventStatus: eventLevelState,
            countEvent: typeEventState,
            place: placeState.value
        }
        console.log(form);
        closeHandler();
    }

    return (
        <div>
            <div>
                <p>Наименование мероприятия</p>
                <Input placeholder="Наименование мероприятия" value={nameEvent} onChange={nameEventState.onChange}/>
            </div>

            <div>
                <p>Дата проведения</p>
                <Input placeholder="Дата проведения" value={dateEvent} onChange={dateEventState.onChange}/>
            </div>

            <div>
                <p>Уровень мероприятия</p>
                <CustomizeSelect items={ItemsEventLevel} handleChange={(value: string) => {setEventLevelState(value)}} />
            </div>

            <div>
                <p>Личное/командное мероприятие</p>
                <CustomizeSelect items={ItemsTypeEvent} handleChange={(value: string) => {setTypeEventState(value)}} />
            </div>

            <div>
                <p>Статус участия/результат</p>
                <Input placeholder="Личное/командное мероприятие" value={place} onChange={placeState.onChange}/>
            </div>
            <div className={styles.buttonPos}>
                <PrimaryButton content={"Всё верно. Отправить"} clickHandler={clickHandler} size={"large"}/>
            </div>

        </div>
    )
})

export default FormForAchievement;