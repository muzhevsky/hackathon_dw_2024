import { User } from "../../entities/user/User";

export interface AuthResponse{
    token: string;
    user: UserResponseAuth;
}

export interface UserResponseAuth{
    id: number | string;
    surname: string;
    name: string;
    patronymic: string;
    role: string;
}