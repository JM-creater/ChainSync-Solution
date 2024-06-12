import React from 'react';
import { Card, List, Typography, Radio, Row, Col, Divider, Button } from 'antd';
import styled from 'styled-components';
import './OrderScreen.css'

const { Title, Text } = Typography;

const products = [
  { name: 'Product 1', price: 50 },
  { name: 'Product 2', price: 100 },
  { name: 'Product 3', price: 150 },
];

const OrderScreen: React.FC = () => {
  const totalPrice = products.reduce((total, product) => total + product.price, 0);

  return (
    <StyledRow justify="center">
      <Col xs={24} sm={18} md={12}>
        <Card bordered={false} className='order-card-container'>
          <StyledTitle>Order Summary</StyledTitle>
          <List
            itemLayout="horizontal"
            dataSource={products}
            renderItem={(product) => (
              <List.Item>
                <List.Item.Meta
                  title={<Text strong>{product.name}</Text>}
                  description={`Price: $${product.price}`}
                />
              </List.Item>
            )}
          />
          <Divider />
          <Row justify="space-between">
            <Text strong>Total Price:</Text>
            <Text strong>${totalPrice}</Text>
          </Row>
          <Divider />
          <Title level={4}>Payment Options</Title>
          <Radio.Group>
            <Radio value="cash">Cash on Hand</Radio>
            <Radio value="emoney">E-Money</Radio>
          </Radio.Group>
          <Divider />
          <Button type="primary" block>
            Place Order
          </Button>
        </Card>
      </Col>
    </StyledRow>
  );
};

const StyledRow = styled(Row)`
  padding: 20px;
  background: linear-gradient(to right, #ffafbd, #ffc3a0);
  min-height: 100vh;
`;

const StyledTitle = styled(Title)`
  text-align: center;
  color: #333;
`;

export default OrderScreen;
