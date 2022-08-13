import {  Action, createReducer, on } from '@ngrx/store';

import * as fromActions from './actions';
import { AppState } from './state';

// export interface AppState {
//   apikeyValue : any
// }

export const initialState: AppState = {
  apikeyValue : "d79krUoEVNJQMnT5AWeZ9keAJzJPxmNVBu4jf9oH"
};

export const apiKeyFeatureKey = 'apiKey';

export const apiKeyReducer = createReducer(
  initialState,
  on(fromActions.updateApiKey, (state, {key}) => ({ ...state, apikeyValue: key }))
);

// export function apiKeyReducer(state: any, action: Action) {
//   return _apiKeyReducer(state, action);
// }