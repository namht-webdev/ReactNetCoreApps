import { combineReducers, configureStore } from '@reduxjs/toolkit';
import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
import dataSlice from './dataSlice';
// import { ObjectState, objectSlice } from './Slices';

export interface ApiRequest {
  route: string;
  title: string;
  id?: string;
  data?: any;
}

export interface DataResponse {
  success: boolean;
  message: string;
  data?: any;
}

export const existData: DataResponse = {
  success: false,
  message: 'This ### is already exist',
};

export const serverError: DataResponse = {
  success: false,
  message: 'Something went wrong',
};

export const rootReducer = combineReducers({
  data: dataSlice,
});
const store = configureStore({
  reducer: rootReducer,
});

export type RootState = ReturnType<typeof rootReducer>;
export type AppDispatch = typeof store.dispatch;
export const useAppDispatch: () => AppDispatch = useDispatch;
export const useAppSelector: TypedUseSelectorHook<RootState> = useSelector;

export interface AppState {
  //   object: ObjectState;
}
