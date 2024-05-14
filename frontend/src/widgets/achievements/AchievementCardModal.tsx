import React from 'react';
import Modal from "antd/lib/modal/Modal";
import styles from "../events/EventCardModal.module.css";
import Img from "../../shared/assets/sad.svg";

interface AchievementCardModalProps {
    id: number;
    userId: number;
    fileName: string;
    score: number;
    teamSize: number;
    isOpen: boolean;
    setIsOpen: (isOpen: boolean) => void;
}

const AchievementCardModal:React.FC<AchievementCardModalProps> = ({id,userId,fileName,score,teamSize,isOpen,setIsOpen}) => {
    return (
        <Modal
            title={fileName}
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
                <div>
                    <p className={styles.description}></p>
                </div>
                <div className={styles.col}>
                    <p className={styles.description}>Очки: {score}`</p>
                    <p className={styles.description}>Команда: {teamSize} человек</p>
                </div>
            </div>
        </Modal>
    );
};

export default AchievementCardModal;