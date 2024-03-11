export interface UsuarioDTO {
    roleId: number,
    userName: string,
    password: string,
    firstName: string,
    lastName: string,
    positionId: number,
    alias: string | null,
    softSkills: boolean | null,
    urlImage: string,
    status: number | boolean,
    careerId: number | null,
    teamId: number | null,
}