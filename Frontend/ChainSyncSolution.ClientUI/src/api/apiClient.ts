import axios from 'axios';

const apiURL = import.meta.env.BASE_API_URL

const apiClient = axios.create({
    baseURL: apiURL,
});

export default apiClient;
