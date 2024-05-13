import React from 'react';
import styles from "./EventCard.module.css"
import Img from "../../shared/assets/sad.svg";

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

    return (
        <div className={styles.cardViev}>
            <p className={styles.title}>{title}</p>
            <div className={styles.container__image}>
                <div className={styles.img}>
                    <img src={Img} alt=""/>
                </div>
                <p className={styles.description}>{description}</p>
            </div>

            <div className={styles.container}>
                {startDate ? (
                    <p className={styles.date}>{displayDate}</p>
                ) : (
                    <>
                        <p className={styles.date}>{endDate.toLocaleDateString()}</p>
                        <p className={styles.additions}>Подробнее (Мероприятие)</p>
                    </>

                )}
            </div>

        </div>
    );
};

export default EventCard;