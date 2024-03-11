import { Component, OnInit, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSnackBarAction, MatSnackBarActions, MatSnackBarLabel, MatSnackBarRef } from '@angular/material/snack-bar';

@Component({
  selector: 'snack-bar-custom',
  templateUrl: 'snack-bar-custom.component.html',
  styles: `
  :host {
    display: flex;
  }

  .texto-mensaje {
    color: white;
  }

  div[mat-button] {
    color: #578eed;
    display: flex;
    align-items: center;
    mat-icon {
      font-size:1.2rem;
    }
    
  }

  div[mat-button].alert {
    color: #e00000;
  }

  div[mat-button].success {
    color: #02e5ff;
  }
`,
  standalone: true,
  imports: [MatButtonModule, MatSnackBarLabel, MatSnackBarActions, MatSnackBarAction, MatIconModule],
})
export class SnackBarCustomComponent implements OnInit {
  snackBarRef = inject(MatSnackBarRef);
  msj: string = "";
  type: string = "";

  constructor() { }

  ngOnInit() {
    // Obtener los datos del snackbar
    const data = this.snackBarRef.containerInstance.snackBarConfig.data;
    this.msj = data.message;
    this.type = data.type;

    console.log(this.msj, this.type)
  }
}