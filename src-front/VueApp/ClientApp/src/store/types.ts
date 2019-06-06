import { User } from '@/models/User';
import { Space } from '@/models/Space';

export interface RootState {
  version: string;
}

export interface AuthState {
  currentUser?: User;
  currentUserToken?: string;
  error: boolean;
}

export interface NoteState {
  spaces?: Space[];
  currentSpace?: Space;
  // updateSpaceError?: boolean;
  // updateSpaceSuccess?: boolean;
}

export interface ProfileState {
  user?: User;
}
