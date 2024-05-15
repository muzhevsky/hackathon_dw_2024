import axios from "axios";
import { userStore } from "../..";

export const API_URL = 'http://localhost:8080';
export const FRONT_URL = 'http://localhost:3000';

const $api = axios.create({
    withCredentials: true,
    baseURL: API_URL
});

$api.interceptors.request.use((config) => {
    config.headers.Authorization = `Bearer ${userStore.activeToken}`;
    config.headers.Accept = 'application/json';
    return config;
});

export default $api;