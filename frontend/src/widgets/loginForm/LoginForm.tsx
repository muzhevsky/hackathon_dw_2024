import { EyeInvisibleOutlined, EyeTwoTone } from "@ant-design/icons";
import { Input } from "antd";
import { observer } from "mobx-react-lite";
import { useContext } from "react";
import { useNavigate } from "react-router-dom";
import { Context } from "../..";
import useInput from "../../hooks/UseInput";
import { HOME_PATH } from "../../routing/RouterConstants";
import AuthService from "../../servises/AuthService";
import PrimaryButton from "../../shared/ui/button/PrimaryButton";
import { STORAGE_TOKEN } from "../../shared/utils/StorageConstants";

const LoginForm: React.FC = observer(() => {
    const {userStore} = useContext(Context);
    const navigate = useNavigate();
    const login = useInput();
    const password = useInput();

    const authHandler = async() => {
        const response = await AuthService.login({email: login.value, password: password.value});
        userStore.activeToken = response;
        localStorage.setItem(STORAGE_TOKEN, response);
        userStore.isAuth = true;
        navigate(HOME_PATH);
    }

    return(
        <div>
            <Input 
                size="large" 
                placeholder="Ваш логин..." 
                onChange={login.onChange}
            />
            <Input.Password 
                size="large" 
                placeholder="Введите пароль..." 
                onChange={password.onChange}
                iconRender={(visible) => (visible ? <EyeTwoTone /> : <EyeInvisibleOutlined />)}
            />
            <PrimaryButton content={"Войти"} clickHandler={authHandler} size={"large"}/>
        </div>
    )
})

export default LoginForm;