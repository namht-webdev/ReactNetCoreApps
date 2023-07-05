import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { Role } from '../interfaces/Role';
import axios from 'axios';
import { DEFAULT_API_URL } from '../api/api';

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
export const fetchAll = createAsyncThunk(
  'role/fetchAll',
  async (): Promise<Role[]> => {
    const response = await axios.get(`${DEFAULT_API_URL}/role`);
    return response.data;
  },
);

export const addNew = createAsyncThunk(
  'role/addNew',
  async (role: Role): Promise<Role | null> => {
    const response = await axios.post(`${DEFAULT_API_URL}/role`, role);
    return response.data ? role : null;
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
        state.roles = action.payload;
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
        state.roles.push(action?.payload as Role);
      })
      .addCase(addNew.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.error.message || 'Failed to add role to database';
      });
  },
});

export default roleSlice.reducer;
