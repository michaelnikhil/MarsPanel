import { createAction, props } from '@ngrx/store';

export const updateApiKey = createAction(
  '[ApiKey] Update Api Key',
  props<{ key: string }>()
);

export const updateApiKeySuccess = createAction(
  '[ApiKey] Update Api Key Success',
  props<{ data: any }>()
);

export const updateApiKeyFailure = createAction(
  '[ApiKey] Update Api Key Failure',
  props<{ error: any }>()
);
