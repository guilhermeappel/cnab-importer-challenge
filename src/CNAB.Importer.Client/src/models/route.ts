export interface Route {
  path: string;
  isPrivate: boolean;
  element: () => JSX.Element;
}
