import {
    User,
    Customer,
    Address,
    Country,
    Record,
    File,
    FileShort,
    Bid,
} from '@/model';

/**
 * This is root state of app store
 */
export interface RootState {
    version: string;
    settings: SettingsState;
    auth: AuthState;
    profile: ProfileState;
    record: RecordState;
}
/**
 * User state
 */
export interface ProfileState {
    user?: User;
    error: boolean;
}
/**
 * Used for authentication
 */
export interface AuthState {
    login?: LoginUser;
    userName: string;
    token: string;
    isAuthenticated: boolean;
    error: boolean;
}
/**
 * Default settings off webpage
 */
export interface SettingsState {
    language: string;
    resource: Dictionary<string>;
    countries: Dictionary<Country[]>;
}
/**
 * Record state
 */
export interface RecordState {
    current?: Record;
    records: Record[];
    error: boolean;
}
export interface Dictionary<T> {
    [key: string]: T;
}
/**
 * This profile is used only for auth and
 * education purposes in this app
 *
 * It's depricated
 */
export interface LoginUser {
    userName: string;
    password: string;
}

