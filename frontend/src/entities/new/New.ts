export interface New{
    type: "new";
    id: number;
    title: string;
    publicationDate: Date;
    content: string;
    imageUrl: string;
}