import { action, computed, makeAutoObservable, observable, runInAction } from "mobx";
import { ALL_SELECT, BaseCollection } from "./baseCollection";
import { WithId, ICollection } from "./iCollection";
import { RequestStatus } from "./RequestStatus";
import { CancelablePromise } from "../../api-generated";

export class BaseApiCollection<T extends WithId, TRespose> extends BaseCollection<T> {

    @observable
    private _requestStatus: RequestStatus = RequestStatus.NEVER;
    private _error?: string;

    @computed
    get error() {
        return this._error;
    }

    @computed
    get isLoaded() {
        return this._requestStatus == RequestStatus.SUCCESSFUL;
    }

    @computed
    get isLoading() {
        return this._requestStatus == RequestStatus.LOADING;
    }


    @action
    load = async (request: () => Promise<Array<TRespose>> | CancelablePromise<Array<TRespose>>, adapter: (res: TRespose) => Promise<T>): Promise<T[]> => {
        if (this._requestStatus == RequestStatus.NEVER || this.error) {
            this._requestStatus = RequestStatus.LOADING;
            try {
                const res = await request();
                runInAction(async () => {
                    const adaptedValues = await Promise.all(res.map(v => adapter(v)));
                    this.setMany(adaptedValues);
                    this._requestStatus = RequestStatus.SUCCESSFUL;
                    return this.where(ALL_SELECT);
                })
            }
            catch (e) {
                return runInAction(() => {
                    this._requestStatus = RequestStatus.ERROR;
                    this._error = 'Что-то пошло не так'
                    return [];
                });

            }
        }
        return this.where(ALL_SELECT);
    }

}

// const isPromiseTypeOrType = <U, T>(adapter:  (res: U) => Promise<T> | T): value is T => {
//     return value instanceof Promise && typeof value.then === 'function';
// }

