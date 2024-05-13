import { User } from "../../entities/user/User";

export interface AuthResponse{
    token: string;
    user: User;
}