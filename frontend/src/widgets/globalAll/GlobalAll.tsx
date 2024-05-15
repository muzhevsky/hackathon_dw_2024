import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import { EventForCabinet } from "../../entities/event/EventForCabinet";
import { New } from "../../entities/new/New";
import { Quest, Request } from "../../entities/request/Request";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import EventsService from "../../servises/EventsService";
import GlobalEventCard from "../events/GlobalEventCard";
import NewCard from "../news/NewCard";
import RequestCard from "../requests/RequestsCard";
import styles from "../globalAll/GlobalAll.module.css";
import StudentService from "../../servises/StudentService";

const GlobalAll: React.FC = observer(() => {
    const {eventsStore, userStore} = useContext(Context);
    const [events, setEvents] = useState<(EventForCabinet | New | Quest)[]>([]);
    const [isLoadingNews,setIsLoadingNews] = useState<boolean>(false);
    const [isLoadingRequests,setIsLoadingRequests] = useState<boolean>(false);


    useEffect(() => {
        const response = StudentService.GetRequestsByGroup(userStore.activeUserRole?.type === "student" ? userStore.activeUserRole.groupId : 1);
        response.then(response => {
            const tmp = response.map(item => {
                const newQuest: Quest = {
                    type: "quest",
                    id: item.id,
                    teacherId: item.teacherId,
                    eventId: item.eventId,
                    resultId: item.resultId,
                    groupId: item.groupId,
                    description: item.description
                }
                return newQuest;
            })
            setEvents(events => [...events, ...tmp]);
            console.log(events);
            setIsLoadingRequests(true);
        })
    }, []);

    useEffect(() => {
        const response = EventsService.getNews();
        response.then(response => {
            setEvents(events =>[...events, ...response]);
            console.log(events);
            setIsLoadingNews(true);
        })
    }, [eventsStore.events]);

    return(
        <div>
            {
                isLoadingNews && isLoadingRequests
                ?   <div className={styles.WrapEvents}>
                    {
                        events.sort((a,b) => Number(a.id) - Number(b.id)).map((item, index) => {
                            if(item.type === "event") return <GlobalEventCard key={index} event={item}/>
                            if(item.type === "new") return<NewCard key={index} newInfo={item}/>
                            else return <RequestCard key={index}
                                title='Купон'
                                id={Number(item.id) ?? -1}
                                endDate={new Date()}
                                statusId={item.resultId ?? -1}
                                description={item.description ?? 'Награда останется сюрпризом'}/>
                        })
                    }
                    </div>
                : <LoadingPage/>
            }
        </div>
    )
})

export default GlobalAll;