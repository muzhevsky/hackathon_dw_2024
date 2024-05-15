import React, {useState} from 'react';
import styles from "./RequestsCard.module.css"
import Img from "../../shared/assets/ticket.png";
import RequestsCardModal from "./RequestsCardModal";

interface EventCardProps {
    id: number;
    title: string;
    startDate?: Date;
    endDate: Date;
    statusId: number;
    description: string;
}

const RequestCard: React.FC<EventCardProps> = ({id, title, startDate, endDate, statusId, description}) => {
    const displayDate = startDate !== undefined ? `${startDate.toLocaleDateString()} - ${endDate.toLocaleDateString()}` : "Подробнее";
    const [isOpen, setOpen] = useState(false);


    return (
        <>
            {
                isOpen
                    ? <RequestsCardModal id={id} title={title} startDate={new Date()} endDate={new Date()}
                                         statusId={statusId} description={description} isOpen={isOpen}
                                         setOpen={setOpen}/>
                    : null
            }
            <div className={styles.cardViev}>

                <p className={styles.title}>{title}</p>
                <div className={styles.wrapContent}>
                    <div className={styles.container__image}>
                        {/* <div className={styles.imgS}> */}
                            <img className={styles.img} src={Img} alt=""/>
                        {/* </div> */}
                    </div>

                    <div className={styles.container}>
                        <p className={styles.description}>{description}</p>
                        {startDate ? (
                            <p className={styles.date}>{displayDate}</p>
                        ) : (
                            <>
                                <div className={styles.row}>
                                    <p className={styles.date}>{endDate.toLocaleDateString()}</p>
                                    <p
                                        className={styles.additions}
                                        onClick={() => setOpen(true)}
                                    >Подробнее</p>
                                </div>

                            </>

                        )}
                    </div>
                </div>
            </div>
        </>

    );
};

export default RequestCard;