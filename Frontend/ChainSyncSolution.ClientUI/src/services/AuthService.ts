import { AxiosError } from "axios";
import apiClient from "../api/apiClient";
import { Login } from "../models/Login";
import { ErrorResponseData } from "../models/errors/ErrorResponseData";
import { CustomersRegister } from "../models/Register";

export const loginUser = async (userData: Login) => {
    try {
        const response = await apiClient.post('/auth/login', userData, {
            headers: {
                'Content-Type': 'application/json',
            },
        });
        return response;
    } catch (error) {
        const axiosError = error as AxiosError<ErrorResponseData>;
        return {
            status: axiosError.response?.status || 500,
            data: axiosError.response?.data || { message: 'Error! Something went wrong.' },
        };
    }
}

export const registerCstmr = async (customerData: CustomersRegister) => {
    try {
        const response = await apiClient.post('/auth/register', customerData, {
            headers: {
                'Content-Type': 'application/json',
            },
        });

        return response;
    } catch (error) {
        const axiosError = error as AxiosError<ErrorResponseData>;
        return {
            status: axiosError.response?.status || 500,
            data: axiosError.response?.data || { message: 'Error! Something went wrong.' },
        };
    }
}

export const registerSplr = async (supplierData: FormData) => {
    try {
        const response = await apiClient.post('/auth/register-supplier', supplierData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            },
        });

        return response;
    } catch (error) {
        const axiosError = error as AxiosError<ErrorResponseData>;
        return {
            status: axiosError.response?.status || 500,
            data: axiosError.response?.data || { message: 'Error! Something went wrong.' },
        };
    }
}

