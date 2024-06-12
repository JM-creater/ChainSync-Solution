import {
  ArrowRightOutlined,
  ShoppingCartOutlined
} from '@ant-design/icons';
import { Avatar, Card, Carousel, Modal } from 'antd'
import React from 'react'
import '../Landing/HomeScreen.css'
import { useModal } from '../../hooks/useModal';
import { useMenuItem } from '../../hooks/useMenuItem';

const { Meta } = Card;

const contentStyle: React.CSSProperties = {
  height: '160px',
  color: '#fff',
  lineHeight: '160px',
  textAlign: 'center',
  background: '#ff7f50',
  fontSize: '24px',
  fontWeight: 'bold',
  borderRadius: '10px'
};

const HomeScreen: React.FC = () => {

  const { isModalOpen, setIsModalOpen, showModal } = useModal();
  const { HandleNavClick } = useMenuItem();

  return (
    <React.Fragment>
      <div className="carousel-container">
        <Carousel autoplay>
          <div>
            <h3 style={contentStyle}>Unlocking the Secrets of Supply Chain Mastery</h3>
          </div>
          <div>
            <h3 style={contentStyle}>Essential Building Blocks of a Strong Supply Chain</h3>
          </div>
          <div>
            <h3 style={contentStyle}>Overcoming Supply Chain Obstacles with Ease</h3>
          </div>
          <div>
            <h3 style={contentStyle}>Innovative Strategies for Optimal Supply Chain Efficiency</h3>
          </div>
        </Carousel>
      </div>

      <div className="card-container-suppliers">
        <Card
          style={{ width: 300 }}
          cover={
            <img
              alt="example"
              src="https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png"
            />
          }
          actions={[
            <ArrowRightOutlined key="edit" onClick={showModal} />,
          ]}
        >
          <Meta
            avatar={<Avatar src="https://api.dicebear.com/7.x/miniavs/svg?seed=8" />}
            title="Card title"
            description="This is the description"
          />
        </Card>
      </div>

      <Modal
        title="Modal 1000px width"
        centered
        open={isModalOpen}
        onOk={() => setIsModalOpen(true)}
        onCancel={() => setIsModalOpen(false)}
        width={1000}
        maskClosable={false}
      >
        <Card
          style={{ width: 300 }}
          cover={
            <img
              alt="example"
              src="https://gw.alipayobjects.com/zos/rmsportal/JiqGstEfoWAOHiTxclqi.png"
            />
          }
          actions={[
            <ShoppingCartOutlined key="edit" onClick={() => HandleNavClick(1)} />,
          ]}
        >
          <Meta
            avatar={<Avatar src="https://api.dicebear.com/7.x/miniavs/svg?seed=8" />}
            title="Card title"
            description="This is the description"
          />
        </Card>
      </Modal>

    </React.Fragment>
  )
}

export default HomeScreen