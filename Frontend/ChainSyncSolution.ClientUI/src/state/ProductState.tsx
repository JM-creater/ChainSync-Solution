import { createContext, useState } from "react";
import { ProductContextType, ProductProps } from "../models/types/ProductType";
import { Form, FormProps } from "antd";
import { CreateProduct } from "../models/Product";
import { createProduct } from "../services/ProductService";
import { showFailedToast, showSuccessToast } from "../utils";
import { useDrawer } from "../hooks/useDrawer";

export const ProductContext = createContext<ProductContextType | null>(null);

export const ProductProvider: React.FC<ProductProps> = ({ children }) => {
    
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const { closeDrawer } = useDrawer();
    const [form] = Form.useForm(); 

    const onFinishCreateProduct: FormProps<CreateProduct>['onFinish'] = async (values) => {
        setIsLoading(true);

        try {
            const formData = new FormData();

            Object.entries(values).forEach(([key, value]) => {
                if (key !== 'productImage' && value !== undefined) {
                    formData.append(key, value.toString());
                }
            })

            if (values.productImage && values.productImage.length > 0) {
                const file = values.productImage[0].originFileObj;
                if (file) {
                    formData.append('productImage', file);
                }
            }

            const response = await createProduct(formData);
            
            if (response.status === 200) {
                form.resetFields();
                showSuccessToast(`The ${values.productName} Successfully Created.`);
                closeDrawer();
            } else {
                showFailedToast(response.data.message || "Failed to Register.");
            }
        } catch (error) {
            console.log(error);
        } finally {
            setIsLoading(false);
        }
    };

    const onFinishFailed: FormProps<CreateProduct>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    const HandleValue = {
        form,
        isLoading,
        onFinishCreateProduct,
        onFinishFailed
    };

    return (
        <ProductContext.Provider value={HandleValue}>
            {children}
        </ProductContext.Provider>
    )
}