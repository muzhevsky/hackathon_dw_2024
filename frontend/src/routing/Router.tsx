import { createBrowserRouter, Outlet } from "react-router-dom";
import Home from "../layouts/home/Home";
import ErrorPage from "../pages/errorPage/ErrorPage";
import GlobalEventsPage from "../pages/globalEventsPage/GlobalEventsPage";
import HomePage from "../pages/homePage/HomePage";
import LoginPage from "../pages/loginPage/LoginPage";
import RatingPage from "../pages/ratingPage/RatingPage";
import ShopPage from "../pages/shopPage/ShopPage";
import TicketPage from "../pages/ticketPage/TicketPage";
import Achievements from "../widgets/achievements/Achievements";
import DocumentVerification from "../widgets/documentVerification/DocumentVerification";
import Events from "../widgets/events/Events";
import Scholarship from "../widgets/scholarship/Scholarship";
import Suggestions from "../widgets/suggestions/Suggestions";
import AuthGuard from "./guards/AuthGuard";
import { ACHIEVEMENTS_PATH, DOCUMENT_VERIFICATION_PATH, ERROR_PAGE, EVENTS_PATH, GLOBAL_EVENTS_PATH, HOME_PATH, LOGIN_PATH, RATING_PATH, SCHOLARSHIP_PATH, SHOP_PATH, SUGGESTIONS_PATH, TICKET_PATH } from "./RouterConstants";

const Router = createBrowserRouter([
	{
		path: HOME_PATH,
		element: <AuthGuard>
			<Outlet context={[]} />
		</AuthGuard>,
		children: [
			{
				path: HOME_PATH,
				element: <Home />,
				children: [
					{
						path: HOME_PATH,
						element: <HomePage />,
						children: [
							{
								path: ACHIEVEMENTS_PATH,
								element: <Achievements />
							},
							{
								path: EVENTS_PATH,
								element: <Events />
							},
							{
								path: SCHOLARSHIP_PATH,
								element: <Scholarship />
							},
							{
								path: SUGGESTIONS_PATH,
								element: <Suggestions/>
							},
							{
								path: DOCUMENT_VERIFICATION_PATH,
								element: <DocumentVerification/>
							}
						]
					},
					{
						path: GLOBAL_EVENTS_PATH,
						element: <GlobalEventsPage />
					},
					{
						path: SHOP_PATH,
						element: <ShopPage />
					},
					{
						path: TICKET_PATH,
						element: <TicketPage />
					},
					{
						path: RATING_PATH,
						element: <RatingPage />
					}
				]
			}
		]
	},
	{
		path: LOGIN_PATH,
		element: <LoginPage />
	},
	{
		path: ERROR_PAGE,
		element: <ErrorPage />
	}
]);

export default Router;