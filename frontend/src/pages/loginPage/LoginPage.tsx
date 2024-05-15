import {Col, Row} from "antd";
import LoginForm from "../../widgets/loginForm/LoginForm";
import styles from "./LoginPage.module.css";

const LoginPage: React.FC = () => {
    return (
        <div>
            {/*<Row >*/}
            {/*    <Col className="colHeight" flex={7}>2 / 5</Col>*/}
            {/*    <Col flex={3}>3 / 5</Col>*/}
            {/*</Row>*/}
            <div className={styles.leftSide}>
                <LoginForm/>
            </div>
            <div className={styles.rightSide}>
                <div className={styles.title}>
                    СГТУ
                </div>
                <div className={styles.subTitle}>
                    КАБИНЕТ
                </div>
            </div>
        </div>
    )
}

export default LoginPage;