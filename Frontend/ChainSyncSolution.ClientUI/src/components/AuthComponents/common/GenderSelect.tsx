import React from 'react';
import { Select } from 'antd';

const { Option } = Select;

export const GenderSelect: React.FC = () => (
    <Select placeholder="select your gender">
        <Option value="male">Male</Option>
        <Option value="female">Female</Option>
        <Option value="other">Prefer not to say</Option>
    </Select>
);