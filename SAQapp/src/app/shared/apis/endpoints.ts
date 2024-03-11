import { HttpHeaders } from "@angular/common/http"

export const endpoint = {
    MENU: "Menu",
    USER_ALL_ACTIVE: "User",
    USER_ALL_INACTIVE: "User/inactive",
    USER_BY_MAIL: "User/mail/",
    USER_BY_ID: "User/",
    POSITIONS: "Position",
    USER_UPDATE: "User/update/",
    USER_DELETE: "User/delete/",
    USER_NEW: "User/register",

    //AUTH MODULE
    GENERATE_TOKEN: 'User/generate/token'
}

export const httpOptions = {
    headers: new HttpHeaders({
        "content-type": "application/json"
    })
}

export const httpOptionsExt = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
        "No_auth": "true"
    })
}