export interface User{
    id: number | string;
    login: string;
    surname: string;
    name: string;
    pathronomyc: string | null;
    password_hash: string;
    role_id: number;
}