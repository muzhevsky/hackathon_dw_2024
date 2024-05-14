import React from 'react';
import styles from './EventCardModal.module.css'
import Modal from "antd/lib/modal/Modal";
import Img from "../../shared/assets/sad.svg";

interface EventCardModalProps {
    id: number;
    title: string;
    startDate?: Date;
    endDate: Date;
    statusId: number;
    description: string;
    isOpen: boolean;
    setOpen: (isOpen: boolean) => void;
}

const EventCardModal: React.FC<EventCardModalProps> = ({id,title,startDate,endDate,statusId,description, isOpen, setOpen}) => {

    return (
        <Modal
            title={title}
            style={{ top: 20 }}
            footer={null}
            open={isOpen}
            onOk={() => setOpen(false)}
            onCancel={() => setOpen(false)}
        >
            <div className={styles.row}>
                <div className={styles.imgSize}>
                    <img className={styles.imgSize} src={Img} alt=""/>
                </div>

                <div className={styles.col}>
                    <p className={styles.description}>{description}</p>
                </div>
            </div>
        </Modal>
    );
};

export default EventCardModal;