import { createContext, useCallback, useState } from "react";
import { ProductContextType, ProductProps } from "../models/types/ProductType";
import { Form, FormProps } from "antd";
import { CreateProduct, Product, UpdateProduct } from "../models/Product";
import { activateProduct, createProduct, deactivateProduct, deleteProductById, getProductsById, getProductsBySupplierId, searchProduct, updateProductsByProductId } from "../services/ProductService";
import { showFailedToast, showSuccessToast } from "../utils";
import { useDrawer } from "../hooks/useDrawer";

export const ProductContext = createContext<ProductContextType | null>(null);

export const ProductProvider: React.FC<ProductProps> = ({ children }) => {
    
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const { closeDrawer } = useDrawer();
    const [form] = Form.useForm(); 
    const [products, setProducts] = useState<Product[]>([]);
    const [selectedProducts, setSelectedProducts] = useState<Product | null>(null);
    // const [isActive, setIsActive] = useState<boolean>(true);

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
                const newProduct = response.data;
                setProducts(prevProduct => [...prevProduct, newProduct]);
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

    const onFinishUpdateFailed: FormProps<UpdateProduct>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };


    const fetchProductBySupplierId = useCallback(async (supplierId: string) => {
        const response = await getProductsBySupplierId(supplierId);
        if (response.status === 200) {
          setProducts(response.data);
        } else {
          console.error(response.data.message);
        }
    }, []);

    const fetchProductById = useCallback(async (productId: string) => {
        const response = await getProductsById(productId);
        if (response.status === 200) {
            setSelectedProducts(response.data);
        } else {
            console.error(response.data.message);
        }
    }, []);

    const onFinishUpdateProduct: FormProps<UpdateProduct>['onFinish'] = async (values) => {
        setIsLoading(true);
    
        try {
            const formData = new FormData();
            Object.entries(values).forEach(([key, value]) => {
                if (key !== 'productImage' && value !== undefined) {
                    formData.append(key, value.toString());
                }
            });
    
            if (values.productImage && values.productImage.length > 0) {
                const file = values.productImage[0].originFileObj;
                if (file) {
                    formData.append('productImage', file);
                }
            }
    
            if (selectedProducts) {
                const response = await updateProductsByProductId(selectedProducts.id, formData);
                if (response.status === 200) {
                    form.resetFields();
                    showSuccessToast(`The ${values.productName} was successfully updated.`);
                    closeDrawer();
                } else {
                    showFailedToast(response.data.message || "Failed to update.");
                }
            }
        } catch (error) {
            console.log(error);
        } finally {
            setIsLoading(false);
        }
    };

    const deleteProduct = async (productId: string) => {
        setIsLoading(true);
        try {
            const response = await deleteProductById(productId);
            if (response.status === 200) {
                setProducts((prevProducts) => prevProducts.filter(product => product.id !== productId));
                showSuccessToast('Product successfully deleted.');
            } else {
                showFailedToast(response.data.message || "Failed to delete product.");
            }
        } catch (error) {
            console.log(error);
        } finally {
            setIsLoading(false);
        }
    };

    const searchProductByName = useCallback(async (productName: string) => {
        const response = await searchProduct(productName);
        if (response.status === 200) {
            setProducts(response.data);
        } else {
            console.error(response.data.message);
        }
    }, []);

    const handleDeactivateActivateProduct = async (productId: string, currentStatus: boolean) => {
        try {
            const response = currentStatus ? await deactivateProduct(productId) : await activateProduct(productId);
            if (response.status === 200) {
                setProducts((prevProducts) =>
                    prevProducts.map((product) =>
                        product.id === productId ? { ...product, isActive: !currentStatus } : product
                    )
                );
                if (selectedProducts) {
                    setSelectedProducts({ ...selectedProducts, isActive: !currentStatus });
                }
            } else {
                showFailedToast(response.data.message || `Failed to ${currentStatus ? 'deactivate' : 'activate'} product.`);
            }
        } catch (error) {
            console.log(error);
        } finally {
            setIsLoading(false);
        }
    };


    const HandleValue = {
        form,
        isLoading,
        products,
        selectedProducts,
        onFinishCreateProduct,
        onFinishFailed,
        onFinishUpdateFailed,
        fetchProductBySupplierId,
        fetchProductById,
        onFinishUpdateProduct,
        deleteProduct,
        searchProductByName,
        handleDeactivateActivateProduct
    };

    return (
        <ProductContext.Provider value={HandleValue}>
            {children}
        </ProductContext.Provider>
    )
}