import React from 'react';
import Img from '../../shared/assets/sertificat.jpg';
import { API_URL } from '../../shared/utils/Api';
import styles from './AchievementCard.module.css'

interface AchievementsProps {
    id: number;
    userId: number;
    fileName: string;
    score: number;
    teamSize: number;

}

const AchievementCard: React.FC<AchievementsProps> = ({ id, userId, fileName, score, teamSize }) => {
    return (
        <div className={styles.cardViev}>
            <div className={styles.img}>
                <img style={{ width: "100%" }} src={`${API_URL}/static/${fileName.slice(fileName.lastIndexOf("/") + 1)}`} alt="" />
            </div>
            <div className={styles.wrapInfo}>
                <p className={styles.title}>{fileName}</p>
                <p className={styles.subtitle}>участник</p>
                <div className={styles.container}>
                    <p className={styles.date}>{"11.08.23"}</p>
                    <p className={styles.additions}>Подробнее</p>
                </div>
            </div>
        </div>
    );
};

export default AchievementCard;