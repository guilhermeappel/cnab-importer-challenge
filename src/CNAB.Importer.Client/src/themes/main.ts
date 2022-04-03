import { DefaultTheme, createGlobalStyle } from 'styled-components';

import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';

export const GlobalStyles = createGlobalStyle`  
  * {
    font-family: 'Roboto';
  }
`;

const theme: DefaultTheme = {
  palette: {
    primary: {
      main: '#90caf9',
      dark: '#42a5f5',
      light: '#e3f2fd',
    },
    neutral: {
      main: '#78849e',
      dark: '#515c6f',
      light: '#f5f5f5',
    },
    error: {
      main: '#f44336',
      dark: '#d32f2f',
      light: '#e57373',
    },
  },
};

export default theme;
