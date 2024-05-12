import { Navigate } from "react-router-dom";
import { useContext, useEffect, useState } from "react";
import { Context } from "../..";
import { observer } from "mobx-react-lite";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import { LOGIN_PATH } from "../RouterConstants";
import { STORAGE_TOKEN } from "../../shared/utils/StorageConstants";


interface AuthGuardProps{
    children : React.ReactElement;
}

const AuthGuard : React.FC<AuthGuardProps> = observer(({children}) => {
    const [isLoading, setIsLoadingState] = useState(true);
    const { userStore } = useContext(Context);
    let isAuthorized : boolean = userStore.isAuth;

    useEffect(() => {
        refreshToken();
    }, [])

    const refreshToken = async() => {
        console.log("tyt");
        console.log(userStore.activeToken);
        if(userStore.activeToken) 
        {
            console.log("tyt1");
            userStore.isAuth = true;
        } 
        else
        {
            console.log("tyt2");
            if (localStorage.getItem(STORAGE_TOKEN) !== null) 
            {
                console.log("tyt3");
                console.log(localStorage.getItem(STORAGE_TOKEN));
                userStore.activeToken = localStorage.getItem(STORAGE_TOKEN);
                userStore.isAuth = true;
            }
        }
        console.warn(userStore.isAuth);
        setIsLoadingState(false);
    }

    return(
        isLoading
        ?
            <LoadingPage/>
        :
            isAuthorized
                ? 
                children
                :
                <Navigate to={LOGIN_PATH} replace/>
    )
})

export default AuthGuard;