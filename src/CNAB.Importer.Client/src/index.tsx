import React from 'react';
import { ThemeProvider } from 'styled-components';
import * as ReactDOMClient from 'react-dom/client';
import { BrowserRouter, Routes, Route } from 'react-router-dom';

import routes from './routes';
import theme, { GlobalStyles } from './themes/main';

import RequireAuth from './hocs/RequireAuth';
import { AuthProvider } from './contexts/Auth';

const root = ReactDOMClient.createRoot(document.getElementById('root')!);

root.render(
  <React.StrictMode>
    <BrowserRouter>
      <ThemeProvider theme={theme}>
        <GlobalStyles />
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
      </ThemeProvider>
    </BrowserRouter>
  </React.StrictMode>
);
