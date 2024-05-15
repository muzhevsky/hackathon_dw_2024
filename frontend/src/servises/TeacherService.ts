import { Teacher, testTeacher } from "../entities/teacher/Teacher";
import $api, { API_URL } from "../shared/utils/Api";

class TeacherService{
    public static async GetTeacherById(id: number | string): Promise<Teacher>{
        // return (await $api.get(`${API_URL}/teacher/${id}`)).data;
        return testTeacher;
    }
}

export default TeacherService;