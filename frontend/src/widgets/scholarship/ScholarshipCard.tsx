import React from 'react';
import styles from './ScholarshipCard.module.css'

interface RequestCardProps {
    id: number;
    userId: number;
    rejected: boolean;
    // clickHandler: () => void;
}

const ScholarshipCard: React.FC<RequestCardProps> = ({ id, userId, rejected }) => {
    return (
        <a
            href={`http://localhost:8080/static/requests/${id}.docx`}
            download="Example-PDF-document"
            target="_blank"
            rel="noopener noreferrer"
        >
            <div className={styles.requestCard}>
                <p className={styles.title}>Заявка</p>
                <p className={styles.subtitle}>{id}</p>
                <p className={styles.date}>{userId}</p>
            </div>
        </a>
    );
};

export default ScholarshipCard;