import axios from "axios";
import { AuthDto } from "../dto/auth/AuthDto";
import { API_URL } from "../shared/utils/Api";

class AuthService{
    public static async login(dto: AuthDto){
        return (await axios.post(`${API_URL}/signin`, dto)).data;
    }
}

export default AuthService;