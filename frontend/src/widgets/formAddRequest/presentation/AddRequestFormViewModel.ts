import { makeObservable, observable, reaction, runInAction } from "mobx";
import { RequestStatus } from "../../../shared/utils/RequestStatus";
import { CreateQuestRequest, StudentService, TeacherService } from "../../../api-generated";
import { QuestRepository } from "../../../store/QuestRepository";

export class AddRequestFormViewModel {
 
    @observable
    createStatus: RequestStatus = RequestStatus.NEVER;
    @observable
    error?: string;

    questRepository: QuestRepository;

    constructor(questRepository: QuestRepository) {
        this.questRepository = questRepository;
        makeObservable(this);
    }

    setupOnResReaction = (onSuccess: () => void, onError: (message: String) => void) => {
        reaction((_) => this.createStatus, (curr, prev) => {
            if(curr == RequestStatus.SUCCESSFUL) onSuccess();
            if(curr == RequestStatus.ERROR) onError(this.error ?? 'Неопознанная ошибка');
        })
    }

    createQuest = async (request: CreateQuestRequest) => {
        this.createStatus = RequestStatus.LOADING;
        try {
            await this.questRepository.create(request);
            console.log(this.questRepository.quests);
            this.createStatus = RequestStatus.SUCCESSFUL;   
        }
        catch(e) {
            runInAction(() => {
                this.createStatus = RequestStatus.ERROR;
                this.error = 'Что-то пошло не так';
            })
        }
    }
}