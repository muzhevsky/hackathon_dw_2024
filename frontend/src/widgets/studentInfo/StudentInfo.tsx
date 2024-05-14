import { Group } from "../../entities/group/Group";
import { Student } from "../../entities/student/Student";
import { GroupAdapter } from "../../shared/utils/GroupAdapter";
import styles from "./StudentInfo.module.css";

interface StudentInfoProps{
    departamentTitle: string;
    groupInfo: Group;
}

const StudentInfo: React.FC<StudentInfoProps> = ({departamentTitle, groupInfo}) => {
    return(
        <div className={styles.container}>
            <p className={styles.pad}>{`Институт: ${departamentTitle}`}</p>
            <p className={styles.pad}>{`Группа: ${groupInfo.title}, курс: ${GroupAdapter.GetCourse(groupInfo.title)}`}</p>
        </div>
    )
}

export default StudentInfo;