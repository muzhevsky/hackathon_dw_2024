/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { GroupDto } from '../models/GroupDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class InstituteStructureService {
    /**
     * @returns GroupDto Success
     * @throws ApiError
     */
    public static getGroups(): CancelablePromise<GroupDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/groups',
        });
    }
    /**
     * @returns GroupDto Success
     * @throws ApiError
     */
    public static getDepartments(): CancelablePromise<GroupDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/departments',
        });
    }
    /**
     * @returns GroupDto Success
     * @throws ApiError
     */
    public static getInstitutes(): CancelablePromise<GroupDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/institutes',
        });
    }
    /**
     * @returns GroupDto Success
     * @throws ApiError
     */
    public static getSpecialities(): CancelablePromise<GroupDto> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/specialities',
        });
    }
}
