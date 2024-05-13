import { AchievementCreateDto } from "../dto/achievement/CreateDro";
import { Achievement } from "../entities/achievement/Achievement";
import $api, { API_URL } from "../shared/utils/Api";

class AchievementService{
    public static async create(dto: AchievementCreateDto){
        try {
            return await $api.postForm(`${API_URL}/achievements`, dto, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                },
                withCredentials: true
            })
        } catch (e){
            console.log(e);
        }
    }

    public static async getAchievements(): Promise<Achievement[]>{
        try {
            return (await $api.get<Achievement[]>(`${API_URL}/achievements`)).data;
        } catch (e){
            console.log(e);
            return []
        }
    }
}

export default AchievementService;