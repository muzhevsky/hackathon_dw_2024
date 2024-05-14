import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import AchievementService from "../../servises/AchievementService";
import AddAchievement from "../addAchievements/AddAchievement";
import AchievementCard from "./AchievementCard";
import styles from "./AchievementCard.module.css";

const Achievements: React.FC = observer(() => {
    const {achievements} = useContext(Context);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    useEffect(() => {
        const response = AchievementService.getAchievements();
        response.then(response => {
            achievements.achievements = response;
            setIsLoading(true);
        });
    }, [])

    return(
        <div className={styles.WrapList}>
            {
                isLoading
                ?   <>
                        <AddAchievement/>
                        {
                            achievements.achievements.map((item, index) => {
                                return <AchievementCard
                                            key={index} 
                                            id={Number(item.id)} 
                                            userId={Number(item.userId)} 
                                            fileName={item.filePath} 
                                            score={Number(item.score)} 
                                            teamSize={Number(item.teamSize)}
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