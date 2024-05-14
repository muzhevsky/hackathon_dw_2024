/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CreateQuestRequest } from '../models/CreateQuestRequest';
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
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/quest',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
}
