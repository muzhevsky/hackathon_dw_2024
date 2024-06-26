import { useState } from "react";

export const useInput = (str?: string) => {
    const [value, setValue] = useState<string>(str ?? "");

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setValue(event.target.value);
    }

    return{
        value,
        onChange: handleChange
    };
};

export default useInput;