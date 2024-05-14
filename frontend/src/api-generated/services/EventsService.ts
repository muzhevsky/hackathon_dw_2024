/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { EventDto } from '../models/EventDto';
import type { EventResultDto } from '../models/EventResultDto';
import type { EventStatusDto } from '../models/EventStatusDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class EventsService {
    /**
     * @returns EventStatusDto Success
     * @throws ApiError
     */
    public static getEventStatuses(): CancelablePromise<Array<EventStatusDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/event_statuses',
        });
    }
    /**
     * @param id
     * @returns EventStatusDto Success
     * @throws ApiError
     */
    public static getEventStatus(
        id?: number,
    ): CancelablePromise<EventStatusDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/event_status',
            query: {
                'id': id,
            },
        });
    }
    /**
     * @returns EventResultDto Success
     * @throws ApiError
     */
    public static getEventResults(): CancelablePromise<Array<EventResultDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/event_results',
        });
    }
    /**
     * @param id
     * @returns EventStatusDto Success
     * @throws ApiError
     */
    public static getEventResult(
        id?: number,
    ): CancelablePromise<EventStatusDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/event_result',
            query: {
                'id': id,
            },
        });
    }
    /**
     * @returns EventDto Success
     * @throws ApiError
     */
    public static getEvents(): CancelablePromise<Array<EventDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/events',
        });
    }
    /**
     * @returns EventDto Success
     * @throws ApiError
     */
    public static getMyEvents(): CancelablePromise<Array<EventDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/myEvents',
        });
    }
}
