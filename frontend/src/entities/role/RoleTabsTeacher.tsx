import { TabsProps } from "antd";
import { EVENTS_PATH, SUGGESTIONS_PATH } from "../../routing/RouterConstants";

export const itemsTeacher: TabsProps['items'] = [
    {
        key: '1',
        label: 'Мои предложения',
        children: '',
    },
    {
        key: '2',
        label: 'Мероприятия',
        children: '',
    }
];

export const itemsNavigateTeacher: string[] = [
    SUGGESTIONS_PATH,
    EVENTS_PATH
]