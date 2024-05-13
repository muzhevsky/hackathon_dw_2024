export interface Student{
    type: "student";
    userId: number | string;
    studentId: number | string;
    groupId:  number | string;
    tgTag : string;
}

export const testStudent: Student = {
    type: "student",
    userId: "1",
    studentId: "1",
    groupId: "1",
    tgTag: ""
}