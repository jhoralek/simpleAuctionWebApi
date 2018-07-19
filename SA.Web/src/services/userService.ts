import { User } from '@/model';
import Mock from '@/mock/mock';
import { MockService } from '@/services';
/**
 * User service
 */
export default class UserService {
    // mocking user service
    private service: Mock;

    constructor() {
        this.service = new Mock(MockService);
    }
    /**
     * Get all users from repository
     */
    public getUsers(): Promise<User[]> {
        return this.service.getUsers().then((users) => {
            return users.data;
        });
    }
    /**
     * Get user by his ID
     * @param id user's Id
     */
    public getById(id: number): Promise<User> {
        return this.service.getUser(id).then((user) => {
            return user.data;
        });
    }
    /**
     * Return user depens on his token string
     * @param token - users current token
     */
    public getByToken(token: string): Promise<User> {
        return this.service.getUserByToken(token).then((user) => {
            return user.data;
        });
    }

    public updateUser(user: User): Promise<User>  {
        return null;
    }
}
