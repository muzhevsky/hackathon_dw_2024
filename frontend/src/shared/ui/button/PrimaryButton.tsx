import { Button } from "antd";
import { SizeType } from "antd/es/config-provider/SizeContext";

interface PrimaryButtonProps{
    content: string;
    clickHandler: () => void;
    size: SizeType;
}

const PrimaryButton: React.FC<PrimaryButtonProps> = ({content, size, clickHandler}) => {
    return(
        <Button type="primary" size={size} onClick={clickHandler}>{content}</Button>
    )
}

export default PrimaryButton;