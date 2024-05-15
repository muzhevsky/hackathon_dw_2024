import { useState } from "react";
import Add from "../../shared/assets/icon_create.svg";
import Portal from "../../shared/ui/portal/Portal";
import FormLoadAchievements from "../formLoadAchievements/FormLoadAchievements";
import styles from "./AddAchievement.module.css";


const AddAchievement: React.FC = () => {
    const [isOpen, setIsOpen] = useState<boolean>(false);

    const openHandler = () => {
        setIsOpen(true);
    }

    const closeHandler = () => {
        setIsOpen(false);
    }

    //TODO useOutsideClick, отдельным компонентом, чтобы везде прокидывать и было красиво

    return(
        <>
            {
                isOpen
                ? <Portal children={<FormLoadAchievements closeHandler={closeHandler}/>}/>
                : null
            }

            <div className={styles.WrapAdd} onClick={openHandler}>
                <img src={Add} alt={"добавить"}/>
                <p className={styles.AddTitle}>Добавить достижение</p>
            </div>
        </>
    )
}

export default AddAchievement;