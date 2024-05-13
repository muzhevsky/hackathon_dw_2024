import { AchievementCreateDto } from "../dto/achievement/CreateDro";
import $api, { API_URL } from "../shared/utils/Api";

class AchievementService{
    public static async create(dto: AchievementCreateDto){
        return await $api.postForm(`${API_URL}/achievements`, dto, {
            headers: {
                'Content-Type': 'multipart/form-data'
              },
              withCredentials: true
        })
    }
}

export default AchievementService;