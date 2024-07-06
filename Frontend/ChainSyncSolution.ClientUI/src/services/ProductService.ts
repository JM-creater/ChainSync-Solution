import { AxiosError } from "axios";
import { ErrorResponseData } from "../models/errors/ErrorResponseData";
import apiClient from "../api/apiClient";

export const createProduct = async (createProductData: FormData) => {
    try {
        const response = await apiClient.post('/api/v1/Product/create-product', createProductData, {
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