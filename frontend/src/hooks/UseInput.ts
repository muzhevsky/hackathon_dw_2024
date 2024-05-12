import { useState } from "react";

export const useInput = () => {
    const [value, setValue] = useState<string>('');

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setValue(event.target.value);
    }

    return{
        value,
        onChange: handleChange
    };
};

export default useInput;