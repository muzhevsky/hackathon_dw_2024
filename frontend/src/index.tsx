import ReactDOM from 'react-dom/client';
import './index.css';
import { RouterProvider } from 'react-router-dom';
import Router from './routing/Router';
import { createContext } from 'react';
import UserStore from './store/UserStore';
import AchievementsStore from './store/Achievements';

interface State {
	userStore: UserStore,
	achievements: AchievementsStore
}

export const userStore = new UserStore();
export const achievements = new AchievementsStore();

export const Context = createContext<State>({
	userStore,
	achievements
})

const root = ReactDOM.createRoot(
	document.getElementById('root') as HTMLElement
);
root.render(
	<Context.Provider value={{
		userStore,
		achievements
	}}>
		<RouterProvider router={Router} />
	</Context.Provider>
);