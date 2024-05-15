import { Achievement } from "../entities/achievement/Achievement";

class AchievementsStore{
    private _achievements: Achievement[] = [];

    get achievements() {
        return this._achievements;
    }

    set achievements(achievements: Achievement[]){
        this._achievements = achievements;
    }
}

export default AchievementsStore;