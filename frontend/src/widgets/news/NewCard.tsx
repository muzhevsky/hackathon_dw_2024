import { New } from "../../entities/new/New";

interface NewCardProps{
    newInfo: New;
}

const NewCard: React.FC<NewCardProps> = ({newInfo}) => {
    return(
        <div>
            <p>{newInfo.title}</p>
            <p>{newInfo.content}</p>
            <p>{newInfo.publicationDate.toLocaleDateString()}</p>
        </div>
    )
}

export default NewCard;