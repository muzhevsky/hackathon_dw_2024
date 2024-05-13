import { useContext, useEffect } from "react";
import { Outlet, useLocation, useNavigate } from "react-router-dom"
import { Context } from "../..";
import { itemsNavigateDepartament } from "../../entities/role/RoleTabsDepartament";
import { itemsNavigateStudent } from "../../entities/role/RoleTabsStudent";
import { itemsNavigateTeacher } from "../../entities/role/RoleTabsTeacher";
import { HOME_PATH } from "../../routing/RouterConstants";
import NavigateTabs from "../../shared/ui/tabs/NavigateTabs";
import ProfileInfo from "../../widgets/profileInfo/ProfileInfo";

const HomePage: React.FC = () => {
    const navigate = useNavigate();
    const locate = useLocation();
    const { userStore } = useContext(Context);

    useEffect(() => {
        if(locate.pathname === HOME_PATH){
            switch(userStore.activeRole?.title){
                case "user":
                    return navigate(itemsNavigateStudent[0]);
                case "teacher":
                    return navigate(itemsNavigateTeacher[0]);
                case "departament":
                    return navigate(itemsNavigateDepartament[0]);
            }
        }
    }, [locate.pathname, userStore.activeRole])


    return(
        <>
            <ProfileInfo/>
            <NavigateTabs/>
            <Outlet></Outlet>
        </>
    )
}

export default HomePage;