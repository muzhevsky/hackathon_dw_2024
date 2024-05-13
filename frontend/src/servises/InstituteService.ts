import { Institute, testInstitute } from "../entities/institute/Institute";
import $api, { API_URL } from "../shared/utils/Api";

class InstituteService{
    public static async GetInstituteById(id: number | string): Promise<Institute>{
        // return (await $api.get(`${API_URL}/institute/${id}`)).data;
        return testInstitute;
    }
}

export default InstituteService;