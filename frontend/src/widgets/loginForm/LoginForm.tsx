import {EyeInvisibleOutlined, EyeTwoTone} from "@ant-design/icons";
import {Input} from "antd";
import {observer} from "mobx-react-lite";
import {useContext} from "react";
import {useNavigate} from "react-router-dom";
import {Context} from "../..";
import useInput from "../../hooks/UseInput";
import {HOME_PATH} from "../../routing/RouterConstants";
import AuthService from "../../servises/AuthService";
import PrimaryButton from "../../shared/ui/button/PrimaryButton";
import {STORAGE_TOKEN} from "../../shared/utils/StorageConstants";
import styles from "./LoginForm.module.css";

const LoginForm: React.FC = observer(() => {
    const {userStore} = useContext(Context);
    const navigate = useNavigate();
    const login = useInput();
    const password = useInput();

    const authHandler = async () => {
        const response = await AuthService.login({email: login.value, password: password.value});
        userStore.activeToken = response;
        localStorage.setItem(STORAGE_TOKEN, response);
        userStore.isAuth = true;
        navigate(HOME_PATH);
    }

    return (
        <div className={styles.FormWrap}>
            <h1 className={styles.loginHeader}>Авторизация</h1>
            <label className={styles.LableText}>Логин</label>
            <Input
                size="large"
                placeholder="Ваш логин..."
                onChange={login.onChange}
                className={styles.InputWrap}
            />
            <label className={styles.LableText}>Пароль</label>
            <Input.Password
                size="large"
                className={styles.InputWrap}
                placeholder="Введите пароль..."
                onChange={password.onChange}
                iconRender={(visible) => (visible ? <EyeTwoTone/> : <EyeInvisibleOutlined/>)}
            />
            <div className={styles.ButtonWrap}>
                <PrimaryButton
                    content={"Войти"}
                    clickHandler={authHandler}
                    size={"large"}
                />
            </div>
        </div>
    )
})

export default LoginForm;