import { 
  FloatButton, 
  Space, 
  Table, 
  Button, 
  Col, 
  Drawer, 
  Form, 
  Input, 
  Row,
  Upload,
  Tag
} from 'antd';
import './ProductsScreen.css'
import { PlusOutlined, UploadOutlined } from '@ant-design/icons';
import { useDrawer } from '../../hooks/useDrawer';
import { useProduct } from '../../hooks/useProduct';
import { CreateProduct } from '../../models/Product';
import { IdentitySupplierProps } from '../../models/types/IdentityType';
import { uploadProductProps } from '../../utils/uploadConfig';
import React, { useEffect } from 'react';

const ProductsScreen: React.FC<IdentitySupplierProps> = ({ supplierId }) => {

  const { 
    drawerOpen, 
    showDrawer, 
    closeDrawer
  } = useDrawer();

  const { 
    form, 
    isLoading, 
    products,
    onFinishCreateProduct, 
    onFinishFailed,
    fetchProductBySupplierId
  } = useProduct();

  useEffect(() => {
    fetchProductBySupplierId(supplierId);
  }, [supplierId, fetchProductBySupplierId]);

  const columns = [
    {
      title: 'Name',
      dataIndex: 'productName',
      key: 'productName',
    },
    {
      title: 'Price',
      dataIndex: 'price',
      key: 'price',
    },
    {
      title: 'Quantity',
      dataIndex: 'quantityOnHand',
      key: 'quantityOnHand',
    },
    {
      title: 'Tags',
      key: 'isActive',
      dataIndex: 'isActive',
      render: (isActive: boolean) => (
        <Tag color={isActive ? 'green' : 'volcano'}>
          {isActive ? 'Active' : 'Inactive'}
        </Tag>
      ),
    },
    {
      title: 'Action',
      key: 'action',
      render: () => (
        <Space size="middle">
          <a>Edit</a>
          <a>Delete</a>
        </Space>
      ),
    },
  ];



  return (
    <React.Fragment>
      <FloatButton 
        icon={<PlusOutlined />} 
        type="primary" 
        style={{ right: 24, height: 50, width: 50}}
        onClick={showDrawer}
      />

      <Table columns={columns} dataSource={products} />

      <Drawer
        maskClosable={false}
        title="Create a new account"
        width={720}
        onClose={closeDrawer}
        open={drawerOpen}
        styles={{
          body: {
            paddingBottom: 80,
          },
        }}
        extra={
          <Space>
            <Button onClick={closeDrawer}>Cancel</Button>
            <Button 
              onClick={() => form.submit()} 
              type="primary" 
              loading={isLoading}
            >
              Submit
            </Button>
          </Space>
        }
      >
        <Form 
          form={form}
          layout="vertical" 
          hideRequiredMark
          onFinish={onFinishCreateProduct}
          onFinishFailed={onFinishFailed}
          initialValues={{ supplierId: supplierId }}
        >
          <Row gutter={16}>
            <Col span={12}>
              <Form.Item<CreateProduct>
                name="productName"
                label="Product Name"
                rules={[{ required: true, message: 'Please enter product name' }]}
              >
                <Input placeholder="Please enter product name" />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item<CreateProduct>
                name="supplierId"
                label="Supplier Id"
              >
                <Input
                  variant='borderless'
                  style={{ width: '100%' }}
                  disabled
                />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={12}>
              <Form.Item<CreateProduct>
                name="phoneNumber"
                label="Phone Number"
                rules={[{ required: true, message: 'Please enter a Phone Number' }]}
              >
                 <Input placeholder="Please enter Phone Number" />
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item<CreateProduct>
                name="price"
                label="Price"
                rules={[{ required: true, message: 'Please enter a Price' }]}
              >
                 <Input placeholder="Please enter Phone Number" />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={12}>
              <Form.Item<CreateProduct>
                name="productImage"
                label="Image"
                rules={[{ required: true, message: 'Please upload an Image' }]}
                valuePropName="fileList"
                getValueFromEvent={(e) => {
                    if (Array.isArray(e)) {
                        return e;
                    } 
                    return e && e.fileList;
                }}
              >
                <Upload {...uploadProductProps} listType="picture">
                  <Button icon={<UploadOutlined/>}>Upload Image</Button>
                </Upload>
              </Form.Item>
            </Col>
            <Col span={12}>
              <Form.Item<CreateProduct>
                name="quantityOnHand"
                label="Quantity"
                rules={[{ required: true, message: 'Please enter a Quantity' }]}
              >
                <Input placeholder="Please enter a Quantity" />
              </Form.Item>
            </Col>
          </Row>
          <Row gutter={16}>
            <Col span={24}>
              <Form.Item<CreateProduct>
                name="description"
                label="Description"
                rules={[
                  {
                    required: true,
                    message: 'please enter product description',
                  },
                ]}
              >
                <Input.TextArea rows={4} placeholder="please enter product description" />
              </Form.Item>
            </Col>
          </Row>
        </Form>
      </Drawer>
    </React.Fragment>
  )
}

export default ProductsScreen;