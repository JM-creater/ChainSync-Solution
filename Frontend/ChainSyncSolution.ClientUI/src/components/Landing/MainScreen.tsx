import React from 'react';
import { Breadcrumb, Layout, Menu, theme } from 'antd';
import { useMenuItem } from '../../hooks/useMenuItem';
import { HomeOutlined } from '@ant-design/icons';
import '../Landing/MainScreen.css'

const { Header, Content, Footer } = Layout;

const MainScreen: React.FC = () => {

  const {
    menuItems,
    selectNavMenu,
    HandleRenderComponent,
    HandleNavClick
  } = useMenuItem();

  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();

  return (
    <Layout>
      <Header
        style={{
          position: 'sticky',
          top: 0,
          zIndex: 1,
          width: '100%',
          display: 'flex',
          alignItems: 'center',
        }}
      >
        <div className="demo-logo" />
        <Menu
          theme="dark"
          mode="horizontal" 
          items={menuItems}
          style={{ flex: 1, minWidth: 0 }}
        />
      </Header>
      <Content style={{ padding: '0 48px' }}>
        <Breadcrumb
          style={{ margin: '16px 0' }}
          separator="/"
          items={[
            {
              onClick: () => HandleNavClick(0),
              title: (
                <React.Fragment>
                  <HomeOutlined />
                  <span className="breadcrumb-item-nav">Home</span>
                </React.Fragment>
              ),
            },
            ...(selectNavMenu === 1 ? [{
              onClick: () => HandleNavClick(1),
              title: <span className="breadcrumb-item-nav">Order</span>,
            }] : []),
            ...(selectNavMenu === 2 ? [{
              onClick: () => HandleNavClick(2),
              title: <span className="breadcrumb-item-nav">Notification</span>,
            }] : [])
          ]}
        />
        <div
          style={{
            padding: 24,
            minHeight: 380,
            background: colorBgContainer,
            borderRadius: borderRadiusLG,
          }}
        >
          {HandleRenderComponent()}
        </div>
      </Content>
      <Footer style={{ textAlign: 'center' }}>
        ChainSync Solution ©{new Date().getFullYear()} Created by Martin Garado
      </Footer>
    </Layout>
  );
};

export default MainScreen;