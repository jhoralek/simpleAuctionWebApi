export default interface AuthUser {
    userName: string;
    token: string;
    langauge: string;
    isDealer: boolean;
    isAuthenticated: boolean;
    isFeePayed: boolean;
    userId: number;
}
