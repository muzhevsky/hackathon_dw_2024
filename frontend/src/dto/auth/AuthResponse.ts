import { User } from "../../entities/user/User";

export interface AuthResponse{
    token: string;
    user: UserResponseAuth;
}

interface UserResponseAuth{
    id: number | string;
    surname: string;
    name: string;
    pathronomyc: string;
    role: number | string;
}