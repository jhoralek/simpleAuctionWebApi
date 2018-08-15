import {
    User,
    Country,
    Record,
} from '@/model';
import { MessageDto } from '@/poco';

/**
 * This is root state of app store
 */
export interface RootState {
    version: string;
    settings: SettingsState;
    auth: AuthState;
    profile: ProfileState;
    record: RecordState;
    message: MessageState;
}
/**
 * User state
 */
export interface ProfileState {
    user?: User;
    list: User[];
    error: boolean;
}
/**
 * Used for authentication
 */
export interface AuthState {
    userId: number;
    userName: string;
    token: string;
    language: string;
    isAuthenticated: boolean;
    isDealer: boolean;
    isFeePayed: boolean;
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
    tableView: boolean;
    currentForm: string;
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
export interface MessageState {
    isOn: boolean;
    module: string;
    created: Date;
    message: MessageDto;
}

export interface Dictionary<T> {
    [key: string]: T;
}
