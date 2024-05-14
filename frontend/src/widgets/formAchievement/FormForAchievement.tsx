import { Input } from "antd";
import { observer } from "mobx-react-lite";
import { useContext, useState } from "react";
import { Context } from "../..";
import { DataAchievementFromBack, FormAchievement } from "../../entities/achievement/FormAchievement";
import { Event } from "../../entities/event/Event";
import { ItemsEventLevel, ItemsTypeEvent } from "../../entities/event/TypeEvent";
import useInput from "../../hooks/UseInput";
import PrimaryButton from "../../shared/ui/button/PrimaryButton";
import CustomizeSelect from "../../shared/ui/select/CustomizeSelect";
import styles from './FormForAchievement.module.css'

interface FormForAchievementProps{
    data: DataAchievementFromBack;
    closeHandler: () => void;
}

const FormForAchievement: React.FC<FormForAchievementProps> = observer(({ data, closeHandler }) => {
    const { userStore } = useContext(Context); 
    const { date, id, result, status, title } = data;

    const nameEventState = useInput(title);
    const dateEventState = useInput(date);
    const placeState = useInput(result);
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
                <Input placeholder="Наименование мероприятия" value={title} onChange={nameEventState.onChange}/>
            </div>

            <div>
                <p>Дата проведения</p>
                <Input placeholder="Дата проведения" value={date} onChange={dateEventState.onChange}/>
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
                <Input placeholder="Личное/командное мероприятие" value={result} onChange={placeState.onChange}/>
            </div>
            <div className={styles.buttonPos}>
                <PrimaryButton content={"Всё верно. Отправить"} clickHandler={clickHandler} size={"large"}/>
            </div>

        </div>
    )
})

export default FormForAchievement;