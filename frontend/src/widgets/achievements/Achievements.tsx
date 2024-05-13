import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import AchievementService from "../../servises/AchievementService";
import AddAchievement from "../addAchievements/AddAchievement";
import AchievementCard from "./AchievementCard";

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
        <>
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
        </>
    )
})

export default Achievements;