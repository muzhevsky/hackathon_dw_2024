import { observer } from "mobx-react-lite";
import { useContext, useEffect, useMemo, useState } from "react";
import { Context } from "../..";
import { Achievement } from "../../api-generated";
import { EventResult } from "../../entities/event/EventResult";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import AchievementService from "../../servises/AchievementService";
import EventsService from "../../servises/EventsService";
import AddAchievement from "../addAchievements/AddAchievement";
import AchievementCard from "./AchievementCard";
import styles from "./AchievementCard.module.css";
import { AchivementsViewModel } from "./AchievementsViewModel";

const Achievements: React.FC = observer(() => {
    const { achievements, achievementsRepository, eventResiltRepository } = useContext(Context);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [results, setResults] = useState<EventResult[]>();

    const achievementsViewModel = useMemo(() => new AchivementsViewModel(achievementsRepository, eventResiltRepository), []);

    useEffect(() => {
        achievementsViewModel.loadAchievements();
    }, [])

    // useEffect(() => {
    //     const response = AchievementService.getAchievements();
    //     response.then(response => {
    //         achievements.achievements = response;

    //         const resultResponse = EventsService.getEventResults();
    //         resultResponse.then(_response => {
    //             setResults(_response);
    //             setIsLoading(true);
    //         })
    //     });
    // }, [])

    return (
        <div className={styles.WrapList}>
            {
                achievementsViewModel.isLoaded
                    ? <>
                        <AddAchievement />
                        {
                            achievementsViewModel.achievements.map((item: Achievement, index: number) => {
                                return <AchievementCard
                                    key={index}
                                    id={Number(item.id)}
                                    userId={Number(item.userId)}
                                    fileName={item.filePath ?? ''}
                                    score={Number(item.score)}
                                    withTeam={item.withTeam ?? false}
                                    result={results?.find(i => i.id === item.id)?.title ?? "участник"}
                                />
                            })
                        }
                    </>
                    : <LoadingPage />
            }
        </div>
    )
})

export default Achievements;