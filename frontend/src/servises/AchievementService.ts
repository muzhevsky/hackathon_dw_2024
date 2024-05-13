import { AchievementCreateDto } from "../dto/achievement/CreateDro";
import { Achievement } from "../entities/achievement/Achievement";
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

    public static async getAchievements(): Promise<Achievement[]>{
        return (await $api.get<Achievement[]>(`${API_URL}/achievements`)).data;
    }
}

export default AchievementService;