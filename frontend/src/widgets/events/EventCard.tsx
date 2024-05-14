import React, {useState} from 'react';
import styles from "./EventCard.module.css"
import Img from "../../shared/assets/web.png";
import EventCardModal from "./EventCardModal";

interface EventCardProps {
    id: number;
    title: string;
    startDate?: Date;
    endDate: Date;
    statusId: number;
    description: string;
}

const EventCard: React.FC<EventCardProps> = ({id, title, startDate, endDate, statusId, description}) => {
    const displayDate = startDate !== undefined ? `${startDate.toLocaleDateString()} - ${endDate.toLocaleDateString()}` : "Подробнее";

    const [isOpen, setOpen] = useState(false);

    return (
        <>
            {
                isOpen
                    ? <EventCardModal id={id} title={title} startDate={new Date()}
                                      endDate={new Date(endDate)} statusId={statusId}
                                      description={description} isOpen={isOpen} setOpen={setOpen}/>
                    : null
            }
            <div className={styles.cardViev}>
                <div className={styles.container__image}>
                    <img className={styles.imgSize} style={{width: "100%"}} src={Img} alt=""/>
                </div>
                <div className={styles.WrapEventInfo}>
                    <div className={styles.row}>
                        <p className={styles.status}>Всероссийский |</p>
                        {/* <p className={styles.date}>{endDate !== undefined ? endDate.getFullYear(): ''}</p> */}
                        <p className={styles.date}>{(new Date()).toLocaleDateString()}</p>
                    </div>
                    <p className={styles.title}>{title}</p>
                    {/* <p className={styles.description}>{description}</p> */}
                    <p className={styles.openContent} onClick={()=>setOpen(true)}>Подробнее...</p>
                </div>
                {/*<div className={styles.container}>*/}
                {/*    {startDate ? (*/}
                {/*        <p className={styles.date}>{displayDate}</p>*/}
                {/*    ) : (*/}
                {/*        <>*/}
                {/*            <p className={styles.date}>{endDate.toLocaleDateString()}</p>*/}
                {/*            <p className={styles.additions}>Подробнее (Мероприятие)</p>*/}
                {/*        </>*/}

                {/*    )}*/}
                {/*</div>*/}

            </div>
        </>
    );
};

export default EventCard;