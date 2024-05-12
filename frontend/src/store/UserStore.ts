import { makeAutoObservable } from "mobx";

class UserStore{
    private _activeToken: string | null = null;
    private _isAuth: boolean = false;

    constructor() {
        makeAutoObservable(this);
    }

    get activeToken() {
        return this._activeToken;
    }

    set activeToken(token: string | null){
        this._activeToken = token;
    }

    get isAuth() {
        return this._isAuth;
    }

    set isAuth(isAuth: boolean){
        this._isAuth = isAuth;
    }
}

export default UserStore;