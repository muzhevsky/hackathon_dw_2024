/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Achievement } from '../models/Achievement';
import type { AchievementSetRequest } from '../models/AchievementSetRequest';
import type { AddConnectedAchievementRequest } from '../models/AddConnectedAchievementRequest';
import type { AddCustomAchievementRequest } from '../models/AddCustomAchievementRequest';
import type { StudentBasicDataResponse } from '../models/StudentBasicDataResponse';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class StudentService {
    /**
     * @param formData
     * @returns any Success
     * @throws ApiError
     */
    public static postAchievementAttach(
        formData?: {
            File?: Blob;
        },
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/achievement/attach',
            formData: formData,
            mediaType: 'multipart/form-data',
        });
    }
    /**
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static postAchievementConnected(
        requestBody?: AddConnectedAchievementRequest,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/achievement/connected',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static postAchievementCustom(
        requestBody?: AddCustomAchievementRequest,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/achievement/custom',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @returns Achievement Success
     * @throws ApiError
     */
    public static getAchievements(): CancelablePromise<Array<Achievement>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/student/achievements',
        });
    }
    /**
     * @param requestBody
     * @returns any Success
     * @throws ApiError
     */
    public static postRequest(
        requestBody?: AchievementSetRequest,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/request',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param id
     * @returns StudentBasicDataResponse Success
     * @throws ApiError
     */
    public static getStudent(
        id?: number,
    ): CancelablePromise<StudentBasicDataResponse> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/student',
            query: {
                'id': id,
            },
        });
    }
    /**
     * @param eventId
     * @returns any Success
     * @throws ApiError
     */
    public static postEventSubscribe(
        eventId?: number,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/event/subscribe',
            query: {
                'eventId': eventId,
            },
        });
    }
    /**
     * @param eventId
     * @returns any Success
     * @throws ApiError
     */
    public static postEventUnsubscribe(
        eventId?: number,
    ): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/event/unsubscribe',
            query: {
                'eventId': eventId,
            },
        });
    }
}
