import { ToastOptions, toast } from "react-toastify";

export const showSuccessToast = (message: string, options?: ToastOptions): void => {
    toast.success(message, options);
};


export const showFailedToast = (message: string, options?: ToastOptions): void => {
    toast.error(message, options);
};