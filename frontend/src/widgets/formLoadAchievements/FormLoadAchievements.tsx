import { InboxOutlined } from "@ant-design/icons";
import { Upload } from "antd";
import { RcFile } from "antd/es/upload";
import { useState } from "react";
import { FormAchievement } from "../../entities/achievement/FormAchievement";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import FormForAchievement from "../formAchievement/FormForAchievement";
import styles from "./FormLoadAchievements.module.css";

const { Dragger } = Upload;

interface FormLoadAchievementsProps {
    closeHandler: () => void;
}

const FormLoadAchievements: React.FC<FormLoadAchievementsProps> = ({ closeHandler }) => {
    const [file, setFile ] = useState<RcFile | null>();
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const [data, setData] = useState<FormAchievement>({
        nameEvent: "тест",
        participant: "Юнева Катя",
        dateEvent: "15.02.2023",
        place: "3 место"
    });

    //@ts-ignore
    const dummyRequest = async ({ file, onSuccess }) => {    
        setTimeout(() => {
           onSuccess("ok");
        }, 0);
      }

    return (
        <div className={styles.DivForm}>
            <button onClick={closeHandler}>Закрыть</button>
            <Dragger 
                name="file" 
                multiple={false}
                listType="picture"
                //@ts-ignore
                customRequest={dummyRequest}
                beforeUpload={(file) => setFile(file)}>
                <p className="ant-upload-drag-icon">
                    <InboxOutlined />
                </p>
                <p className="ant-upload-text">Нажмите или перенесите файл для загрузки</p>
            </Dragger>
            {
                isLoading
                ? <FormForAchievement 
                    data={data} closeHandler={closeHandler}/>
                : <LoadingPage/>
            }
        </div>
    )
}

export default FormLoadAchievements;