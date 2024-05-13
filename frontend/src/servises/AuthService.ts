import axios from "axios";
import { AuthDto } from "../dto/auth/AuthDto";
import { AuthResponse } from "../dto/auth/AuthResponse";
import { API_URL } from "../shared/utils/Api";

class AuthService{
    public static async login(dto: AuthDto): Promise<AuthResponse>{
        return (await axios.post<AuthResponse>(`${API_URL}/signin`, dto)).data;
    }
}

export default AuthService;