import styles from "./ScholarshipCard.module.css";
import Add from "../../shared/assets/icon_create.svg";
import AchievementService from "../../servises/AchievementService";
import { Achievement } from "../../entities/achievement/Achievement";
import { observer } from "mobx-react-lite";
import { useContext } from "react";
import { Context } from "../..";

const AddScholarship: React.FC = observer(() => {
    const { scholarshipStore } = useContext(Context);

    const clickHandler = async() => {
        const achs:Achievement[] = await AchievementService.getAchievements();
        const idsAch: number[] = achs.map(item => Number(item.id));

        const response = await AchievementService.requestScholar(idsAch);
        console.log(response);
        scholarshipStore.idsScholar = [...scholarshipStore.idsScholar, response];
    }

    return(
        <div className={styles.WrapAdd} onClick={clickHandler}>
            <img src={Add} alt="добавить"/>
            <p className={styles.AddTitle}>Добавить заявку</p>
        </div>
    )
})

export default AddScholarship;