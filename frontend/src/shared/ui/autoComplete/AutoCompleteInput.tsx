import { AutoComplete } from "antd";
import { useEffect, useState } from "react";
import { EventForCabinet } from "../../../entities/event/EventForCabinet";

interface AutoCompleteInputProps{
	items: EventForCabinet[];
	onSelectHandler: (str?: EventForCabinet) => void;
	placeholder: string;
	defaultValue: string;
	changeHandler: (e: string) => void;
}

const AutoCompleteInput: React.FC<AutoCompleteInputProps> = ({items, onSelectHandler, placeholder, defaultValue, changeHandler}) => {
	const [value, setValue] = useState(defaultValue);
	const [options, setOptions] = useState<{ value: string }[]>([]);

	const sortItems = (searchText: string) => {
		return items.filter(item => item.title.toLocaleLowerCase().includes(searchText.toLocaleLowerCase()));
	}

	const getPanelValue = (searchText: string) =>
		!searchText ? [] : sortItems(searchText);

	const onSelect = (data: string) => {
		console.log('onSelect', data);
		onSelectHandler(items.find(item => item.title === value));
	};

	const onChange = (data: string) => {
		setValue(data);
		changeHandler(data);
	};

	return (
		<AutoComplete
			value={value}
			options={options}
			style={{ width: "100%" }}
			onSelect={onSelect}
			onSearch={(text) => setOptions(getPanelValue(text).map(i => { return { value: i.title }}))}
			onChange={onChange}
			placeholder={placeholder}
		/>
	);
}

export default AutoCompleteInput;