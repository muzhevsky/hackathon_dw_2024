import { computed, makeObservable } from "mobx";
import { BaseApiCollection } from "../shared/utils/baseApiCollection";
import { ICollection } from "../shared/utils/iCollection";
import { EventResultDto, EventsService} from "../api-generated";
import { EventResult } from "../entities/event/EventResult";



export class EventResultRepository implements ICollection<EventResult> {

    private _baseCollection: BaseApiCollection<EventResult, EventResultDto> = new BaseApiCollection();


    constructor() {
        makeObservable(this);
        this.load();
    }

    @computed
    get isLoaded() {
        return this._baseCollection.isLoaded;
    }

    @computed
    get isLoading() {
        return this._baseCollection.isLoading;
    }

    @computed
    get error() {
        return this._baseCollection.error;
    }

    load = async () => {
        await this._baseCollection.load(async () => EventsService.getEventResults(), async (dto) => ({id: dto.id ?? -1, title: dto.title ?? '', score: dto.score ?? 0}))
    }

    getById = (id: number): EventResult | null => {
        return this._baseCollection.getById(id);
    }
    where = (predicate: (v: EventResult) => boolean): EventResult[]=> {
        return this._baseCollection.where(predicate);
    }
    setMany = (values: EventResult[]): void => {
        return this._baseCollection.setMany(values);
    }
    addMany = (values: EventResult[]): void => {
        return this._baseCollection.addMany(values);
    }
    deleteMany = (values: Pick<EventResult, "id">[]): void => {
        return this._baseCollection.deleteMany(values);
    }
    
}