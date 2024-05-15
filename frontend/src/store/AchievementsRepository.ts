import { makeAutoObservable, runInAction } from "mobx";
import { Achievement, StudentService } from "../api-generated";

const attachAchievement = StudentService.postAchievementAttach;

export class AchievementsRepository {
    achievements: Achievement[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    getAchievements = async () => {
        try {
            const achievements = await StudentService.getAchievements();
            runInAction(() => {
                this.achievements = achievements;
            });
        }
        catch (e) {
            throw e;
        }
    }

    addSync = (achievement: Achievement) => {
        this.achievements = [...this.achievements, achievement];
    }
}