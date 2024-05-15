import { ObservableMap, action, makeAutoObservable, makeObservable, observable } from "mobx";
import { WithId, ICollection, IdTypePicker } from "./iCollection";

export const ALL_SELECT = (v: any) => true;


export class BaseCollection<T extends WithId> implements ICollection<T> {
    @observable
    storage: ObservableMap<IdTypePicker<T>, T> = new ObservableMap();

    constructor() {
        makeObservable(this);
    }

    getById(this: BaseCollection<T>, id: IdTypePicker<T>): T | null {
        return this.storage.get(id) ?? null;
    }
    where(predicate: (v: T) => boolean): T[] {
        return Array
            .from(this.storage.values())
            .filter(predicate);
    }
    @action
    setMany(values: T[]): void {
        for(const value of values) this.storage.set(value.id, value); 
    }
    @action
    addMany(values: T[]): void {
        for(const value of values) {
            if(!this.storage.has(value.id)) this.storage.set(value.id, value);
        }
    }
    @action
    deleteMany(values: Pick<T, 'id'>[]): void {
        for(const value of values) {
            this.storage.delete(value.id);
        }
    }

}