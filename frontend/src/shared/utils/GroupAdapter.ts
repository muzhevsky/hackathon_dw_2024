export class GroupAdapter{
    public static GetCourse(groupTitle: string){
        return groupTitle.replace(/ /g,'')[groupTitle.length - 2];
    }
}