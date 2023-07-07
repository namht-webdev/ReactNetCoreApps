import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { Role } from '../interfaces/Role';
import axios from 'axios';
import { DEFAULT_API_URL } from '../api/api';
import { DataResponse } from '.';

// interface Error{
//   success: boolean;
//   message: string;
// }

interface RoleState {
  roles: Role[];
  isLoading: boolean;
  error: string | null;
}
const initialState: RoleState = {
  roles: [],
  isLoading: false,
  error: null,
};

export interface UpdateRolePayload {
  role_id: string;
  role: Role;
}

export const fetchAll = createAsyncThunk(
  'role/fetchAll',
  async (): Promise<DataResponse> => {
    const response = await axios.get(`${DEFAULT_API_URL}/role`);
    return response.data;
  },
);

export const addNew = createAsyncThunk<DataResponse, Role>(
  'role/addNew',
  async (role: Role): Promise<DataResponse> => {
    try {
      const response = await axios.post<DataResponse>(
        `${DEFAULT_API_URL}/role`,
        role,
      );
      return response.data;
    } catch (error) {
      if (error instanceof Error && error.message.includes('400'))
        return { success: false, message: 'This role was exist' };
      return { success: false, message: 'Something went wrong' };
    }
  },
);

export const updateRole = createAsyncThunk<DataResponse, UpdateRolePayload>(
  'role/addNew',
  async (payload: UpdateRolePayload): Promise<DataResponse> => {
    try {
      const response = await axios.put<DataResponse>(
        `${DEFAULT_API_URL}/role/${payload.role_id}`,
        payload.role,
      );
      return response.data;
    } catch (error) {
      if (error instanceof Error && error.message.includes('400'))
        return { success: false, message: 'This role was exist' };
      return { success: false, message: 'Something went wrong' };
    }
  },
);

export const getOne = createAsyncThunk<DataResponse, string>(
  'role/addNew',
  async (role_id: string): Promise<DataResponse> => {
    try {
      const response = await axios.get<DataResponse>(
        `${DEFAULT_API_URL}/role/${role_id}`,
      );
      return response.data;
    } catch (error) {
      if (error instanceof Error && error.message.includes('400'))
        return { success: false, message: 'Role này chưa có trong hệ thống' };
      return { success: false, message: 'Something went wrong' };
    }
  },
);

export const deleteRole = createAsyncThunk<DataResponse, string>(
  'role/deleteRole',
  async (role_id: string): Promise<DataResponse> => {
    try {
      const response = await axios.delete<DataResponse>(
        `${DEFAULT_API_URL}/role/${role_id}`,
      );
      return response.data;
    } catch (error) {
      if (error instanceof Error && error.message.includes('400'))
        return { success: false, message: 'Role này chưa có trong hệ thống' };
      return { success: false, message: 'Something went wrong' };
    }
  },
);

export const roleSlice = createSlice({
  name: 'role',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchAll.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(fetchAll.fulfilled, (state, action) => {
        state.isLoading = false;
        state.roles = action.payload.data;
      })
      .addCase(fetchAll.rejected, (state, action) => {
        state.isLoading = false;
        state.error =
          action.error.message || 'Fail to fetch roles from database';
      })
      .addCase(addNew.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(addNew.fulfilled, (state, action) => {
        state.isLoading = false;
        state.roles.push(action?.payload.data);
      })
      .addCase(addNew.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.error.message || 'Failed to add role to database';
      })
      .addCase(deleteRole.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(deleteRole.fulfilled, (state, action) => {
        state.isLoading = false;
        state.roles = state.roles.filter(
          (role) => role.role_id !== action.payload.data,
        );
      });
  },
});

export default roleSlice.reducer;
