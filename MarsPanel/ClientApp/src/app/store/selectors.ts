import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AppState } from './state';

export const getState = createFeatureSelector<AppState>('state');

export const getApiKey = createSelector(getState,
(state: AppState) => state.apikeyValue
); 