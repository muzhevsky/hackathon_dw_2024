import { makeAutoObservable } from "mobx";
import { Role } from "../entities/role/Role";

class UserStore{
    private _activeToken: string | null = null;
    private _isAuth: boolean = false;
    //TODO исправить начальное положение на null
    private _activeRole: Role | null = {id: 4, title: "user"};

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

    get activeRole() {
        return this._activeRole;
    }

    set activeRole(activeRole: Role | null){
        this._activeRole = activeRole;
    }
}

export default UserStore;