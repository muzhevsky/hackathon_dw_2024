import {observer} from "mobx-react-lite";
import {useContext, useEffect, useState} from "react";
import {Context} from "../..";
import {Group, testGroup} from "../../entities/group/Group";
import {Student} from "../../entities/student/Student";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import DepartamentService from "../../servises/DepartamentService";
import GroupService from "../../servises/GroupService";
import StudentInfo from "../studentInfo/StudentInfo";
import styles from './ProfileInfo.module.css'

const ProfileInfo: React.FC = observer(() => {
    const {userStore} = useContext(Context);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [addInfo, setAddInfo] = useState<Group>();

    useEffect(() => {
        if (userStore.activeUserRole && userStore.activeUserRole.type === "student") {
            const response = GroupService.getGroupById(userStore.activeUserRole.groupId);
            response.then((response) => {
                setAddInfo(response);
                setIsLoading(true);
                return;
            })
        }
        setIsLoading(true);
    }, [])

    return (
        <>
            {
                isLoading
                    ? <div className={styles.profileWrap}>
                        <div className={styles.nsp}>
                            <p className={styles.nsp}>{`Фамилия: ${userStore.user?.surname}`}</p>
                            <p className={styles.nsp}>{`Имя: ${userStore.user?.name}`}</p>
                            <p className={styles.nsp}>{`Отчество: ${userStore.user?.pathronomyc}`}</p>
                        </div>


                        {
                            userStore.activeRole?.title === "user"
                                ? <StudentInfo departamentTitle={"Инпит"} groupInfo={addInfo ?? testGroup}/>
                                : null
                        }
                    </div>
                    : <LoadingPage/>
            }
        </>

    )
})

export default ProfileInfo;