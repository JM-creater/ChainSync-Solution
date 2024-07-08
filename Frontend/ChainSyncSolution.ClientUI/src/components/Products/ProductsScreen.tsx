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
  Tag,
  Flex,
  Switch,
} from 'antd';
import './ProductsScreen.css'
import { PlusOutlined, SearchOutlined, UploadOutlined } from '@ant-design/icons';
import { useDrawer } from '../../hooks/useDrawer';
import { useProduct } from '../../hooks/useProduct';
import { CreateProduct, Product } from '../../models/Product';
import { IdentitySupplierProps } from '../../models/types/IdentityType';
import { uploadProductProps } from '../../utils/uploadConfig';
import React, { useEffect, useState } from 'react';

const ProductsScreen: React.FC<IdentitySupplierProps> = ({ supplierId }) => {

  const [searchQuery, setSearchQuery] = useState<string>('');

  const { 
    drawerOpen, 
    editDrawerOpen,
    showDrawer, 
    closeDrawer,
    showEditDrawer,
    closeEditDrawer
  } = useDrawer();

  const { 
    form, 
    isLoading, 
    products,
    selectedProducts,
    onFinishCreateProduct,
    onFinishUpdateProduct,
    onFinishFailed,
    onFinishUpdateFailed,
    fetchProductBySupplierId,
    fetchProductById,
    deleteProduct,
    searchProductByName,
    handleDeactivateActivateProduct
  } = useProduct();

  useEffect(() => {
    fetchProductBySupplierId(supplierId);
  }, [supplierId, fetchProductBySupplierId]);

  const HandleEdit = async (productId: string) => {
    await fetchProductById(productId);
    showEditDrawer();
  };

  const HandleDelete = async (productId: string) => {
    await deleteProduct(productId);
  };

  const HandleSearch = async () => {
    if (searchQuery.trim() !== '') {
      await searchProductByName(searchQuery);
    } else {
      await fetchProductBySupplierId(supplierId);
    }
  };

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
      render: (record: Product) => (
        <Space size="middle">
          <a onClick={() => HandleEdit(record.id)}>Edit</a>
          <a onClick={() => HandleDelete(record.id)}>Delete</a>
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
        onClick={() => {
          form.resetFields();
          showDrawer();
        }}
      />

      <Flex justify='flex-end' align='flex-start' style={{ marginBottom: '20px' }}>
        <Input 
          addonBefore={<SearchOutlined />} 
          placeholder="Search" 
          style={{ width: 350 }}
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
          onPressEnter={HandleSearch}
        />
      </Flex>
      
      <Table columns={columns} dataSource={products} />

      {/* Create Product */}

      <Drawer
        maskClosable={false}
        title="Create a new product"
        width={720}
        onClose={() => {
          form.resetFields();
          closeDrawer();
        }}
        open={drawerOpen}
        styles={{
          body: {
            paddingBottom: 80,
          },
        }}
        extra={
          <Space>
            <Button onClick={() => {
                form.resetFields();
                closeDrawer();
              }}
            >
              Cancel
            </Button>
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

    {/* Edit Product */}

    <Drawer
        maskClosable={false}
        title="Update a product"
        width={720}
        onClose={() => {
          form.resetFields();
          closeEditDrawer();
        }}
        open={editDrawerOpen}
        bodyStyle={{ paddingBottom: 80 }}
        extra={
          <Space>
            <Button onClick={() => {
                form.resetFields();
                closeEditDrawer()
              }}
            >
              Cancel
            </Button>
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
        {
          selectedProducts && (
            <React.Fragment>
              <React.Fragment>
                <Space align="center" style={{ marginBottom: 25 }}>
                  <label>Activate/Deactivate Product</label>
                  <Switch 
                    checked={selectedProducts.isActive}
                    onChange={() => handleDeactivateActivateProduct(selectedProducts.id, selectedProducts.isActive)} 
                  />
                </Space>
              </React.Fragment>
              <Form 
                form={form}
                layout="vertical" 
                key={selectedProducts.id}
                disabled={!selectedProducts.isActive}
                hideRequiredMark
                onFinish={onFinishUpdateProduct}
                onFinishFailed={onFinishUpdateFailed}
                initialValues={{ 
                  supplierId: supplierId,
                  productName: selectedProducts.productName,
                  phoneNumber: selectedProducts.phoneNumber,
                  price: selectedProducts.price,
                  quantityOnHand: selectedProducts.quantityOnHand,
                  description: selectedProducts.description,
                  productImage: selectedProducts.productImage 
                    ? [{
                        uid: '-1',
                        name: selectedProducts.productImage.split('\\').pop(),
                        status: 'done',
                        url: `https://localhost:7256/${selectedProducts.productImage}`
                      }]
                    : []
                }}
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
                      <Input placeholder="Please enter Price" />
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
            </React.Fragment>
          )
        }
      </Drawer>
    </React.Fragment>
  )
}

export default ProductsScreen;