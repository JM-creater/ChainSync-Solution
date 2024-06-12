import React from 'react'
import { Alert } from 'antd'
import './NotificationScreen.css'

const NotificationScreen: React.FC = () => {
  return (
    <div className="notification-container">
     <Alert
        message="Notification Title"
        description="This is a detailed description of the notification. It provides more information about the notification content."
        type="info"
        showIcon
      />
      <Alert
        message="Notification Title"
        description="This is a detailed description of the notification. It provides more information about the notification content."
        type="info"
        showIcon
      />
       <Alert
        message="Notification Title"
        description="This is a detailed description of the notification. It provides more information about the notification content."
        type="info"
        showIcon
      />
       <Alert
        message="Notification Title"
        description="This is a detailed description of the notification. It provides more information about the notification content."
        type="info"
        showIcon
      />
    </div>
  )
}

export default NotificationScreen
