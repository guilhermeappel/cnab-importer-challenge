import 'styled-components';

interface Palette {
  main: string;
  dark: string;
  light: string;
}

declare module 'styled-components' {
  export interface DefaultTheme {
    palette: {
      primary: Palette;
      neutral: Palette;
      error: Palette;
    };
  }
}
