import { UploadProps, message } from "antd";

export const uploadProps: UploadProps = {
  name: 'document',
  headers: {
      'Content-Type': 'multipart/form-data',
  },
  beforeUpload: () => false,
  onChange(info) {
      if (info.file.status === 'done') {
          message.success(`${info.file.name} file uploaded successfully`);
      } else if (info.file.status === 'error') {
          message.error(`${info.file.name} file upload failed.`);
      }
  },
};
