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

export const CustomerRegister: React.FC = () => {
    const { HandleRegister } = useRegister();
    const { HandleCustomerRegisterCancel } = useMenuItem();

    return (
        <Form
            onFinish={HandleRegister}
            style={{ maxWidth: 600 }}
            labelCol={{ flex: '110px' }}
            wrapperCol={{ flex: 1 }}
            scrollToFirstError
            labelAlign="left"
            colon={false}
            className='form-register-container'
        >
            <React.Fragment>
                <Title level={3} className="title-label">Register</Title>
            </React.Fragment>

            <Flex gap='middle'>
                <Form.Item label='First Name'>
                    <Form.Item
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
                    <Form.Item
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
                    <Form.Item
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
                    <Form.Item
                        name="gender"
                        rules={[{ required: true, message: 'Please select gender!' }]}
                        className='Form-Register-Container'
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
                    <Form.Item
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
                    <Form.Item
                        name="address"
                        rules={[{ required: true, message: 'Please input your address!' }]}
                        hasFeedback
                        className='Form-Register-Container'
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>

                <Form.Item label='Phonenumber'>
                    <Form.Item
                        name="phone"
                        rules={[{ required: true, message: 'Please input your phone number!' }]}
                        hasFeedback
                        className='Form-Register-Container'
                    >
                        <Input style={{ width: '265px' }} />
                    </Form.Item>
                </Form.Item>
            </Flex>

            <Form.Item>
                <Flex gap='middle'>
                    <Button type="primary" htmlType="submit" className='register-content-button'>
                        Register
                    </Button>
                    <Button type="default" className='register-cancel-button' onClick={HandleCustomerRegisterCancel}>
                        Cancel
                    </Button>
                </Flex>
            </Form.Item>
        </Form>
    );
}

export const SupplierRegister: React.FC = () => {
    return (
        <div>SupplierScreen</div>
    )
}

