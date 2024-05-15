import { makeAutoObservable } from "mobx";

class ScholarshipStore{
    private _idsScholar: number[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    get idsScholar() {
        return this._idsScholar;
    }

    set idsScholar(events: number[]){
        this._idsScholar = events;
    }
}

export default ScholarshipStore;