import { observer } from "mobx-react-lite";
import React, { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import { EventForCabinet } from "../../entities/event/EventForCabinet";
import PrimaryButton from "../../shared/ui/button/PrimaryButton";
import styles from "./GlobalEventCard.module.css";
import Img from "../../shared/assets/web.png";
import GlobalEventCardModal from "./GlobalEventCardModal";

interface GlobalEventCardProps {
    event: EventForCabinet;
}

const GlobalEventCard: React.FC<GlobalEventCardProps> = observer(({ event }) => {
    const { eventsStore } = useContext(Context);
    const [isOpen, setIsOpen] = React.useState(false);


    const addHandler = () => {
        eventsStore.events = [...eventsStore.events, event];
        console.log(eventsStore.events);
    }

    const hasEvent = (): boolean => {
        const tmp = eventsStore.events.find(item => item.id === event.id);
        if (tmp !== undefined) return true;
        return false;
    }

    const [hasInEvents, setInEvents] = useState<boolean>(hasEvent());
    useEffect(() => {
        setInEvents(() => hasEvent());
    }, [addHandler, hasInEvents])

    return (
        <>
            {
                isOpen
                    ? <GlobalEventCardModal event={event} isOpen={isOpen} setIsOpen={setIsOpen} />
                    : null
            }
            <div className={styles.cardViev}>
                <div
                    className={styles.ImgWrap}
                    onClick={() => setIsOpen(true)}
                >
                    <img className={styles.imgSize} src={Img} alt="" />
                </div>
                <div className={styles.WrapContent}>
                    <div className={styles.row}>
                        <p className={styles.title}>{event.title}</p>
                        <p className={styles.date}>{event.startDate.toLocaleDateString()}</p>
                    </div>
                    <p className={styles.description}>{event.description}</p>
                    <div className={styles.buttonWrap}>
                        <PrimaryButton content={hasInEvents ? "Уже участвуете" : "Участвовать"} disabled={hasInEvents}
                            clickHandler={addHandler} size={"middle"} />
                    </div>
                </div>
            </div>
        </>
    )
})

export default GlobalEventCard;