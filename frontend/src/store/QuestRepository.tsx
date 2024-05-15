import { makeAutoObservable, runInAction } from "mobx"
import { Request } from "../entities/request/Request";
import { CreateQuestRequest, QuestDto, TeacherService } from "../api-generated";

export class QuestRepository {

    private _quests: Map<number, QuestDto> = new Map();

    get quests() {
        return Array.from(this._quests.values());
    }

    constructor() {
        makeAutoObservable(this);
    }

    getQuestByGroup = async (groupId: number) => {
        try {
            const res = await TeacherService.getGroupQuests(groupId);
            runInAction(() => this._quests = new Map(res.map(dto => [dto.id ?? 0, dto])));
        }
        catch(e) {
            throw e;
        }
    }

    getTeacherQuests = async (teacherId: number) => {
        const res = await TeacherService.getTeacherQuests(teacherId);
        runInAction(() => this._quests = new Map(res.map(dto => [dto.id ?? 0, dto])));
    }

    create = async (quest: CreateQuestRequest) => {
        try {
            const res = await TeacherService.postQuest(quest);
            this._quests.set(res.id ?? -1, res);
            // this._quests.set();
            //  TODO добавление здесь в quest
        }
        catch (e) {
            throw e;
        }
    }
}