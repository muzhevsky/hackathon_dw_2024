import { Button } from "antd";
import { SizeType } from "antd/es/config-provider/SizeContext";
import styles from './PrimaryButton.module.css'

interface PrimaryButtonProps{
    content: string;
    clickHandler: () => void;
    size: SizeType;
    disabled?: boolean;
}

const PrimaryButton: React.FC<PrimaryButtonProps> = ({content, size, clickHandler, disabled}) => {
    return(
        <Button type="primary" disabled={disabled} className={"ButtonLog"} size={size} onClick={clickHandler}>{content}</Button>
    )
}

export default PrimaryButton;