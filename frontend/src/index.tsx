import ReactDOM from 'react-dom/client';
import './index.css';
import { RouterProvider } from 'react-router-dom';
import Router from './routing/Router';
import { createContext } from 'react';
import UserStore from './store/UserStore';
import AchievementsStore from './store/Achievements';
import EventsStore from './store/EventsStore';
import { ConfigProvider } from 'antd';
import { GroupRepository } from './store/GroupRepository';
import { EventRepository } from './store/EventsRepository';
import { EventResultRepository } from './store/EventsResultRepository';
import { QuestRepository } from './store/QuestRepository';
import ScholarshipStore from './store/ScholarshipStore';
import { AchievementsRepository } from './store/AchievementsRepository';

interface State {
	userStore: UserStore,
	achievements: AchievementsStore,
	achievementsRepository: AchievementsRepository,
	eventsStore: EventsStore,
	groupRepository: GroupRepository,
	eventRepository: EventRepository,
	eventResiltRepository: EventResultRepository,
	questRepository: QuestRepository,
	scholarshipStore: ScholarshipStore
}

export const userStore = new UserStore();
export const achievements = new AchievementsStore();
export const eventsStore = new EventsStore();
export const groupRepository = new GroupRepository();
export const eventRepository = new EventRepository();
export const eventResiltRepository = new EventResultRepository();
export const questRepository = new QuestRepository();
export const scholarshipStore = new ScholarshipStore();
export const achievementsRepository = new AchievementsRepository();

export const Context = createContext<State>({
	userStore,
	achievements,
	eventsStore,
	groupRepository,
	eventRepository,
	eventResiltRepository,
	questRepository,
	scholarshipStore,
	achievementsRepository
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
			eventsStore,
			groupRepository,
			eventRepository,
			eventResiltRepository,
			questRepository,
			scholarshipStore,
			achievementsRepository
		}}>
			<RouterProvider router={Router} />
		</Context.Provider>
	</ConfigProvider>
);