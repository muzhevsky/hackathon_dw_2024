import { Student } from "../entities/student/Student";
import $api, { API_URL } from "../shared/utils/Api";

class StudentService{
    public static async GetStudentById(id: number | string): Promise<Student>{
        return (await $api.get(`${API_URL}/student?id=${id}`)).data;
    }
}

export default StudentService;