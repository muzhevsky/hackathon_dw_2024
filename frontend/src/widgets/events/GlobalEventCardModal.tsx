import React from 'react';
import {EventForCabinet} from "../../entities/event/EventForCabinet";
import styles from "./GlobalEventCardModal.module.css";
import Img from "../../shared/assets/web.png";
import Modal from "antd/lib/modal/Modal";

interface GlobalEventCardProps {
    event: EventForCabinet;
    isOpen:boolean;
    setIsOpen:(isOpen:boolean) => void;
}

const GlobalEventCardModal:React.FC<GlobalEventCardProps> = ({event,isOpen,setIsOpen}) => {
    return (
        <Modal
            title={event.title + event.statusId}
            style={{ top: 20 }}
            open={isOpen}
            footer={null}
            onOk={() => setIsOpen(false)}
            onCancel={() => setIsOpen(false)}
        >
            <div className={styles.row}>
                <div className={styles.imgSize}>
                    <img className={styles.imgSize} src={Img} alt=""/>
                </div>

                <div className={styles.col}>
                    <p className={styles.description}>{event.description}</p>
                </div>
            </div>
        </Modal>
    );
};

export default GlobalEventCardModal;