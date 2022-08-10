import {
  ActionReducer,
  ActionReducerMap,
  createFeatureSelector,
  createSelector,
  MetaReducer
} from '@ngrx/store';
import { environment } from '../../environments/environment';


export interface State {
  apikeyValue : string
}

export const initialState: State = {
  apikeyValue : "d79krUoEVNJQMnT5AWeZ9keAJzJPxmNVBu4jf9oH"
};

// export const reducers: ActionReducerMap<State> = {

// };


// export const metaReducers: MetaReducer<State>[] = !environment.production ? [] : [];
