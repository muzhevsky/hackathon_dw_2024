import styles from "./ScholarshipCard.module.css";
import Add from "../../shared/assets/icon_create.svg";
import AchievementService from "../../servises/AchievementService";
import { Achievement } from "../../entities/achievement/Achievement";
import { observer } from "mobx-react-lite";
import { useContext } from "react";
import { Context } from "../..";
import { API_URL } from "../../shared/utils/Api";

const AddScholarship: React.FC = observer(() => {
    const { scholarshipStore } = useContext(Context);

    const downloadFile = (requestId: number) => {
        fetch(`${API_URL}/static/requests/${requestId}.docx`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/doc',
            },
        })
            .then(response => response.blob())
            .then(blob => {
                const url = window.URL.createObjectURL(new Blob([blob]));

                const link = document.createElement('a');
                link.href = url;
                link.download = `Заявка ${requestId}.docx`;

                document.body.appendChild(link);

                link.click();

                link.parentNode!.removeChild(link);
            });
    };

    const clickHandler = async () => {
        const achs: Achievement[] = await AchievementService.getAchievements();
        const idsAch: number[] = achs.map(item => Number(item.id));

        const response = await AchievementService.requestScholar(idsAch);
        console.log(response);
        scholarshipStore.idsScholar = [...scholarshipStore.idsScholar, response];
        downloadFile(response);
    }

    return (
        <div className={styles.WrapAdd} onClick={clickHandler}>
            <img src={Add} alt="добавить" />
            <p className={styles.AddTitle}>Добавить заявку</p>
        </div>
    )
})

export default AddScholarship;