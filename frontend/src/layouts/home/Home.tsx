import { Outlet } from "react-router-dom";
import LoadingPage from "../../pages/loadingPage/LoadingPage";

const Home: React.FC = () => {
    return(
        <div>
            <h1>Home</h1>
            <LoadingPage/>
            <Outlet></Outlet>
        </div>
    )
}

export default Home;