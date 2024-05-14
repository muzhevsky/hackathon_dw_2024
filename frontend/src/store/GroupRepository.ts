import { computed, makeObservable } from "mobx";
import { Group } from "../entities/group/Group";
import { BaseApiCollection } from "../shared/utils/baseApiCollection";
import { ICollection } from "../shared/utils/iCollection";
import { GroupDto, InstituteStructureService } from "../api-generated";



export class GroupRepository implements ICollection<Group> {

    private _baseCollection: BaseApiCollection<Group, GroupDto> = new BaseApiCollection();


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
        await this._baseCollection.load(async () => InstituteStructureService.getGroups(), async (dto) => ({
            id: dto.id ?? -1, 
            departamentId: dto.departmentId ?? -1,
            title: dto.title ?? '',
        }))
    }

    getById = (id: string | number): Group | null => {
        return this._baseCollection.getById(id);
    }
    where = (predicate: (v: Group) => boolean): Group[]=> {
        return this._baseCollection.where(predicate);
    }
    setMany = (values: Group[]): void => {
        return this._baseCollection.setMany(values);
    }
    addMany = (values: Group[]): void => {
        return this._baseCollection.addMany(values);
    }
    deleteMany = (values: Pick<Group, "id">[]): void => {
        return this._baseCollection.deleteMany(values);
    }
    
}