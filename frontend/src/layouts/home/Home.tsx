import { observer } from "mobx-react-lite";
import { useContext, useEffect, useState } from "react";
import { Outlet } from "react-router-dom";
import { Context } from "../..";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import DepartamentService from "../../servises/DepartamentService";
import RoleService from "../../servises/RoleService";
import StudentService from "../../servises/StudentService";
import TeacherService from "../../servises/TeacherService";

const Home: React.FC = observer(() => {
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const { userStore } = useContext(Context);

    useEffect(() => {
        const response = RoleService.GetRoleById(userStore.user?.role_id ?? 4);
        response.then(response => {
            userStore.activeRole = response;
            if(userStore.activeRole.title === "user"){
                const responseUserRole = StudentService.GetStudentById(userStore.user?.id ?? 1);
                responseUserRole.then(response => {
                    userStore.activeUserRole = response;
                })
            } else if(userStore.activeRole.title === "teacher"){
                const responseUserRole = TeacherService.GetTeacherById(userStore.user?.id ?? 1);
                responseUserRole.then(response => {
                    userStore.activeUserRole = response;
                })
            } else {
                const responseUserRole = DepartamentService.GetDepartamentById(userStore.user?.id ?? 1);
                responseUserRole.then(response => {
                    userStore.activeUserRole = response;
                })
            }
            setIsLoading(true);
        })
    }, [])

    return (
        <>
            {
                isLoading
                    ? <div>
                        <Outlet></Outlet>
                    </div>
                    : <LoadingPage />
            }
        </>
    )
})

export default Home;