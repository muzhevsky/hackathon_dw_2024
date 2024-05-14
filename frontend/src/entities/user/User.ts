export interface User{
    id: number | string;
    login: string;
    surname: string;
    name: string;
    patronomyc: string | null;
    password_hash: string;
    role_id: number;
}

export const testUser: User = {
    id: "1",
    login: "katya_yuneva@mail.ru",
    surname: "Юнева",
    name: "Екатерина",
    patronomyc: "Петровна",
    password_hash: "123456",
    role_id: 4
}