import { Group, testGroup } from "../entities/group/Group";
import $api, { API_URL } from "../shared/utils/Api";

class GroupService{
    public static async getGroupById(id: number | string): Promise<Group> {
        return (await $api.get(`${API_URL}/group/${id}`)).data;
    }
}

export default GroupService;