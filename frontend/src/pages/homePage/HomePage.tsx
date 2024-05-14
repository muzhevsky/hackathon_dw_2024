import { Outlet } from "react-router-dom"

const HomePage: React.FC = () => {
    return(
        <>
            <h1>Домашняя страница</h1>
            <Outlet></Outlet>
        </>
    )
}

export default HomePage;