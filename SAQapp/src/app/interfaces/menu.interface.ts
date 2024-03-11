export interface Menu {
    "menuId": number,
    "title": string,
    "icon": string | null,
    "url": string | null,
    "parent": number | null,
    "status": number,
    "permissionMenus": any[],
    "submenus": Menu[] | null
}
