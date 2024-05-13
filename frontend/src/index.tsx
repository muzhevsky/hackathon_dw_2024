import ReactDOM from 'react-dom/client';
import './index.css';
import { RouterProvider } from 'react-router-dom';
import Router from './routing/Router';
import { createContext } from 'react';
import UserStore from './store/UserStore';
import AchievementsStore from './store/Achievements';
import EventsStore from './store/EventsStore';
import { ConfigProvider } from 'antd';

interface State {
	userStore: UserStore,
	achievements: AchievementsStore,
	eventsStore: EventsStore
}

export const userStore = new UserStore();
export const achievements = new AchievementsStore();
export const eventsStore = new EventsStore();

export const Context = createContext<State>({
	userStore,
	achievements,
	eventsStore
})

const root = ReactDOM.createRoot(
	document.getElementById('root') as HTMLElement
);
root.render(
	<ConfigProvider 
		theme={{
			components:{
				Button: {
					lineHeight: 150
				}
			},
			token: {
				colorPrimary:"#02006B",
				borderRadius: 5
			}
		}}>
		<Context.Provider value={{
			userStore,
			achievements,
			eventsStore
		}}>
			<RouterProvider router={Router} />
		</Context.Provider>
	</ConfigProvider>
);