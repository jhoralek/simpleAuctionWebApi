import axios from 'axios';
import { User } from '@/model';

export default class AuthService {
    /**
     * Login user
     * @param userName - User's login name
     * @param password - User's password
     */
    public login(userName: string, password: string): Promise<User> {
        return axios.post('http://localhost:4999/api/accounts/login', {
                UserName: userName,
                Password: password })
            .then((response) => {
                return response.data as User; })
            .catch((error) => {
                return error;
            });
    }
}
