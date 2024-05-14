import {CloseOutlined, InboxOutlined} from "@ant-design/icons";
import { Upload } from "antd";
import { RcFile } from "antd/es/upload";
import { useState } from "react";
import { DataAchievementFromBack, FormAchievement } from "../../entities/achievement/FormAchievement";
import LoadingPage from "../../pages/loadingPage/LoadingPage";
import AchievementService from "../../servises/AchievementService";
import FormForAchievement from "../formAchievement/FormForAchievement";
import styles from "./FormLoadAchievements.module.css";

const { Dragger } = Upload;

interface FormLoadAchievementsProps {
    closeHandler: () => void;
}

const FormLoadAchievements: React.FC<FormLoadAchievementsProps> = ({ closeHandler }) => {
    const [file, setFile ] = useState<RcFile | null>();
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [data, setData] = useState<DataAchievementFromBack>();

    //@ts-ignore
    const dummyRequest = async ({ file, onSuccess }) => {
        const response = await AchievementService.create({File: file});
        if(response !== undefined){
            setData(response);
        }
        setIsLoading(true);
        onSuccess("ok");
    }

    return (
        <div className={styles.overlay}>
            <div className={styles.container}>
                <div>
                    <CloseOutlined className={styles.closeElement} onClick={closeHandler}/>
                    <Dragger
                        name="file"
                        multiple={false}
                        listType="picture"
                        //@ts-ignore
                        customRequest={dummyRequest}
                        beforeUpload={(file) => setFile(file)}>
                        <p className="ant-upload-drag-icon">
                            <InboxOutlined/>
                        </p>
                        <p className="ant-upload-text">Нажмите или перенесите файл для загрузки</p>
                    </Dragger>
                    {
                        isLoading && (data !== undefined)
                            ? <FormForAchievement
                                data={data} closeHandler={closeHandler}/>
                            : null
                    }
                </div>
            </div>
        </div>
    )
}


export default FormLoadAchievements;