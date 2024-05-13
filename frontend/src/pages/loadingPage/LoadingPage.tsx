import styles from './LoadingPage.module.css'
import {Spin} from "antd";

const LoadingPage: React.FC = () => {
    return (
        <div className={styles.centreElem}>
            <h1 className={styles.flex}>Загрузка...</h1>
            <Spin size="large"/>
        </div>
    )
}

export default LoadingPage;