import { Select } from "antd";

export interface ItemSelect {
    value: string;
    label: string;
    disabled?: boolean;
}

interface CustomizeSelectProps {
    items: ItemSelect[];
    handleChange: (value: string) => void;
    defaultValue?: string;
}

const CustomizeSelect: React.FC<CustomizeSelectProps> = ({items, handleChange, defaultValue}) => {
    return (
        <Select
            defaultValue={items.find(item => item.value === defaultValue)?.value ?? items[0].value}
            onChange={handleChange}
            options={items}
        />
    )
}

export default CustomizeSelect;