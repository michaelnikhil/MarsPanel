import {  createReducer, on } from '@ngrx/store';
import * as fromActions from './actions';
import { initialState } from './state';

export const apiKeyFeatureKey = 'apiKey';

export const apiKeyReducer = createReducer(
  initialState,
  on(fromActions.updateApiKey, (state, {key}) => ({ ...state, apikeyValue: key }))
);
