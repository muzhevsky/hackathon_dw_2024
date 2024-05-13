import { Role } from "../entities/role/Role";
import $api, { API_URL } from "../shared/utils/Api";

class RoleService{
    public static async GetRoleById(id: number | string): Promise<Role>{
        // return (await $api.get(`${API_URL}/role/${id}`)).data;
        return {id: 4, title: "user"};
    }
}

export default RoleService;