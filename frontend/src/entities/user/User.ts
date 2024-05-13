export interface User{
    id: number | string;
    login: string;
    surname: string;
    name: string;
    pathronomyc: string | null;
    password_hash: string;
    role_id: number;
}

export const testUser: User = {
    id: "1",
    login: "katya_yuneva@mail.ru",
    surname: "Юнева",
    name: "Екатерина",
    pathronomyc: "Петровна",
    password_hash: "123456",
    role_id: 4
}