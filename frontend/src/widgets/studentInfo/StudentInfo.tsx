import { Group } from "../../entities/group/Group";
import { Student } from "../../entities/student/Student";
import { GroupAdapter } from "../../shared/utils/GroupAdapter";

interface StudentInfoProps{
    departamentTitle: string;
    groupInfo: Group;
}

const StudentInfo: React.FC<StudentInfoProps> = ({departamentTitle, groupInfo}) => {
    return(
        <div>
            <p>{departamentTitle}</p>
            <p>{`Группа: ${groupInfo.title}, курс: ${GroupAdapter.GetCourse(groupInfo.title)}`}</p>
        </div>
    )
}

export default StudentInfo;