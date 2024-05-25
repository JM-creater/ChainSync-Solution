import { AxiosError } from "axios";
import apiClient from "../api/apiClient";
import { Login } from "../models/Login";
import { ErrorResponseData } from "../models/errors/ErrorResponseData";

export const loginUser = async (userData: Login) => {
    try {
        const response = await apiClient.post('/auth/login', userData, {
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return response.data;
    } catch (error) { 
        return (error as AxiosError<ErrorResponseData>).message || 'Error! Something Went Wrong.';
    }
}