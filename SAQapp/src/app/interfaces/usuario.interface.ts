export interface Usuario {
    userId: string,
    roleId: number,
    positionId: number,
    userName: string | null,
    password?: string | null,
    firstName?: string | null,
    lastName?: string | null,
    alias?: string | null,
    study?: any[] | null,
    softSkills?: boolean | null,
    urlImage: string | null,
    status: number,
    statusUser?: string | null,
    permisson?: number[] | null
    dateCreated?: string | null,
    rol?: any[] | null,
    position?: object | null,
    careerId: number | null,
    stateCareer?: number | null,
    teamId: number | null,
    team?: any | null,
    activeTkn?: string | null
}
