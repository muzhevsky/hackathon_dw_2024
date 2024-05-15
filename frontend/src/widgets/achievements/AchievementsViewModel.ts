import { action, computed, makeObservable, observable, runInAction } from "mobx";
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

    @action
    loadAchievements = async (refresh?: boolean) => {
        console.warn("tyt");
        if (refresh) this.achievementsRepository.getAchievements();
        else {
            runInAction(() => {
                this.getAchievementsStatus = RequestStatus.LOADING;
            })
            
            try {
                await this.achievementsRepository.getAchievements();
                runInAction(() => {
                    console.log('УСПЕХ');
                    
                    this.getAchievementsStatus = RequestStatus.SUCCESSFUL;
                })
            }

            catch (e) {
                console.log('ERROR');
                
                runInAction(() => this.getAchievementsStatus = RequestStatus.ERROR);
            }
        }
    }

}