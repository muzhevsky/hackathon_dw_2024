import styles from "./ErrorPage.module.css";

const ErrorPage: React.FC = () => {
    return(
        <div>
            <h1 className={styles.textStyle}>
                Произошла неизевестная ошибка
            </h1>
            {/*<img className={styles.error} src="../../shared/assets/sad-circle-svgrepo-com.png" alt="sss"/>*/}
        </div>
    )
}

export default ErrorPage;