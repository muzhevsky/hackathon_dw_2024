import React from 'react';
import Img from '../../shared/assets/sad.svg'
import styles from './AchievementCard.module.css'

interface AchievementsProps {
    id: number;
    userId: number;
    fileName: string;
    score: number;
    teamSize: number;

}

const AchievementCard: React.FC<AchievementsProps> = ({id, userId, fileName, score, teamSize}) => {
    return (
        <div className={styles.cardViev}>
            <div className={styles.img}>
                <img src={Img} alt=""/>
            </div>

            <p className={styles.title}>{fileName}</p>
            <p className={styles.subtitle}>{score}</p>
            <div className={styles.container}>
                <p className={styles.date}>{"11.08.23"}</p>
                <p className={styles.additions}>Подробнее</p>
            </div>

        </div>
    );
};

export default AchievementCard;