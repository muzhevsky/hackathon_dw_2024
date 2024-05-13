import { Group } from "antd/es/avatar";

export interface Group{
    id: number | string;
    departamentId: number | string;
    title: string;
}

export const testGroup: Group = {
    id: "1",
    departamentId: "1",
    title: "Б2-ИФСТ-41"
}