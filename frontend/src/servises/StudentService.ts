import { Role } from "../entities/role/Role";
import { Student, testStudent } from "../entities/student/Student";
import $api, { API_URL } from "../shared/utils/Api";

class StudentService{
    public static async GetStudentById(id: number | string): Promise<Student>{
        // return (await $api.get(`${API_URL}/student/${id}`)).data;
        return testStudent;
    }
}

export default StudentService;