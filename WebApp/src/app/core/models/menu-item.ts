export interface MenuItem {
    name:    string;
    label:   string;
    submenu: Submenu[];
    route: string;
}

export interface Submenu {
    name:  string;
    label: string;
    route: string;
}