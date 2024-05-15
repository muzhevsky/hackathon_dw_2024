import { useContext, useEffect, useState } from "react";
import { Outlet, useLocation, useNavigate } from "react-router-dom"
import { Context } from "../..";
import { itemsNavigateDepartament } from "../../entities/role/RoleTabsDepartament";
import { itemsNavigateStudent } from "../../entities/role/RoleTabsStudent";
import { itemsNavigateTeacher } from "../../entities/role/RoleTabsTeacher";
import { HOME_PATH } from "../../routing/RouterConstants";
import DepartamentService from "../../servises/DepartamentService";
import GroupService from "../../servises/GroupService";
import InstituteService from "../../servises/InstituteService";
import NavigateTabs from "../../shared/ui/tabs/NavigateTabs";
import ProfileInfo from "../../widgets/profileInfo/ProfileInfo";
import LoadingPage from "../loadingPage/LoadingPage";
import BalanceCounter from "../../widgets/balance/BalanceCounter";

const HomePage: React.FC = () => {
    const navigate = useNavigate();
    const locate = useLocation();
    const { userStore } = useContext(Context);
    const [isLoading, setIsLoading] = useState<boolean>(false);

    useEffect(() => {
        let departamentId: number | string = 1;
        if (userStore.activeUserRole?.type === "teacher") {
            departamentId = userStore.activeUserRole.departamentId;
        }
        else if (userStore.activeUserRole?.type === "student") {
            const getGroup = GroupService.getGroupById(userStore.activeUserRole.groupId);
            getGroup.then(response => {
                departamentId = response.departamentId;
            })
        } else {
            departamentId = userStore.activeUserRole?.id ?? 1;
        }

        const responseDepartament = DepartamentService.GetDepartamentById(departamentId);
        responseDepartament.then(response => {
            userStore.departament = response;
            const responseInstitute = InstituteService.GetInstituteById(userStore.departament.instituteId);
            responseInstitute.then(response => {
                userStore.institute = response;
                setIsLoading(true);
            })
        })

        if (locate.pathname === HOME_PATH) {
            switch (userStore.user?.role) {
                case "student":
                    return navigate(itemsNavigateStudent[0]);
                case "teacher":
                    return navigate(itemsNavigateTeacher[0]);
                case "departament":
                    return navigate(itemsNavigateDepartament[0]);
            }
        }
    }, [locate.pathname, userStore.activeRole])


    return (
        <>
            {
                isLoading
                    ? <>             
                        <ProfileInfo /> 
                        <BalanceCounter count={658999}/>
                        <NavigateTabs />
                        <Outlet></Outlet>
                    </>
                    : <LoadingPage />
            }

        </>
    )
}

export default HomePage;