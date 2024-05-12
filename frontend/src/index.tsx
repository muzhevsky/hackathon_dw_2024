import ReactDOM from 'react-dom/client';
import './index.css';
import { RouterProvider } from 'react-router-dom';
import Router from './routing/Router';
import UserStore from './store/UserStore';
import { createContext } from 'react';

interface State {
	userStore: UserStore
}

export const userStore = new UserStore();

export const Context = createContext<State>({
	userStore
})

const root = ReactDOM.createRoot(
	document.getElementById('root') as HTMLElement
);
root.render(
	<Context.Provider value={{
		userStore
	}}>
		<RouterProvider router={Router} />
	</Context.Provider>
);