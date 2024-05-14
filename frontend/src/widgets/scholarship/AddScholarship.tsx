import styles from "./ScholarshipCard.module.css";
import Add from "../../shared/assets/icon_create.svg";
import AchievementService from "../../servises/AchievementService";
import { Achievement } from "../../entities/achievement/Achievement";

const AddScholarship: React.FC = () => {
    const clickHandler = async() => {
        const achs:Achievement[] = await AchievementService.getAchievements();
        const idsAch: number[] = achs.map(item => Number(item.id));

        const response = await AchievementService.requestScholar(idsAch);
        console.log(response);
    }

    return(
        <div className={styles.WrapAdd} onClick={clickHandler}>
            <img src={Add} alt="добавить"/>
            <p className={styles.AddTitle}>Добавить заявку</p>
        </div>
    )
}

export default AddScholarship;