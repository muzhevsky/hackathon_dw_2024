import { Outlet } from "react-router-dom";

const Home: React.FC = () => {
    return(
        <div>
            <h1>Home</h1>
            <Outlet></Outlet>
        </div>
    )
}

export default Home;