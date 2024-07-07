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

export const getProductsBySupplierId = async (supplierId: string) => {
    try {
        const response = await apiClient.get(`/api/v1/Product/get-products-supplierId/${supplierId}`);
        return response;
    } catch (error) {
        const axiosError = error as AxiosError<ErrorResponseData>;
        return {
            status: axiosError.response?.status || 500,
            data: axiosError.response?.data || { message: 'Error! Something went wrong.' },
        };
    }
}

export const getProductsById = async (id: string) => {
    try {
        const response = await apiClient.get(`/api/v1/Product/get-products-id/${id}`);
        return response;
    } catch (error) {
        const axiosError = error as AxiosError<ErrorResponseData>;
        return {
            status: axiosError.response?.status || 500,
            data: axiosError.response?.data || { message: 'Error! Something went wrong.' },
        };
    }
}

export const updateProductsByProductId = async (productId: string, updateProductData: FormData) => {
    try {
        const response = await apiClient.put(`/api/v1/Product/update-products/${productId}`, updateProductData, {
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

export const deleteProductById = async (productId: string) => {
    try {
        const response = await apiClient.delete(`/api/v1/Product/delete-products/${productId}`);
        return response;
    } catch (error) {
        const axiosError = error as AxiosError<ErrorResponseData>;
        return {
            status: axiosError.response?.status || 500,
            data: axiosError.response?.data || { message: 'Error! Something went wrong.' },
        };
    }
}

export const searchProduct = async (productName: string) => {
    try {
        const response = await apiClient.get(`/api/v1/Search/search-products?productName=${productName}`);
        return response;
    } catch (error) {
        const axiosError = error as AxiosError<ErrorResponseData>;
        return {
            status: axiosError.response?.status || 500,
            data: axiosError.response?.data || { message: 'Error! Something went wrong.' },
        };
    }
}