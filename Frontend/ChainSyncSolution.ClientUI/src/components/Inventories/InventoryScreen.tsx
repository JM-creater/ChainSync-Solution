import React from 'react';
import { EditOutlined, SettingOutlined } from '@ant-design/icons';
import { Avatar, Card } from 'antd';
import './InventoryScreen.css';

const { Meta } = Card;

const InventoryScreen: React.FC = () => (
  <div className="inventory-container">
    <h2 className="inventory-title">INVENTORY ITEM</h2>
    <Card
      className="inventory-card"
      cover={
        <img
          className="inventory-card-cover"
          alt="example"
          src="https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png"
        />
      }
      actions={[
        <SettingOutlined key="setting" />,
        <EditOutlined key="edit" />,
        <span>test</span>,
      ]}
    >
      <Meta
        avatar={<Avatar src="https://api.dicebear.com/7.x/miniavs/svg?seed=8" />}
        title="Item Name"
        description="Detailed description of the item in the inventory. Includes specifications and other relevant information."
      />
    </Card>
  </div>
);

export default InventoryScreen;
