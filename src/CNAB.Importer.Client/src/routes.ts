import { Route } from './models/route';

import Home from './pages/home';
import Login from './pages/login';
import Register from './pages/register';

const routes: Route[] = [
  { path: '/', isPrivate: true, element: Home },
  { path: '/login', isPrivate: false, element: Login },
  { path: '/register', isPrivate: false, element: Register },
];

export default routes;
