export interface User{
    id: number | string;
    login: string;
    surname: string;
    name: string;
    patronymic: string | null;
    role: string;
}

export const testUser: User = {
    id: "1",
    login: "katya_yuneva@mail.ru",
    surname: "Юнева",
    name: "Екатерина",
    patronymic: "Петровна",
    role: "student"
}