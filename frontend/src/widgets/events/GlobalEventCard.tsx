import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import { EventForCabinet } from "../../entities/event/EventForCabinet";
import PrimaryButton from "../../shared/ui/button/PrimaryButton";

interface GlobalEventCardProps{
    event: EventForCabinet;
}

const GlobalEventCard: React.FC<GlobalEventCardProps> = observer(({event}) => {
    const { eventsStore } = useContext(Context);

    const addHandler = () => {
        eventsStore.events = [...eventsStore.events, event];
        console.log(eventsStore.events);
    }

    const hasEvent = (): boolean => {
        const tmp = eventsStore.events.find(item => item.id === event.id);
        if(tmp !== undefined) return true;
        return false;
    }

    const [hasInEvents, setInEvents] = useState<boolean>(hasEvent());
    useEffect(() => {
        setInEvents(() => hasEvent());
    }, [addHandler, hasInEvents])

    return(
        <div>
            <p>{event.title}</p>
            <p>{event.description}</p>
            <p>{event.startDate.toLocaleDateString()}</p>
            <PrimaryButton content={hasInEvents ? "Уже участвуете" :"Участвовать"} disabled={hasInEvents} clickHandler={addHandler} size={"middle"}/>
            <p>Подробнее...</p>
        </div>
    )
})

export default GlobalEventCard;