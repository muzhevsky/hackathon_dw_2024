/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { DepartmentDto } from '../models/DepartmentDto';
import type { GroupDto } from '../models/GroupDto';
import type { InstituteDto } from '../models/InstituteDto';
import type { SpecialityDto } from '../models/SpecialityDto';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class InstituteStructureService {
    /**
     * @returns GroupDto Success
     * @throws ApiError
     */
    public static getGroups(): CancelablePromise<Array<GroupDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/groups',
        });
    }
    /**
     * @returns DepartmentDto Success
     * @throws ApiError
     */
    public static getDepartments(): CancelablePromise<Array<DepartmentDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/departments',
        });
    }
    /**
     * @returns InstituteDto Success
     * @throws ApiError
     */
    public static getInstitutes(): CancelablePromise<Array<InstituteDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/institutes',
        });
    }
    /**
     * @returns SpecialityDto Success
     * @throws ApiError
     */
    public static getSpecialities(): CancelablePromise<Array<SpecialityDto>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/specialities',
        });
    }
}
