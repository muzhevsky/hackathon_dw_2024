import { makeAutoObservable } from "mobx";
import { UserResponseAuth } from "../dto/auth/AuthResponse";
import { Departament } from "../entities/departament/Departament";
import { Institute } from "../entities/institute/Institute";
import { Role } from "../entities/role/Role";
import { Student } from "../entities/student/Student";
import { Teacher } from "../entities/teacher/Teacher";
import { User } from "../entities/user/User";
import { OpenAPI } from "../api-generated";

class UserStore {
    private _activeToken: string | null = null;
    private _isAuth: boolean = false;
    //TODO исправить начальное положение на null
    private _activeRole: string | null = null;
    private _user: UserResponseAuth | null = null;
    private _activeUserRole: Student | Teacher | Departament | null = null;
    private _departament: Departament | null = null;
    private _institute: Institute | null = null;

    constructor() {
        makeAutoObservable(this);
    }

    get activeToken() {
        return this._activeToken;
    }

    set activeToken(token: string | null) {
        this._activeToken = token;
        OpenAPI.TOKEN = token ?? '';
    }

    get isAuth() {
        return this._isAuth;
    }

    set isAuth(isAuth: boolean) {
        this._isAuth = isAuth;
    }

    get activeRole() {
        return this._activeRole;
    }

    set activeRole(activeRole: string | null) {
        this._activeRole = activeRole;
    }

    get user() {
        return this._user;
    }

    set user(user: UserResponseAuth | null) {
        this._user = user;
    }

    get activeUserRole() {
        return this._activeUserRole;
    }

    set activeUserRole(activeUserRole: Student | Teacher | Departament | null) {
        this._activeUserRole = activeUserRole;
    }

    get departament() {
        return this._departament;
    }

    set departament(departament: Departament | null) {
        this._departament = departament;
    }

    get institute() {
        return this._institute;
    }

    set institute(institute: Institute | null) {
        this._institute = institute;
    }
}

export default UserStore;