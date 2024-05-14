import { AchievementCreateDto } from "../dto/achievement/CreateDro";
import { AchConnected, AchCustom, Achievement } from "../entities/achievement/Achievement";
import { DataAchievementFromBack } from "../entities/achievement/FormAchievement";
import $api, { API_URL } from "../shared/utils/Api";

class AchievementService{
    public static async create(dto: AchievementCreateDto): Promise<DataAchievementFromBack | undefined>{
        try {
            return (await $api.postForm<DataAchievementFromBack>(`${API_URL}/achievement/attach`, dto, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                },
                withCredentials: true
            })).data;
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

    public static async connect(dto: AchConnected){
        return (await $api.post(`${API_URL}/achievement/connected`, dto)).data;
    }

    public static async custom(dto: AchCustom){
        return (await $api.post(`${API_URL}/achievement/custom`, dto)).data;
    }
}

export default AchievementService;