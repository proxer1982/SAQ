import { Injectable } from '@angular/core';
import { AsyncValidatorFn, FormControl } from '@angular/forms';
import { Observable, catchError, map, of } from 'rxjs';
import { UsuarioService } from './usuario.service';
import { MicrosoftService } from './microsoft.service';
import { symbols } from '../shared/assets/symbols';

@Injectable({
  providedIn: 'root'
})
export class ValidateService {


  constructor(private _userService: UsuarioService, private _mss: MicrosoftService) { }

  validateEmailDomain(control: FormControl) {
    const email = control.value;
    if (!email || email.indexOf('@') === -1) {
      return { invalidFormat: true };
    }

    const parts = email.split('@');
    const userName = parts[0];
    const domain = parts[1];

    // Verifica caracteres especiales en el nombre de usuario
    const specialCharacters = /[^a-zA-Z.]/;
    if (specialCharacters.test(userName)) {
      return { invalidUserName: true };
    }

    // Verifica el dominio del correo electrónico
    if (domain !== 'satrack.com') {
      return { invalidDomain: true };
    }

    return null;
  }


  validateName(control: FormControl) {
    const text = control.value;

    // Verifica caracteres especiales en el nombre de usuario
    const specialCharacters = /[^a-zA-Z\s.']/;;
    if (specialCharacters.test(text)) {
      return { invalidText: true };
    }

    return null;
  }

  mailRegisteredValidator(): AsyncValidatorFn {
    return (control): Observable<{ [key: string]: any } | null> => {
      const email = control.value;
      return this._userService.getUserByMail(email).pipe(
        map(resp => {
          if (resp.data) {
            return { mailRegistered: true };
          } else {
            return null;
          }
        }),
        catchError(() => of(null)) // Manejo de errores
      );
    };
  }

  passwordValidator(control: FormControl) {
    const password = control.value;
    if (!password) {
      return null;
    }

    const hasUpperCase = /[A-Z]/.test(password);
    if (!hasUpperCase) {
      return { requiredUpperCase: true };
    }

    const hasLowerCase = /[a-z]/.test(password);
    if (!hasLowerCase) {
      return { requiredLowerCase: true };
    }


    const hasNumbers = /\d/.test(password);
    if (!hasNumbers) {
      return { requiredNumber: true };
    }

    const hasSpecialCharacters = symbols.complet.test(password);
    if (!hasSpecialCharacters) {
      return { requiredSpecialCaracter: true };
    }

    if (password.length < 8) {
      return { requiredLengthMin: true };
    }

    return null;
  }

  /*private escapeRegExpTemp(stro: string): string {
    console.log(stro);
    const resp = stro.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
    console.log('esta es la respuesta: ', resp);
    if (resp === stro) {
      return resp;
    } else {
      return "";
    }
  }*/
}
