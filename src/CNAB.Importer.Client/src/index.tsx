import React from 'react';
import * as ReactDOMClient from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';

import routes from './routes';

import RequireAuth from './hocs/RequireAuth';
import { AuthProvider } from './contexts/Auth';

const root = ReactDOMClient.createRoot(document.getElementById('root')!);

root.render(
  <React.StrictMode>
    <BrowserRouter>
      <AuthProvider>
        <Routes>
          {routes.map((route, index) => (
            <Route
              key={index}
              path={route.path}
              element={
                route.isPrivate ? (
                  <RequireAuth>
                    <route.element />
                  </RequireAuth>
                ) : (
                  <route.element />
                )
              }
            />
          ))}
        </Routes>
      </AuthProvider>
    </BrowserRouter>
  </React.StrictMode>
);
