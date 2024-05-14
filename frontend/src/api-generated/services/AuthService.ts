/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { SignInRequest } from '../models/SignInRequest';
import type { SignInResponse } from '../models/SignInResponse';
import type { SignUpResponse } from '../models/SignUpResponse';
import type { StudentSignUpRequest } from '../models/StudentSignUpRequest';
import type { TeacherSignUpRequest } from '../models/TeacherSignUpRequest';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class AuthService {
    /**
     * @param requestBody
     * @returns SignUpResponse Success
     * @throws ApiError
     */
    public static postSignupStudent(
        requestBody?: StudentSignUpRequest,
    ): CancelablePromise<SignUpResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/signup/student',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param requestBody
     * @returns SignUpResponse Success
     * @throws ApiError
     */
    public static postSignupTeacher(
        requestBody?: TeacherSignUpRequest,
    ): CancelablePromise<SignUpResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/signup/teacher',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
    /**
     * @param requestBody
     * @returns SignInResponse Success
     * @throws ApiError
     */
    public static postSignin(
        requestBody?: SignInRequest,
    ): CancelablePromise<SignInResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/signin',
            body: requestBody,
            mediaType: 'application/json',
        });
    }
}
