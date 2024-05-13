import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import EventsService from "../../servises/EventsService";
import EventCard from "./EventCard";
import GoToEvents from "./GoToEvents"

const Events: React.FC = observer(() => {
    const [ isLoading, setIsLoading ] = useState<boolean>(false);
    const { eventsStore } = useContext(Context);

    useEffect(() => {
        const response = EventsService.getEvents();
        response.then(response => {
            eventsStore.events = response;
            setIsLoading(true);
        })
    }, [])

    return(
        <>
        {
            isLoading
            ?   <>
                    <GoToEvents/>
                    {
                        eventsStore.events.map((item, index) => {
                            return <EventCard 
                                        key={index}
                                        id={Number(item.id)} 
                                        title={item.title} 
                                        endDate={item.endDate} 
                                        statusId={Number(item.statusId)} 
                                        description={item.description}/>
                        })
                    }
                </>
            : <LoadingPage/>
        }
        </>
    )
})

export default Events;