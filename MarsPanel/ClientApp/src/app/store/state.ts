import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../environments/environment';


export interface AppState {
  apikeyValue : any
}

// export const initialState: AppState = {
//   apikeyValue : "d79krUoEVNJQMnT5AWeZ9keAJzJPxmNVBu4jf9oH"
// };

// export const reducers: ActionReducerMap<AppState> = {};


//  export const metaReducers: MetaReducer<AppState>[] = !environment.production ? [] : [];
