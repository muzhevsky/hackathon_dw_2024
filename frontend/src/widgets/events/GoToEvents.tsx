import { useNavigate } from "react-router";
import { GLOBAL_EVENTS_PATH } from "../../routing/RouterConstants";

const GoToEvents: React.FC = () => {
    const navigate = useNavigate();

    return(
        <div onClick={() => navigate(GLOBAL_EVENTS_PATH)}>
            <p>Перейти к выбору мероприятия</p>
        </div>
    )
}

export default GoToEvents;