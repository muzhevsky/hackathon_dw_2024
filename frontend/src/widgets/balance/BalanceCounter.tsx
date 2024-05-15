import React from 'react';
import styles from './BalanceCounter.module.css'
import Diamond from '../../shared/assets/diamond.svg'

interface BalanceCounterProps {
    count: number;
}

const BalanceCounter: React.FC<BalanceCounterProps> = ({count}) => {
    return (
        <div className={styles.balanceWrap}>
            <p className={styles.textWrap}>{count}</p>
            <img className={styles.iconWrap} src={Diamond} alt=""/>
        </div>
    );
};

export default BalanceCounter;