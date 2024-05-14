/* generated using openapi-typescript-codegen -- do not edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { SignInRequest } from '../models/SignInRequest';
import type { SignInResponse } from '../models/SignInResponse';
import type { SignUpRequest } from '../models/SignUpRequest';
import type { SignUpResponse } from '../models/SignUpResponse';
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';
export class AuthService {
    /**
     * @param requestBody
     * @returns SignUpResponse Success
     * @throws ApiError
     */
    public static postSignup(
        requestBody?: SignUpRequest,
    ): CancelablePromise<SignUpResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/signup',
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
