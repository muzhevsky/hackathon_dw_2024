import { action, computed, makeObservable, observable, runInAction } from "mobx";
import { RequestStatus } from "../../shared/utils/RequestStatus";
import { EventRepository } from "../../store/EventsRepository";
import { QuestRepository } from "../../store/QuestRepository";
import { ALL_SELECT } from "../../shared/utils/baseCollection";
import { QuestDto } from "../../api-generated";
import { EventForCabinet } from "../../entities/event/EventForCabinet";
import { async } from "q";

type MergedQuest = Omit<QuestDto, 'eventId'> & {event: EventForCabinet | null}

export class RequestViewModel {
    @observable
    getQuestStatus: RequestStatus = RequestStatus.NEVER;

    private _teacherId: number;
    private _eventsRepository: EventRepository;
    private _questRepository: QuestRepository;

    @computed
    get isLoaded() {
        return this.getQuestStatus == RequestStatus.SUCCESSFUL && this._eventsRepository.isLoaded;
    }

    @computed
    get events() {
        return this._eventsRepository.where(ALL_SELECT);
    }

    @computed
    get mergedQuests() {
        return this._questRepository.quests.map<MergedQuest>(quest => ({
            ...quest,
            event: this._eventsRepository.getById(quest.id ?? -1 )
        }))
    }

    constructor(eventRepository: EventRepository, teacherId: number, questRepository: QuestRepository) {
        makeObservable(this);
        this._eventsRepository = eventRepository;
        this._teacherId = teacherId;
        this._questRepository = questRepository;
        this.loadQuests();
    }

    // @action 
    loadQuests =  async() => {
            runInAction(() => {
                this.getQuestStatus = RequestStatus.LOADING;
            })
            await this._questRepository.getTeacherQuests(Number(localStorage.getItem("lk_teacherId")) ?? this._teacherId);
            runInAction(() => {
                this.getQuestStatus = RequestStatus.SUCCESSFUL;
            })
    }
}