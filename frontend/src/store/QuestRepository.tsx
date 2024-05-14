import { makeAutoObservable } from "mobx"
import { Request } from "../entities/request/Request";
import { CreateQuestRequest, TeacherService } from "../api-generated";

export class QuestRepository {

    private _quests: Map<number, Request> = new Map();

    get quests() {
        return Array.from(this._quests.values());
    }

    constructor() {
        makeAutoObservable(this);
    }

    getQuestByGroup = async (groupId: number) => {

    }

    getTeacherQuests = async (teacherId: number) => {

    }

    create = async (quest: CreateQuestRequest) => {
        try {
           const res = await TeacherService.postQuest(quest);
        //  TODO добавление здесь в quest
        }
        catch (e) {
            throw e;
        }
    }
}