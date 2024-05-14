import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import { EventForCabinet } from "../../entities/event/EventForCabinet";
import { New } from "../../entities/new/New";
import { Request } from "../../entities/request/Request";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import EventsService from "../../servises/EventsService";
import GlobalEventCard from "../events/GlobalEventCard";
import NewCard from "../news/NewCard";
import RequestCard from "../requests/RequestsCard";
import styles from "../globalAll/GlobalAll.module.css";

const GlobalAll: React.FC = observer(() => {
    const {eventsStore} = useContext(Context);
    const [events, setEvents] = useState<(EventForCabinet | New | Request)[]>([]);
    const [isLoading,setIsLoading] = useState<boolean>(false);

    useEffect(() => {
        const response = EventsService.getAllEvents();
        response.then(response => {
            setEvents(response);
            setIsLoading(true);
        })
    }, [eventsStore.events]);

    useEffect(() => {
        const response = EventsService.getNews();
        response.then(response => {
            setEvents(response);
            setIsLoading(true);
        })
    }, [eventsStore.events]);

    return(
        <div>
            {
                isLoading
                ?   <div className={styles.WrapEvents}>
                    {
                        events.map((item, index) => {
                            if(item.type === "event") return <GlobalEventCard key={index} event={item}/>
                            if(item.type === "new") return<NewCard key={index} newInfo={item}/>
                            else return <RequestCard key={index} id={Number(item.id)} title={"Что-то заполнить"} endDate={new Date()} statusId={1} description={"Что-то заполнить..."}/>
                        })
                    }
                    </div>
                : <LoadingPage/>
            }
        </div>
    )
})

export default GlobalAll;