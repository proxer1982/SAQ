import { Injectable } from '@angular/core';
import { UsuarioDTO } from '../interfaces/userDTOInterface';
import { Usuario } from '../interfaces/usuario.interface';

@Injectable({
  providedIn: 'root'
})
export class MapperService {

  constructor() { }

  mapUsuarioToUserDTO(usuario: Usuario): UsuarioDTO {
    return {
      roleId: usuario.roleId,
      userName: usuario.userName || '',
      password: usuario.password || '',
      firstName: usuario.firstName || '',
      lastName: usuario.lastName || '',
      alias: usuario.alias || '',
      softSkills: usuario.softSkills || false,
      positionId: usuario.positionId,
      urlImage: usuario.urlImage || '',
      status: usuario.status,// Convertir de booleano a número según la lógica de tu aplicación
      careerId: usuario.careerId,
      teamId: usuario.teamId,
    };
  }

  // Función para mapear un objeto de tipo UserDTOInterface a un objeto de tipo Usuario
  mapUserDTOToUsuario(userDTO: UsuarioDTO): Usuario {
    return {
      userId: '', // No estoy seguro de dónde obtendrías este valor en la transformación
      roleId: userDTO.roleId,
      positionId: userDTO.positionId,
      userName: userDTO.userName || null,
      password: userDTO.password || null,
      firstName: userDTO.firstName || null,
      lastName: userDTO.lastName || null,
      urlImage: userDTO.urlImage || null,
      status: userDTO.status, // Convertir de número a booleano según la lógica de tu aplicación
      statusUser: null, // No estoy seguro de dónde obtendrías este valor en la transformación
      permisson: null, // No estoy seguro de dónde obtendrías este valor en la transformación
      alias: userDTO.alias || null,
      softSkills: userDTO.softSkills || false,
      dateCreated: null,
      rol: null,
      careerId: userDTO.careerId || null,
      stateCareer: null,
      teamId: userDTO.teamId || null,
      team: null
    };
  }
}
