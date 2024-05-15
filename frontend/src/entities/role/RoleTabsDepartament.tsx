import { TabsProps } from "antd";
import { DOCUMENT_VERIFICATION_PATH, EVENTS_PATH, SUGGESTIONS_PATH } from "../../routing/RouterConstants";

export const itemsDepartament: TabsProps['items'] = [
    {
        key: '1',
        label: 'Мои предложения',
        children: '',
    },
    {
        key: '2',
        label: 'Мероприятия',
        children: '',
    },
    {
        key: '3',
        label: 'Проверка документов на стипенжию',
        children: '',
    }
];

export const itemsNavigateDepartament: string[] = [
    SUGGESTIONS_PATH,
    EVENTS_PATH,
    DOCUMENT_VERIFICATION_PATH
]