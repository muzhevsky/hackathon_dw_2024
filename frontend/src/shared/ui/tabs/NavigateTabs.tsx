import { Tabs, TabsProps } from "antd";
import { observer } from "mobx-react-lite";
import { useContext, useMemo } from "react";
import { useNavigate } from "react-router-dom";
import { Context } from "../../..";
import { itemsDepartament, itemsNavigateDepartament } from "../../../entities/role/RoleTabsDepartament";
import { itemsNavigateStudent, itemsStudent } from "../../../entities/role/RoleTabsStudent";
import { itemsNavigateTeacher, itemsTeacher } from "../../../entities/role/RoleTabsTeacher";
import { HOME_PATH } from "../../../routing/RouterConstants";
import styles from './NavigateTabs.module.css'


const NavigateTabs: React.FC = observer(() => {
    const navigate = useNavigate();
    const { userStore } = useContext(Context);

    const navigatePaths: string[] = useMemo(() => {
        switch(userStore.activeRole?.title){
            case "user":
                return itemsNavigateStudent;
            case "teacher": 
                return itemsNavigateTeacher;
            case "departament":
                return itemsNavigateDepartament;
            default:
                return [HOME_PATH];
        }
    }, [userStore.activeRole]);

    const items: TabsProps['items'] = useMemo(() => {
        switch(userStore.activeRole?.title){
            case "user":
                return itemsStudent;
            case "teacher": 
                return itemsTeacher;
            case "departament":
                return itemsDepartament;
        }
    }, [userStore.activeRole]);

    const onChange = (key: string) => {
        navigate(navigatePaths[Number(key) - 1]);
      };

    return(
        <Tabs defaultActiveKey="1" items={items} type={"card"} onChange={onChange} />
    )
})

export default NavigateTabs;