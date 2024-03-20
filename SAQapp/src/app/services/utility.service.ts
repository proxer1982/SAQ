import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackBarCustomComponent } from '../shared/components/snack-bar-custom/snack-bar-custom.component';
import { symbols } from '../shared/util/symbols';

@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor(private _snackBar: MatSnackBar) { }

  viewAlert(msj: string, type: string, duration: number = 5000) {
    this._snackBar.openFromComponent(SnackBarCustomComponent, {
      duration: duration,
      data: {
        message: msj,
        type: type
      },
      horizontalPosition: 'center',
      verticalPosition: 'top'
    });
  }

  generateSecurePassword(length: number, especial: string = symbols.str.complet): string {
    const uppercaseChars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const lowercaseChars = 'abcdefghijklmnopqrstuvwxyz';
    const numericChars = '0123456789';
    const specialChars = especial;

    const allChars = uppercaseChars + lowercaseChars + numericChars + specialChars;

    let password = '';

    // Add at least one of each type of character
    password += this.getRandomChar(uppercaseChars);
    password += this.getRandomChar(lowercaseChars);
    password += this.getRandomChar(numericChars);
    password += this.getRandomChar(specialChars);

    // Fill the rest of the password with random characters
    for (let i = 0; i < length - 4; i++) {
      password += this.getRandomChar(allChars);
    }

    // Shuffle the password to ensure randomness
    password = this.shuffleString(password);

    return password;
  }

  private getRandomChar(characters: string): string {
    return characters.charAt(Math.floor(Math.random() * characters.length));
  }

  private shuffleString(str: string): string {
    const array = str.split('');
    for (let i = array.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]];
    }
    return array.join('');
  }



  // Función para mapear un objeto de tipo Usuario a un objeto de tipo UserDTOInterface


}


