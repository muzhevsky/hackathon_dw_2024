import { Button, Input, Space } from "antd";
import { useForm } from "react-hook-form";
import DefaultController from "../../../shared/hook-form-tools/DefaultController";
import PrimaryButton from "../../../shared/ui/button/PrimaryButton";

interface AddRequestFormData {
    description: string,
    groupId: number,
    resultId: number,
    eventId: number
}

const FormAddRequest: React.FC = () => {

    const addRequestFormApi = useForm<AddRequestFormData>();

    const {control, setValue} = addRequestFormApi;

    

    
    return (
        <Space size={10}>
            <DefaultController 
                control={control}
                name='description'
                render={
                    ({field}) => <Input {...field}/>
                }
            />
            <PrimaryButton content="Добавить" clickHandler={() => {}} size='middle' />
        </Space>
    );
}