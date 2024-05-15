import { TabsProps } from "antd";
import { ACHIEVEMENTS_PATH, EVENTS_PATH, SCHOLARSHIP_PATH } from "../../routing/RouterConstants";

export const itemsStudent: TabsProps['items'] = [
    {
        key: '1',
        label: 'Мои достижения',
        children: null,
    },
    {
        key: '2',
        label: 'Мои мероприятия',
        children: '',
    },
    {
        key: '3',
        label: 'Заявки на стипендию',
        children: '',
    },
];

export const itemsNavigateStudent: string[] = [
    ACHIEVEMENTS_PATH,
    EVENTS_PATH,
    SCHOLARSHIP_PATH
]