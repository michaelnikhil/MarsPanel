import { createAction, props } from '@ngrx/store';

export const updateApiKey = createAction(
  '[ApiKey] Update Api Key',
  props<{ key: string }>()
);
