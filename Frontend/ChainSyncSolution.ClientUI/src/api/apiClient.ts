import axios from 'axios';

const apiClient = axios.create({
    baseURL: 'https://localhost:7256',
});

export default apiClient;
