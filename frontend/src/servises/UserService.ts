import { Teacher, testTeacher } from "../entities/teacher/Teacher";
import { testUser, User } from "../entities/user/User";
import $api, { API_URL } from "../shared/utils/Api";

class UserService{
    public static async GetUserById(id: number | string): Promise<User>{
        // return (await $api.get(`${API_URL}/teacher/${id}`)).data;
        return testUser;
    }
}

export default UserService;