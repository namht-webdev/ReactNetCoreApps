import { combineReducers, configureStore } from '@reduxjs/toolkit';
import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux';
import roleSlice from './roleSlice';
// import { ObjectState, objectSlice } from './Slices';

export interface DataResponse {
  success: boolean;
  message: string;
  data?: any;
}

export const rootReducer = combineReducers({
  role: roleSlice,
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
