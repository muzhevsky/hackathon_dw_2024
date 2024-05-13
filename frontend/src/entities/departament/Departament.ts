export interface Departament{
    type: "departament";
    id: number | string;
    instituteId: number | string;
    title: string;
}

export const testDepartament: Departament = {
    type: "departament",
    id: "1",
    instituteId: "1",
    title: "Деканат ИНПИТ"
}