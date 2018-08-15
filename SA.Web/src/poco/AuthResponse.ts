export default interface AuthResponse {
    userId: number;
    userName: string;
    token: string;
    langauge: string;
    error: string;
    isDealer: boolean;
    isFeePayed: boolean;
}
