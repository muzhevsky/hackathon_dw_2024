import {New} from "../../entities/new/New";
import styles from './NewCard.module.css'
import {useState} from "react";
import Modal from "antd/lib/modal/Modal";
import NewPopup from "./NewPopup";


interface NewCardProps {
    newInfo: New;
}


const NewCard: React.FC<NewCardProps> = ({newInfo}) => {
    const [modal2Open, setModal2Open] = useState(false);
    let Img = require('../../shared/assets/news/' + newInfo.imageUrl);
    return (
        <>
            {
                modal2Open
                    ? <NewPopup newInfo={newInfo} isOpen={modal2Open} setIsOpen={setModal2Open}/>
                    : null
            }
            <div
                className={styles.cardViev}

            >
                <div className={styles.col} onClick={() => {
                    setModal2Open(true)
                }}>

                    {/* <div className={styles.row}> */}
                        <div className={styles.ImgWrap}>
                            <img className={styles.imgSize} src={Img} alt=""/>
                        </div>
                        <div className={styles.col1}>
                            <p className={styles.title}>{newInfo.title}</p>
                            <p className={styles.date}>{newInfo.publicationDate.toLocaleDateString()}</p>
                            <p className={styles.description}>{newInfo.content}</p>
                        </div>
                    {/* </div> */}
                </div>


            </div>
        </>
    )
}

export default NewCard;