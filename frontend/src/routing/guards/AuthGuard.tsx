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
        if(userStore.activeToken) 
        {
            userStore.isAuth = true;
        } 
        else
        {
            if (localStorage.getItem(STORAGE_TOKEN) !== null) 
            {
                userStore.activeToken = localStorage.getItem(STORAGE_TOKEN);
                userStore.isAuth = true;
            }
        }
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