import {New} from "../../entities/new/New";
import styles from './NewCard.module.css'
import Img from "../../shared/assets/sad.svg";

interface NewCardProps {
    newInfo: New;
}

const NewCard: React.FC<NewCardProps> = ({newInfo}) => {
    return (
        <div className={styles.cardViev}>
            <div className={styles.col}>
                <p className={styles.date}>{newInfo.publicationDate.toLocaleDateString()}</p>
                <div className={styles.row}>
                    <img className={styles.imgSize} src={Img} alt=""/>
                    <div className={styles.col}>
                        <p className={styles.title}>{newInfo.title}</p>
                        <p className={styles.description}>{newInfo.content}</p>
                    </div>
                </div>
            </div>


        </div>
    )
}

export default NewCard;