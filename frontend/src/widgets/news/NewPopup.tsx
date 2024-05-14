import {New} from "../../entities/new/New";
import styles from './NewPopup.module.css'
import Img from "../../shared/assets/sertificat.jpg";
import Modal from "antd/lib/modal/Modal";
import {useState} from "react";

interface NewPopupProps {
    newInfo: New;
    isOpen: boolean;
    setIsOpen: (isOpen: boolean) => void;
}

const NewPopup: React.FC<NewPopupProps> = ({newInfo, isOpen, setIsOpen}) => {
    const showModal = () => {
        setIsOpen(true);
    };

    const handleCancel = () => {
        setIsOpen(false);
    };

    return (
        <div>
            <Modal
                title={newInfo.title}
                centered
                open={isOpen}
                onCancel={() => setIsOpen(false)}
                onOk={()=> setIsOpen(false)}
            >
                <div className={styles.row}>
                    <div className={styles.imgSize}>
                        <img className={styles.imgSize} src={Img} alt=""/>
                    </div>

                    <div className={styles.col}>
                        <p className={styles.description}>{newInfo.content}</p>
                    </div>
                </div>
            </Modal>
        </div>
    )
}

export default NewPopup;