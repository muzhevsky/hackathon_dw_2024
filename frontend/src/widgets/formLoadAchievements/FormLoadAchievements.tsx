import { InboxOutlined } from "@ant-design/icons";
import { message, Upload, UploadProps } from "antd";
import { RcFile } from "antd/es/upload";
import { useState } from "react";
import styles from "./FormLoadAchievements.module.css";

const { Dragger } = Upload;

interface FormLoadAchievementsProps {
    closeHandler: () => void;
}

const FormLoadAchievements: React.FC<FormLoadAchievementsProps> = ({ closeHandler }) => {
    const [file, setFile ] = useState<RcFile | null>();

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
        </div>
    )
}

export default FormLoadAchievements;