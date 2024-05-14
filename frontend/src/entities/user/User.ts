export interface User{
    id: number | string;
    login: string;
    surname: string;
    name: string;
    patronymic: string | null;
    role: string;
}