import React, { useState } from 'react';
import {
  DashboardOutlined,
  FileOutlined,
  GroupOutlined,
  ImportOutlined,
  ShoppingOutlined,
} from '@ant-design/icons';
import type { MenuProps } from 'antd';
import { Breadcrumb, Layout, Menu, theme } from 'antd';
import { useMenuItem } from '../../hooks/useMenuItem';

const { Header, Content, Footer, Sider } = Layout;

type MenuItem = Required<MenuProps>['items'][number];

function getItem(
  label: React.ReactNode,
  key: React.Key,
  icon?: React.ReactNode,
  children?: MenuItem[],
  onClick?: () => void
): MenuItem {
  return {
    key,
    icon,
    children,
    label,
    onClick
  } as MenuItem;
}

const items: MenuItem[] = [
  getItem('Dashboard', '1', <DashboardOutlined />),
  getItem('Products', '2', <ShoppingOutlined />),
  getItem('Orders', 'sub1', <GroupOutlined />, [
    getItem('Pending', '3'),
    getItem('Processing', '4'),
    getItem('Ready For Pick Up', '5'),
    getItem('Completed', '6'),
    getItem('Canceled', '7'),
    getItem('Denied', '8')
  ]),
  getItem('Inventory', '9', <ImportOutlined />),
  getItem('Reports', '10', <FileOutlined />),
];

const SupplierMainScreen: React.FC = () => {
  const [collapsed, setCollapsed] = useState(false);
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();
  const { selectedKeySupplier, 
          HandleChangeKeySupplier, 
          HandleRenderContentSupplier 
        } = useMenuItem();

  return (
    <Layout style={{ minHeight: '100vh' }}>
      <Sider 
        collapsible 
        collapsed={collapsed} 
        onCollapse={(value) => setCollapsed(value)} 
        style={{ 
          position: 'fixed', 
          height: '100vh' 
        }}
      >
        <div className="demo-logo-vertical" />
        <Menu 
          theme="dark" 
          mode="inline" 
          selectedKeys={[selectedKeySupplier]} 
          items={items} 
          onClick={HandleChangeKeySupplier}
        />
      </Sider>
      <Layout style={{ marginLeft: collapsed ? 80 : 200, transition: 'margin-left 0.2s' }}>
        <Header style={{ padding: 0, background: colorBgContainer }} />
        <Content style={{ margin: '24px 16px 0', overflow: 'initial' }}>
          <Breadcrumb style={{ margin: '16px 0' }}>
            <Breadcrumb.Item>User</Breadcrumb.Item>
            <Breadcrumb.Item>Bill</Breadcrumb.Item>
          </Breadcrumb>
          <div
            style={{
              padding: 24,
              textAlign: 'center',
              background: colorBgContainer,
              borderRadius: borderRadiusLG,
            }}
          >
            {HandleRenderContentSupplier()}
          </div>
        </Content>
        <Footer style={{ textAlign: 'center' }}>
          ChainSync Solution ©{new Date().getFullYear()} Created by Martin Garado
        </Footer>
      </Layout>
    </Layout>
  );
};

export default SupplierMainScreen;
