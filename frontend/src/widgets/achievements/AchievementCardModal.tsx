import React from 'react';
import Modal from "antd/lib/modal/Modal";
import styles from "../events/EventCardModal.module.css";
import {API_URL} from "../../shared/utils/Api";

interface AchievementCardModalProps {
    id: number;
    userId: number;
    fileName: string;
    score: number;
    isOpen: boolean;
    setIsOpen: (isOpen: boolean) => void;
    withTeam: boolean;
    result: string;
}

const AchievementCardModal:React.FC<AchievementCardModalProps> = ({id,userId,fileName,score,isOpen,setIsOpen, withTeam, result}) => {
    let Img = `${API_URL}/static/achievements/${fileName.slice(fileName.lastIndexOf("/") + 1)}`
    return (
        <Modal
            title={withTeam ? "Командное" : "Личное"}
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
                    <p className={styles.subtitle}>{result}</p>
                </div>
                <div className={styles.col}>
                    <p className={styles.date}>Дата: {"11.08.23"}</p>
                </div>
            </div>
        </Modal>
    );
};

export default AchievementCardModal;