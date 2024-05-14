import { useNavigate } from "react-router";
import { GLOBAL_EVENTS_PATH } from "../../routing/RouterConstants";
import styles from "./EventCard.module.css";

const GoToEvents: React.FC = () => {
    const navigate = useNavigate();

    return(
        <div className={styles.WrapNavigate} onClick={() => navigate(GLOBAL_EVENTS_PATH)}>
            <p className={styles.NavigateTitle}>Перейти к выбору мероприятия</p>
        </div>
    )
}

export default GoToEvents;