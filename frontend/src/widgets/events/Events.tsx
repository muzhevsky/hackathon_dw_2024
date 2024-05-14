import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import EventsService from "../../servises/EventsService";
import EventCard from "./EventCard";
import GoToEvents from "./GoToEvents";
import styles from "./EventCard.module.css";
import { EventForCabinet } from "../../entities/event/EventForCabinet";

const Events: React.FC = observer(() => {
    const [ isLoading, setIsLoading ] = useState<boolean>(false);
    const { eventsStore } = useContext(Context);

    useEffect(() => {
        console.log(eventsStore.events);
        if(eventsStore.events.length === 0){
            const response = EventsService.getEvents();
            response.then(response => {
                eventsStore.events = response;
                setIsLoading(true);
            })
        }
        setIsLoading(true);
    }, [])

    return(
        <>
        {
            isLoading
            ?   <div className={styles.WrapEvents}>
                    <GoToEvents/>
                    {
                        eventsStore.events.map((item: EventForCabinet, index: number) => {
                            return <EventCard 
                                        key={index}
                                        id={Number(item.id)} 
                                        title={item.title} 
                                        endDate={item.endDate} 
                                        statusId={Number(item.statusId)} 
                                        description={item.description}/>
                        })
                    }
                </div>
            : <LoadingPage/>
        }
        </>
    )
})

export default Events;