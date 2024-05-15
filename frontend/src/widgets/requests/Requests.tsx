import { observer } from "mobx-react-lite";
import { FormAddRequest } from "../formAddRequest/presentation/FormAddRequest";
import { Context, achievements } from "../..";
import { Achievement } from "../../api-generated";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import styles from "../achievements/AchievementCard.module.css";
import { useContext, useEffect, useMemo, useState } from "react";
import RequestCard from "./RequestsCard";
import { RequestViewModel } from "./RequestViewModel";
import { AddRequestButton } from "../formAddRequest/presentation/AddRequestButton";

const Requests: React.FC = observer(() => {

    const { questRepository, userStore, eventRepository } = useContext(Context);

    const questViewModel = useMemo(() => new RequestViewModel(eventRepository, +(userStore.user?.id ?? -1), questRepository), []);

    return (
        <div className={styles.WrapList}>
            {
                questViewModel.isLoaded
                    ? <>
                        <AddRequestButton />
                        {
                            questViewModel.mergedQuests.map((quest, index) => {
                                return <RequestCard
                                    key={index}
                                    title='Купон'
                                    id={quest.id ?? -1}
                                    endDate={quest.event?.endDate ?? new Date()}
                                    statusId={quest.resultId ?? -1}
                                    description={quest.description ?? 'Награда останется сюрпризом'}
                                />
                            })
                        }
                    </>
                    : <LoadingPage />
            }
        </div>
    )
})

export default Requests;