import { computed, makeObservable, observable } from "mobx";
import { RequestStatus } from "../../shared/utils/RequestStatus";
import { AchievementsRepository } from "../../store/AchievementsRepository";
import { EventResultRepository } from "../../store/EventsResultRepository";

export class AchivementsViewModel {
    achievementsRepository: AchievementsRepository;
    eventResultsRepository: EventResultRepository;

    @observable
    getAchievementsStatus: RequestStatus = RequestStatus.NEVER;

    @computed
    get isLoaded() {
        return this.getAchievementsStatus == RequestStatus.SUCCESSFUL && this.eventResultsRepository.isLoaded;
    }

    @computed
    get achievements() {
        return this.achievementsRepository.achievements;
    }

    constructor(achievementsRepository: AchievementsRepository, eventResultsRepository: EventResultRepository) {
        makeObservable(this);
        this.achievementsRepository = achievementsRepository;
        this.eventResultsRepository = eventResultsRepository;
    }

    loadAchievements = async (refresh?: boolean) => {
        if(refresh) this.achievementsRepository.getAchievements();
        else {
            this.getAchievementsStatus = RequestStatus.LOADING;
            await this.achievementsRepository.getAchievements();
            this.getAchievementsStatus = RequestStatus.SUCCESSFUL;
        }
    }

}