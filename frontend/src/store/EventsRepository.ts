import { computed, makeObservable } from "mobx";
import { BaseApiCollection } from "../shared/utils/baseApiCollection";
import { ICollection } from "../shared/utils/iCollection";
import { EventDto, EventResultDto, EventsService, GroupDto, InstituteStructureService } from "../api-generated";
import { EventResult } from "../entities/event/EventResult";
import { Event } from "../entities/event/Event";
import { EventForCabinet } from "../entities/event/EventForCabinet";



export class EventRepository implements ICollection<EventForCabinet> {

    private _baseCollection: BaseApiCollection<EventForCabinet, EventDto> = new BaseApiCollection();


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
        await this._baseCollection.load(async () => EventsService.getEvents(), async (dto) => ({
            id: dto.id ?? -1,
            title: dto.title ?? '',
            description: dto.description ?? '',
            startDate: new Date(dto.startDate ?? ''),
            endDate: new Date(dto.endDate ?? ''),
            type: 'event',
            statusId: dto.statusId ?? -1
        }))
    }

    getById = (id: number): EventForCabinet | null => {
        return this._baseCollection.getById(id);
    }
    where = (predicate: (v: EventForCabinet) => boolean): EventForCabinet[] => {
        return this._baseCollection.where(predicate);
    }
    setMany = (values: EventForCabinet[]): void => {
        return this._baseCollection.setMany(values);
    }
    addMany = (values: EventForCabinet[]): void => {
        return this._baseCollection.addMany(values);
    }
    deleteMany = (values: Pick<EventForCabinet, "id">[]): void => {
        return this._baseCollection.deleteMany(values);
    }

}