import { Departament, testDepartament } from "../entities/departament/Departament";
import $api, { API_URL } from "../shared/utils/Api";

class DepartamentService{
    public static async GetDepartamentById(id: number | string): Promise<Departament>{
        // return (await $api.get(`${API_URL}/departament/${id}`)).data;
        return testDepartament
    }
}

export default DepartamentService;