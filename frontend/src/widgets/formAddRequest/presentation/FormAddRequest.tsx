import { Button, Form, Input, Select, Space } from "antd";
import { useForm } from "react-hook-form";
import DefaultController from "../../../shared/hook-form-tools/DefaultController";
import PrimaryButton from "../../../shared/ui/button/PrimaryButton";
import { useContext, useMemo } from "react";
import { Context } from "../../..";
import { observer } from "mobx-react-lite";
import { ALL_SELECT } from "../../../shared/utils/baseCollection";
import { LabeledValue } from "antd/es/select";
import { Group } from "../../../entities/group/Group";
import { AddRequestFormViewModel } from "./AddRequestFormViewModel";
import { RequestStatus } from "../../../shared/utils/RequestStatus";

interface AddRequestFormData {
    description: string,
    groupId: number,
    resultId: number,
    eventId: number
}

type GroupOption = LabeledValue & { group: Group };

export const FormAddRequest: React.FC = observer(() => {

    const addRequestFormApi = useForm<AddRequestFormData>();

    const addRequestFormModel = useMemo(() => new AddRequestFormViewModel(), [])

    const { control, handleSubmit } = addRequestFormApi;

    const { groupRepository, eventRepository, eventResiltRepository } = useContext(Context);

    const groupOptions = useMemo<GroupOption[]>(() => groupRepository.isLoaded
        ? groupRepository.where(ALL_SELECT).map(group => ({
            key: group.id.toString(),
            label: group.title,
            group: group,
            value: group.id
        }))
        : [],
        [groupRepository.isLoaded])

    const eventsOptions = useMemo<LabeledValue[]>(() => eventRepository.isLoaded
        ? eventRepository
            .where(ALL_SELECT)
            .map(v => ({
                key: v.id.toString(),
                label: v.title,
                value: v.id,
            }))
        : [],
        [eventRepository.isLoaded]);

    const eventResultOptions = useMemo<LabeledValue[]>(() => eventResiltRepository.isLoaded
        ? eventResiltRepository.where(ALL_SELECT).map(
            v => ({
                key: v.id.toString(),
                label: v.title,
                value: v.id,
            }))
        : [],
        [eventResiltRepository.isLoaded]);


    return (
        <Form onFinish={
            handleSubmit((from) => addRequestFormModel.createQuest({
                resultId: from.resultId,
                groupId: from.groupId,
                desctiption: from.description,
                eventId: from.eventId
            }))
        }>
            <Space size={10} direction='vertical'>
                <DefaultController
                    control={control}
                    name='description'
                    render={
                        ({ field }) => <Input {...field} />
                    }
                />
                <DefaultController
                    control={control}
                    name='groupId'
                    render={
                        ({ field }) => <Select
                            {...field}
                            style={{ width: '100%' }}
                            labelInValue
                            options={groupOptions}
                            loading={groupRepository.isLoading}
                        />
                    }
                />
                <DefaultController
                    control={control}
                    name='eventId'
                    render={
                        ({ field }) => <Select
                            {...field}
                            style={{ width: '100%' }}
                            labelInValue
                            options={eventsOptions}
                            loading={eventRepository.isLoading}
                        />
                    }
                />
                <DefaultController
                    control={control}
                    name='resultId'
                    render={
                        ({ field }) => <Select
                            {...field}
                            style={{ width: '100%' }}
                            labelInValue
                            options={eventResultOptions}
                            loading={eventResiltRepository.isLoading}
                        />
                    }
                />
                <PrimaryButton
                    content={addRequestFormModel.createStatus == RequestStatus.LOADING ? 'Загрузка' : "Отправить"}
                    disabled={addRequestFormModel.createStatus == RequestStatus.LOADING}
                    clickHandler={() => { }}
                    size='large'
                    htmlType='submit'
                />
            </Space>

        </Form>

    );
})