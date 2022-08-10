import { Action, createReducer, on } from '@ngrx/store';
import { initialState } from './state';


export const apiKeyFeatureKey = 'apiKey';

// export interface State {

// }

// export const initialState: State = {

// };

export const reducer = createReducer(
  initialState,

);
