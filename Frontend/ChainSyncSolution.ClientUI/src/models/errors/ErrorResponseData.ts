import { AxiosResponse } from "axios";

export interface ErrorResponseData {
    response?: AxiosResponse<unknown>;
    error?: string;
    status?: number;
    message?: string;
}