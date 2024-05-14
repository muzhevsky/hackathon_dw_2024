/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CreateQuestRequest } from '../models/CreateQuestRequest';
import type { QuestDto } from '../models/QuestDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class TeacherService {
    /**
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static postQuest(
        requestBody?: CreateQuestRequest,
    ): CancelablePromise<QuestDto> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/quest',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param id
     * @returns QuestDto Success
     * @throws ApiError
     */
    public static getQuest(
        id?: number,
    ): CancelablePromise<QuestDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/quest',
            query: {
                'id': id,
            },
        });
    }
    /**
     * @param groupId
     * @returns QuestDto Success
     * @throws ApiError
     */
    public static getGroupQuests(
        groupId?: number,
    ): CancelablePromise<Array<QuestDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/group/quests',
            query: {
                'groupId': groupId,
            },
        });
    }
    /**
     * @param eventId
     * @returns QuestDto Success
     * @throws ApiError
     */
    public static getEventQuests(
        eventId?: number,
    ): CancelablePromise<Array<QuestDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/event/quests',
            query: {
                'eventId': eventId,
            },
        });
    }
    /**
     * @param teacherId
     * @returns QuestDto Success
     * @throws ApiError
     */
    public static getTeacherQuests(
        teacherId?: number,
    ): CancelablePromise<Array<QuestDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/teacher/quests',
            query: {
                'teacherId': teacherId,
            },
        });
    }
}
