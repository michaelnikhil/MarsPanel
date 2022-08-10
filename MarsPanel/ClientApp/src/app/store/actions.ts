import { createAction, props } from '@ngrx/store';

export const loadApiKey = createAction(
  '[ApiKey] Load Users'
);

export const loadApiKeySuccess = createAction(
  '[ApiKey] Load Users Success',
  props<{ data: any }>()
);

export const loadApiKeyFailure = createAction(
  '[ApiKey] Load Users Failure',
  props<{ error: any }>()
);
