import { useEffect } from "react";
import { Outlet } from "react-router-dom"
import NavigateTabs from "../../shared/ui/tabs/NavigateTabs";

const HomePage: React.FC = () => {
    //TODO сделать рероут на первую страницу массива табов в зависимости от роли

    return(
        <>
            <h1>Домашняя страница</h1>
            <NavigateTabs/>
            <Outlet></Outlet>
        </>
    )
}

export default HomePage;