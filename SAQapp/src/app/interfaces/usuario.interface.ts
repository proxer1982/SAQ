export interface Usuario {
    userId: string,
    roleId: number,
    positionId: number,
    userName: string | null,
    password?: string | null,
    firstName?: string | null,
    lastName?: string | null,
    alias?: string | null,
    softSkills?: boolean | null,
    urlImage: string | null,
    status: number | boolean,
    statusUser?: string | null,
    permisson?: number[] | null
    dateCreated?: string | null,
    rol?: any[] | null,
    careerId: number | null,
    stateCareer?: number | null,
    teamId: number | null,
    team?: any | null;
}
