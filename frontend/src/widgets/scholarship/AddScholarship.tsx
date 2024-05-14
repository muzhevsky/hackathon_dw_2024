import styles from "./ScholarshipCard.module.css";
import Add from "../../shared/assets/icon_create.svg";

const AddScholarship: React.FC = () => {
    return(
        <div className={styles.WrapAdd}>
            <img src={Add} alt="добавить"/>
            <p className={styles.AddTitle}>Добавить заявку</p>
        </div>
    )
}

export default AddScholarship;