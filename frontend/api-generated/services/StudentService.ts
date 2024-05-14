/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Achievement } from '../models/Achievement';
import type { AddConnectedAchievementRequest } from '../models/AddConnectedAchievementRequest';
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
     * @returns Achievement Success
     * @throws ApiError
     */
    public static getAchievements(): CancelablePromise<Array<Achievement>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/achievements',
        });
    }
    /**
     * @returns any Success
     * @throws ApiError
     */
    public static postRequest(): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/request',
        });
    }
    /**
     * @returns StudentBasicDataResponse Success
     * @throws ApiError
     */
    public static getStudent(): CancelablePromise<StudentBasicDataResponse> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/student',
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
