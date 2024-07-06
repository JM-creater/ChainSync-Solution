import React from 'react';
import { 
  FloatButton, 
  Space, 
  Table, 
  Tag, 
  Button, 
  Col, 
  Drawer, 
  Form, 
  Input, 
  Row,
  Upload
} from 'antd';
import type { TableProps } from 'antd';
import './ProductsScreen.css'
import { PlusOutlined, UploadOutlined } from '@ant-design/icons';
import { useDrawer } from '../../hooks/useDrawer';
import { useProduct } from '../../hooks/useProduct';
import { CreateProduct } from '../../models/Product';
import { IdentitySupplierProps } from '../../models/types/IdentityType';
import { uploadProductProps } from '../../utils/uploadConfig';

interface DataType {
  key: string;
  name: string;
  age: number;
  address: string;
  tags: string[];
}

const columns: TableProps<DataType>['columns'] = [
  {
    title: 'Name',
    dataIndex: 'name',
    key: 'name',
    render: (text) => <a>{text}</a>,
  },
  {
    title: 'Age',
    dataIndex: 'age',
    key: 'age',
  },
  {
    title: 'Address',
    dataIndex: 'address',
    key: 'address',
  },
  {
    title: 'Tags',
    key: 'tags',
    dataIndex: 'tags',
    render: (_, { tags }) => (
      <>
        {tags.map((tag) => {
          let color = tag.length > 5 ? 'geekblue' : 'green';
          if (tag === 'loser') {
            color = 'volcano';
          }
          return (
            <Tag color={color} key={tag}>
              {tag.toUpperCase()}
            </Tag>
          );
        })}
      </>
    ),
  },
  {
    title: 'Action',
    key: 'action',
    render: (_, record) => (
      <Space size="middle">
        <a>Invite {record.name}</a>
        <a>Delete</a>
      </Space>
    ),
  },
];

const data: DataType[] = [
  {
    key: '1',
    name: 'John Brown',
    age: 32,
    address: 'New York No. 1 Lake Park',
    tags: ['nice', 'developer'],
  },
  {
    key: '2',
    name: 'Jim Green',
    age: 42,
    address: 'London No. 1 Lake Park',
    tags: ['loser'],
  },
  {
    key: '3',
    name: 'Joe Black',
    age: 32,
    address: 'Sydney No. 1 Lake Park',
    tags: ['cool', 'teacher'],
  },
];

const ProductsScreen: React.FC<IdentitySupplierProps> = ({ supplierId }) => {

  const { 
    drawerOpen, 
    showDrawer, 
    closeDrawer 
  } = useDrawer();

  const { 
    form, 
    // isLoading, 
    onFinishCreateProduct, 
    onFinishFailed 
  } = useProduct();

  return (
    <React.Fragment>
      <FloatButton 
        icon={<PlusOutlined />} 
        type="primary" 
        style={{ right: 24, height: 50, width: 50}}
        onClick={showDrawer}
      />
      <Table columns={columns} dataSource={data} />

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
            <Button onClick={() => form.submit()} type="primary">
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