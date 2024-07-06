import {
    Button,
    Flex,
    Form,
    Input,
    Radio,
} from 'antd';
import { useRegister } from '../../hooks/useRegister';
import '../AuthComponents/RegisterScreen.css';
import Title from 'antd/es/typography/Title';
import React from 'react';
import { useMenuItem } from '../../hooks/useMenuItem';
import { SupplierRegisterProps } from '../../models/types/RegisterType';
import Dragger from 'antd/es/upload/Dragger';
import { InboxOutlined } from '@ant-design/icons';
import { uploadProps } from '../../utils/uploadConfig';
import { CustomersRegister, SuppliersRegister } from '../../models/Register';

export const CustomerRegister: React.FC = () => {
    const { HandleCustomerRegister, form, isLoading } = useRegister();
    const { HandleCustomerRegisterCancel } = useMenuItem();

    return (
        <Form
            className='form-customer-container'
            onFinish={HandleCustomerRegister}
            style={{ maxWidth: 600 }}
            labelCol={{ flex: '110px' }}
            wrapperCol={{ flex: 1 }}
            scrollToFirstError
            labelAlign="left"
            colon={false}
            form={form}
        >
            <React.Fragment>
                <Title level={3} className="title-register-customer">Register</Title>
            </React.Fragment>

            <Flex gap='middle'>
                <Form.Item label='First Name'>
                    <Form.Item<CustomersRegister>
                        name="firstName"
                        label="First Name"
                        rules={[
                            {
                                required: true,
                                message: 'Please input your first name!',
                            },
                        ]}
                        hasFeedback
                        noStyle
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>

                <Form.Item label='Last Name'>
                    <Form.Item<CustomersRegister>
                        name="lastName"
                        rules={[
                            {
                                required: true,
                                message: 'Please input your last name!',
                            },
                        ]}
                        hasFeedback
                        noStyle
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Flex gap='middle'>
                <Form.Item label='E-mail'>
                    <Form.Item<CustomersRegister>
                        name="email"
                        rules={[
                            {
                                type: 'email',
                                message: 'The input is not valid E-mail!',
                            },
                            {
                                required: true,
                                message: 'Please input your E-mail!',
                            },
                        ]}
                        hasFeedback
                        noStyle
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>

                <Form.Item label='Gender'>
                    <Form.Item<CustomersRegister>
                        name="gender"
                        rules={[{ required: true, message: 'Please select gender!' }]}
                        hasFeedback
                        noStyle
                    >
                        <Radio.Group buttonStyle="solid">
                            <Radio.Button
                                value="Female"
                                style={{ width: '70px' }}
                            >
                                Female
                            </Radio.Button>
                            <Radio.Button
                                value="Male"
                            >
                                Male
                            </Radio.Button>
                            <Radio.Button
                                value="Prefer not to say"
                            >
                                Prefer not to say
                            </Radio.Button>
                        </Radio.Group>
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Flex gap='middle'>
                <Form.Item label='Password'>
                    <Form.Item<CustomersRegister>
                        name="password"
                        rules={[
                            {
                                required: true,
                                message: 'Please input your password!',
                            },
                        ]}
                        hasFeedback
                        noStyle
                    >
                        <Input.Password style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>

                <Form.Item label='Confirm Pass'>
                    <Form.Item
                        name="confirmPassword"
                        dependencies={['password']}
                        hasFeedback
                        rules={[
                            {
                                required: true,
                                message: 'Please confirm your password!',
                            },
                            ({ getFieldValue }) => ({
                                validator(_, value) {
                                    if (!value || getFieldValue('password') === value) {
                                        return Promise.resolve();
                                    }
                                    return Promise.reject(new Error('The new password that you entered do not match!'));
                                },
                            }),
                        ]}
                        noStyle
                    >
                        <Input.Password style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Flex gap='middle'>
                <Form.Item label='Address'>
                    <Form.Item<CustomersRegister>
                        name="address"
                        rules={[{ required: true, message: 'Please input your address!' }]}
                        hasFeedback
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>

                <Form.Item label='Phonenumber'>
                    <Form.Item<CustomersRegister>
                        name="phoneNumber"
                        rules={[{ required: true, message: 'Please input your phone number!' }]}
                        hasFeedback
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Flex gap='middle'>
                <Form.Item label='Company Name'>
                    <Form.Item<CustomersRegister>
                        name="companyName"
                        rules={[{ required: true, message: 'Please input your company name!' }]}
                        hasFeedback
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Form.Item>
                <Flex gap='middle'>
                    <Button type="primary" htmlType="submit" className='register-content-customer' loading={isLoading}>
                        Register
                    </Button>
                    <Button type="default" className='register-cancel-customer' onClick={HandleCustomerRegisterCancel}>
                        Cancel
                    </Button>
                </Flex>
            </Form.Item>
        </Form>
    );
}

export const SupplierRegister: React.FC<SupplierRegisterProps> = ({ randomNumber }) => {
    const { HandleSupplierRegister, form, isLoading } = useRegister();
    const { HandleSupplierRegisterCancel } = useMenuItem();
    
    return (
        <Form
            className='form-supplier-container'
            onFinish={HandleSupplierRegister}
            style={{ maxWidth: 600 }}
            labelCol={{ flex: '110px' }}
            wrapperCol={{ flex: 1 }}
            scrollToFirstError
            labelAlign="left"
            colon={false}
            form={form}
            initialValues={{ supplierId: randomNumber }}
        >
            <React.Fragment>
                <Title level={3} className="title-register-supplier">Register</Title>
            </React.Fragment>

            <Flex gap='middle'>
                <Form.Item label='Supplier ID'>
                    <Form.Item<SuppliersRegister>
                        name="supplierId"
                        noStyle
                    >
                        <Input
                            variant="borderless"
                            style={{ width: '265px' }}
                            disabled
                        />
                    </Form.Item>
                </Form.Item>

                <Form.Item label='Company Name'>
                    <Form.Item<SuppliersRegister>
                        name="companyName"
                        rules={[
                            {
                                required: true,
                                message: 'Please input your last name!',
                            },
                        ]}
                        hasFeedback
                        noStyle
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Flex gap='middle'>
                <Form.Item label='E-mail'>
                    <Form.Item<SuppliersRegister>
                        name="email"
                        rules={[
                            {
                                type: 'email',
                                message: 'The input is not valid E-mail!',
                            },
                            {
                                required: true,
                                message: 'Please input your E-mail!',
                            },
                        ]}
                        hasFeedback
                        noStyle
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>

                <Form.Item label='Business Lic. No.'>
                    <Form.Item<SuppliersRegister>
                        name="bizLicenseNumber"
                        rules={[{ required: true, message: 'Please input your business license number!' }]}
                        hasFeedback
                        noStyle
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Flex gap='middle'>
                <Form.Item label='Address'>
                    <Form.Item<SuppliersRegister>
                        name="address"
                        rules={[{ required: true, message: 'Please input your address!' }]}
                        hasFeedback
                        noStyle
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>

                <Form.Item label='Phonenumber'>
                    <Form.Item<SuppliersRegister>
                        name="phoneNumber"
                        rules={[{ required: true, message: 'Please input your phone number!' }]}
                        hasFeedback
                        noStyle
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Flex gap='middle'>
                <Form.Item label='Password'>
                    <Form.Item<SuppliersRegister>
                        name="password"
                        rules={[
                            {
                                required: true,
                                message: 'Please input your password!',
                            },
                        ]}
                        hasFeedback
                        noStyle
                    >
                        <Input.Password style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>

                <Form.Item label='Confirm Pass'>
                    <Form.Item
                        name="confirmPassword"
                        dependencies={['password']}
                        rules={[
                            {
                                required: true,
                                message: 'Please confirm your password!',
                            },
                            ({ getFieldValue }) => ({
                                validator(_, value) {
                                    if (!value || getFieldValue('password') === value) {
                                        return Promise.resolve();
                                    }
                                    return Promise.reject(new Error('The new password that you entered do not match!'));
                                },
                            }),
                        ]}
                        hasFeedback
                        noStyle
                    >
                        <Input.Password style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Flex gap='middle'>
                <Form.Item<SuppliersRegister>
                    name="document"
                    rules={[{ 
                        required: true, message: 'Please upload an image.' 
                    }]}
                    valuePropName="fileList"
                    getValueFromEvent={(e) => {
                        if (Array.isArray(e)) {
                            return e;
                        } 
                        return e && e.fileList;
                    }}
                >
                    <Dragger {...uploadProps} listType='picture'>
                        <p className="ant-upload-drag-icon">
                            <InboxOutlined />
                        </p>
                        <p className="ant-upload-text">
                            Click or drag file to this area to upload
                        </p>
                        <p className="ant-upload-hint">
                            Please upload your document(s) here. Please ensure that you only upload the required documents and refrain from uploading any prohibited files.
                        </p>
                    </Dragger>
                </Form.Item>
            </Flex> 

            <Form.Item>
                <Flex gap='middle'>
                    <Button type="primary" htmlType="submit" className='register-content-supplier' loading={isLoading}>
                        Register
                    </Button>
                    <Button type="default" className='register-cancel-supplier' onClick={HandleSupplierRegisterCancel}>
                        Cancel
                    </Button>
                </Flex>
            </Form.Item>
        </Form>
    )
}

