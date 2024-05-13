export interface Teacher{
    type: "teacher";
    userId: number | string;
    departamentId: number | string;
}

export const testTeacher: Teacher = {
    type: "teacher",
    userId: "1",
    departamentId: "1"
}