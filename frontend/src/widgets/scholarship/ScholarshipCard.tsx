import React from 'react';
import styles from './ScholarshipCard.module.css'

interface RequestCardProps {
    id: number;
    userId: number;
    rejected: boolean;
}

const RequestCard: React.FC<RequestCardProps> = ({id, userId, rejected}) => {
    return (
        <div className={styles.requestCard}>
            <p className={styles.title}>Заявка</p>
            <p className={styles.subtitle}>{id}</p>
            <p className={styles.date}>{userId}</p>
        </div>
    );
};

export default RequestCard;