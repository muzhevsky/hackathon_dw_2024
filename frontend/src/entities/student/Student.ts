export interface Student{
    type: "student";
    groupId: number;
    id: number;
    name: string;
    patronymic?: string;
    phoneNumber: string | null;
    studentId: string;
    surname: string;
    telegram: string | null;
    userId: number;
}

export interface StudentDto{
    groupId: number;
    id: number;
    name: string;
    patronymic?: string;
    phoneNumber: string | null;
    studentId: string;
    surname: string;
    telegram: string | null;
    userId: number;
}