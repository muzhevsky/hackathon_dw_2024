import { Select } from "antd";

export interface ItemSelect {
    value: string;
    label: string;
    disabled?: boolean;
}

interface CustomizeSelectProps {
    items: ItemSelect[];
    handleChange: (value: string) => void;
}

const CustomizeSelect: React.FC<CustomizeSelectProps> = ({items, handleChange}) => {
    return (
        <Select
            defaultValue={items[0].value}
            onChange={handleChange}
            options={items}
        />
    )
}

export default CustomizeSelect;