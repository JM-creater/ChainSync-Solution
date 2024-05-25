import React from 'react'
import { Button, Checkbox, Form, Input } from 'antd';
import { Login } from '../../models/Login';
import { useLogin } from '../../hooks/useLogin';
import '../AuthComponents/LoginScreen.css';
import { Typography } from 'antd';
import { Link } from 'react-router-dom';
import { 
    EyeInvisibleOutlined, 
    EyeTwoTone, 
    LockOutlined, 
    UserOutlined 
} from '@ant-design/icons';
import logo from '../../assets/Logo/chainsync logo.png';
import { useMenuItem } from '../../hooks/useMenuItem';
import Customer from '../../assets/Figures/customer.png'
import Supplier from '../../assets/Figures/supplier.png'

const { Title } = Typography;

const LoginScreen: React.FC = () => {
    const { HandleLogin, onFinishFailed, isLoading, form } = useLogin();
    const { HandleChangeItemMenu, selectedMenuItem } = useMenuItem();

    return (
        <section>
            <div className='left'>
                <div className='container'>
                    <img 
                        src={logo} 
                        alt="eVotery-logo" 
                        className='main-logo'
                    />
                    <Title className='main-title'>ChainSync Solution</Title>
                </div>
            </div>
            <div className='right'>
                <div className="container">
                    {
                        selectedMenuItem == 1 ? (
                            <React.Fragment>
                                <div className="customer-right">
                                    <div className="customer-right-container">
                                        <img src={Customer} alt="customer image" width={120} height={120} />
                                        <h1>Customer</h1>
                                    </div>
                                </div>
                                <div className="supplier-left">
                                    <div className="supplier-left-container">
                                    <img 
                                        src={Supplier} 
                                        alt="supplier image" 
                                        width={120} 
                                        height={120} 
                                    />
                                        <h1>Customer</h1>
                                    </div>
                                </div>
                            </React.Fragment>
                        ) : (
                            <Form
                                className="login-form-container"
                                name="basic"
                                style={{ maxWidth: 500 }}
                                initialValues={{ remember: true }}
                                onFinish={HandleLogin}
                                onFinishFailed={onFinishFailed}
                                autoComplete="off"
                                form={form}
                            >
                                <div className="title-login-container">
                                    <Title level={3} className="title-label">LOGIN</Title>
                                </div>

                                <Form.Item<Login>
                                    label="Email"
                                    name="email"
                                    rules={[{ required: true, message: 'Please input your email!' }]}
                                >
                                    <Input 
                                        size='large' 
                                        prefix={<UserOutlined className="site-form-item-icon" />} 
                                        placeholder="Email address" 
                                    />
                                </Form.Item>

                                <Form.Item<Login>
                                    label="Password"
                                    name="password"
                                    rules={[{ required: true, message: 'Please input your password!' }]}
                                >
                                    <Input.Password
                                        size='large'
                                            prefix={<LockOutlined className="site-form-item-icon" />}
                                            type="password"
                                            placeholder="Password"
                                            iconRender={(visible) => (visible ? <EyeTwoTone /> : <EyeInvisibleOutlined />)}
                                        />
                                </Form.Item>

                                <Form.Item>
                                    <div className="form-remember-forgot">
                                        <Form.Item noStyle>
                                            <Checkbox className='title-remember'>Remember me</Checkbox>
                                        </Form.Item>

                                        <Link to={'/reset-password'}>
                                            <div className="login-form-forgot">
                                                Forgot password
                                            </div>
                                        </Link>
                                    </div>
                                </Form.Item>

                                <Form.Item>
                                    <div className="login-register-container">
                                        <div className="login-button-container">
                                            <Button 
                                                size='large'
                                                type="primary" 
                                                htmlType="submit" 
                                                className="login-form-button"
                                                loading={isLoading}
                                            >
                                                Log in
                                            </Button>
                                        </div>
                                        
                                        <div className="register-button-container">
                                            <span className='title-no-account'>No account?</span>
                                            
                                            <a className='register-title' onClick={HandleChangeItemMenu}>Register now!</a>
                                        </div>
                                    </div>
                                </Form.Item>
                            </Form>
                        )
                    }
                </div>
            </div>
        </section>
    )
}

export default LoginScreen