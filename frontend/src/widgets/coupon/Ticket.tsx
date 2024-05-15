import React from 'react';
import styles from './Ticket.module.css'
import PrimaryButton from "../../shared/ui/button/PrimaryButton";
import Diamond from '../../shared/assets/diamond.svg'
import {ReactComponent as CartIcon} from "../../shared/assets/diamond.svg"

interface TicketProps {
    title: string;
    cost: number;
    icon?: string
}

const Ticket: React.FC<TicketProps> = ({title, cost, icon}) => {
    const ticketImage = require(`../../shared/assets/ticket.png`);
    const Diamond = require(`../../shared/assets/diamond_636600.png`);
    const [isPurchased, setIsPurchased] = React.useState(false);

    const handlePurchase = () => {
        setIsPurchased(true);
    };
    return (
        <div className={styles.rowGap}>
            <div className={styles.containerWrap}>
                <PrimaryButton
                    content={isPurchased ? 'Куплено' : 'Приобрести'}
                    clickHandler={isPurchased ? () => ('') : handlePurchase}
                    size={"large"}
                    disabled={isPurchased}
                />
                <div className={styles.costCont}>
                    <img className={styles.absImg} src={ticketImage} alt=""/>

                </div>

                <div className={styles.col}>
                    <p className={styles.centreText}>{cost}<img src={Diamond} style={{height:'8%', width:'8%'}}
                                                                alt=""/></p>
                    <p className={styles.centreText}>{title}</p>

                </div>
            </div>
        </div>
    );
};


export default Ticket;