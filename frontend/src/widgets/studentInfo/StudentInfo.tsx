import { Group } from "../../entities/group/Group";
import { Student } from "../../entities/student/Student";
import PrimaryButton from "../../shared/ui/button/PrimaryButton";
import { GroupAdapter } from "../../shared/utils/GroupAdapter";
import styles from "./StudentInfo.module.css";

interface StudentInfoProps{
    departamentTitle: string;
    groupInfo: Group;
}

const StudentInfo: React.FC<StudentInfoProps> = ({departamentTitle, groupInfo}) => {
    return(
        <div className={styles.wrapModule}>
            <div className={styles.container}>
                <p className={styles.pad}>{`Институт: ${departamentTitle}`}</p>
                <p className={styles.pad}>{`Группа: ${groupInfo.title}, курс: ${GroupAdapter.GetCourse(groupInfo.title)}`}</p>
            </div>

            <a className={styles.link} href="https://t.me/CodeHubNotifierBot" target="_blank">
                <PrimaryButton content={"Telegtam bot"} clickHandler={() => console.log('click')} size={"large"}/>
            </a>
        </div>
    )
}

export default StudentInfo;