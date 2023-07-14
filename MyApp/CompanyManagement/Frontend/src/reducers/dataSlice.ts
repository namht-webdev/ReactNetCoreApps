import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import axios from 'axios';
import { DEFAULT_API_URL } from '../api/api';
import { ApiRequest, DataResponse, existData, serverError } from '.';
import { Values } from '../components/Context/Form';

interface DataState {
  data: Values[];
  isLoading: boolean;
  error: string | null;
}
const initialState: DataState = {
  data: [],
  isLoading: false,
  error: null,
};

export const fetchAll = createAsyncThunk<DataResponse, ApiRequest>(
  'data/fetchAll',
  async (req: ApiRequest): Promise<DataResponse> => {
    try {
      const response = await axios.get(`${DEFAULT_API_URL}/${req.route}`);
      return response.data;
    } catch (error) {
      return serverError;
    }
  },
);

export const addNew = createAsyncThunk<DataResponse, ApiRequest>(
  'data/addNew',
  async (req: ApiRequest): Promise<DataResponse> => {
    try {
      const response = await axios.post<DataResponse>(
        `${DEFAULT_API_URL}/${req.route}`,
        req.data!,
      );
      return response.data;
    } catch (error) {
      if (error instanceof Error && error.message.includes('400'))
        return {
          ...existData,
          message: existData.message.replace('###', req.title),
        };
      return serverError;
    }
  },
);

export const update = createAsyncThunk<DataResponse, ApiRequest>(
  'data/update',
  async (req: ApiRequest): Promise<DataResponse> => {
    try {
      const response = await axios.put<DataResponse>(
        `${DEFAULT_API_URL}/${req.route}/${req.id}`,
        req.data,
      );
      return response.data;
    } catch (error) {
      if (error instanceof Error && error.message.includes('400'))
        return { success: false, message: `This ${req.title} does not exist` };
      return { success: false, message: 'Something went wrong' };
    }
  },
);

export const getOne = createAsyncThunk<DataResponse, ApiRequest>(
  'data/getOne',
  async (req: ApiRequest): Promise<DataResponse> => {
    try {
      const response = await axios.get<DataResponse>(
        `${DEFAULT_API_URL}/${req.route}/${req.id}`,
      );
      return response.data;
    } catch (error) {
      if (error instanceof Error && error.message.includes('400'))
        return { success: false, message: `This ${req.title} dose not exist` };
      return { success: false, message: 'Something went wrong' };
    }
  },
);

export const deleteOne = createAsyncThunk<DataResponse, ApiRequest>(
  'data/deleteOne',
  async (req: ApiRequest): Promise<DataResponse> => {
    try {
      const response = await axios.delete<DataResponse>(
        `${DEFAULT_API_URL}/${req.route}/${req.id}`,
      );
      return response.data;
    } catch (error) {
      if (error instanceof Error && error.message.includes('400'))
        return { success: false, message: `This ${req.title} dose not exist` };
      return { success: false, message: 'Something went wrong' };
    }
  },
);

export const dataSlice = createSlice({
  name: 'data',
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
        state.data = action.payload.data;
      })
      .addCase(fetchAll.rejected, (state, action) => {
        state.isLoading = false;
        state.error =
          action.error.message || 'Fail to fetch data from database';
      })
      .addCase(addNew.pending, (state) => {
        state.isLoading = true;
        state.error = null;
      })
      .addCase(addNew.fulfilled, (state, action) => {
        state.isLoading = false;
        state.data.push(action?.payload.data);
      })
      .addCase(addNew.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.error.message || 'Failed to add data to database';
      })
      .addCase(deleteOne.pending, (state) => {
        state.isLoading = true;
      })
      .addCase(deleteOne.fulfilled, (state, action) => {
        state.isLoading = false;
        state.data = state.data.filter(
          (data) => data.id !== action.payload.data,
        );
      })
      .addCase(deleteOne.rejected, (state, action) => {
        state.isLoading = false;
        state.error = action.error.message || 'Failed to add data to database';
      });
  },
});

export default dataSlice.reducer;
