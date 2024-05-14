import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import { Achievement } from "../../entities/achievement/Achievement";
import { EventResult } from "../../entities/event/EventResult";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import AchievementService from "../../servises/AchievementService";
import EventsService from "../../servises/EventsService";
import AddAchievement from "../addAchievements/AddAchievement";
import AchievementCard from "./AchievementCard";
import styles from "./AchievementCard.module.css";

const Achievements: React.FC = observer(() => {
    const {achievements} = useContext(Context);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [results, setResults] = useState<EventResult[]>();

    useEffect(() => {
        const response = AchievementService.getAchievements();
        response.then(response => {
            achievements.achievements = response;

            const resultResponse = EventsService.getEventResults();
            resultResponse.then(_response => {
                setResults(_response);
                setIsLoading(true);
            })
        });
    }, [achievements.achievements])

    return(
        <div className={styles.WrapList}>
            {
                isLoading
                ?   <>
                        <AddAchievement/>
                        {
                            achievements.achievements.map((item : Achievement, index: number) => {
                                return <AchievementCard
                                    key={index}
                                    id={Number(item.id)}
                                    userId={Number(item.userId)}
                                    fileName={item.filePath}
                                    score={Number(item.score)}
                                    withTeam={item.withTeam} 
                                    result={results?.find(i => i.id === item.id)?.title ?? "участник"}                                        
                                    />
                            })
                        }
                    </>
                :   <LoadingPage/>
            }      
        </div>
    )
})

export default Achievements;