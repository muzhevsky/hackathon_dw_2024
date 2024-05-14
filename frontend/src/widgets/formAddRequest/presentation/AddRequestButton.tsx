import { useState } from "react";
import Portal from "../../../shared/ui/portal/Portal";
import styles from "../../addAchievements/AddAchievement.module.css";
import Add from "../../../shared/assets/icon_create.svg";
import { FormAddRequest } from "./FormAddRequest";
import { Modal } from "antd";

export const AddRequestButton: React.FC = () => {
    const [isOpen, setIsOpen] = useState<boolean>(false);

    const openHandler = () => {
        setIsOpen(true);
    }

    const closeHandler = () => {
        setIsOpen(false);
    }

    //TODO useOutsideClick, отдельным компонентом, чтобы везде прокидывать и было красиво

    return (
        <>
            {
                isOpen
                    ? <Portal children={<FormAddRequest onClose={closeHandler} />} />
                    : null
            }

            <div className={styles.WrapAdd} onClick={openHandler}>
                <img src={Add} alt={"добавить"} />
                <p className={styles.AddTitle}>Добавить задание</p>
            </div>
        </>
    )
}