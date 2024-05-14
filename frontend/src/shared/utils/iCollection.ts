
export interface WithId {
    id: string | number
}

export type IdTypePicker<T extends WithId> = T['id'];


export interface ICollection<T extends WithId> {
    getById(id: IdTypePicker<T>): T | null;
    where(predicate: (v: T) => boolean): T[];
    setMany(values: T[]): void;
    addMany(values: T[]): void;
    deleteMany(values: Pick<T, 'id'>[]): void;
} 