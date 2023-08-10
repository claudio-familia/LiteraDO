export interface MenuItem {
    name:    string;
    label:   string;
    role?: any;
    submenu: Submenu[];
    route: string;
}

export interface Submenu {
    name:  string;
    label: string;
    route: string;
}