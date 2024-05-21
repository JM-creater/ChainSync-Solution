import React from 'react'
import { Button, Form, Input } from 'antd';
import { User } from '../../models/User';
import { userLogin } from '../../hooks/UserLogin';


const LoginScreen: React.FC = () => {
    const { HandleLogin, onFinishFailed } = userLogin();

    return (
        <Form
            name="basic"
            style={{ maxWidth: 500 }}
            initialValues={{ remember: true }}
            onFinish={HandleLogin}
            onFinishFailed={onFinishFailed}
            autoComplete="off"
        >
            <Form.Item<User>
                label="Email"
                name="email"
                rules={[{ required: true, message: 'Please input your username!' }]}
            >
                <Input />
            </Form.Item>

            <Form.Item<User>
                label="Password"
                name="password"
                rules={[{ required: true, message: 'Please input your password!' }]}
            >
                <Input.Password />
            </Form.Item>

            <Form.Item wrapperCol={{ offset: 8, span: 16 }}>
                <Button type="primary" htmlType="submit">
                    Submit
                </Button>
            </Form.Item>
        </Form>
    )
}

export default LoginScreen