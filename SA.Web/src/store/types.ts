import {
    User,
    Country,
    Record,
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
    error: ErrorState;
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
    userName: string;
    token: string;
    language: string;
    isAuthenticated: boolean;
    error: boolean;
    errorMessage: string;
}
/**
 * Default settings off webpage
 */
export interface SettingsState {
    language: string;
    resource: Dictionary<string>;
    countries: Dictionary<Country[]>;
    apiUrl: string;
}
/**
 * Record state
 */
export interface RecordState {
    current?: Record;
    records: Record[];
    error: boolean;
}

/**
 * Error state
 */
export interface ErrorState {
    error: boolean;
    message: string;
}

export interface Dictionary<T> {
    [key: string]: T;
}
