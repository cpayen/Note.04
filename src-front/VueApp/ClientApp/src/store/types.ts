import { User } from '../models/User';

export interface RootState {
  version: string;
}

export interface AuthState {
  currentUser?: User;
  currentUserToken?: string;
  error: boolean;
}

export interface ProfileState {
  user?: User;
}
