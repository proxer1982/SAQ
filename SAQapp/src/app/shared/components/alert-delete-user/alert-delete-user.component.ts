import { Component } from '@angular/core';
import { MatDialog, MatDialogActions, MatDialogClose, MatDialogContent, MatDialogRef, MatDialogTitle } from '@angular/material/dialog';
import { Usuario } from '../../../interfaces/usuario.interface';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-alert-delete-user',
  standalone: true,
  imports: [MatButtonModule, MatDialogActions, MatDialogClose, MatDialogTitle, MatDialogContent],
  templateUrl: './alert-delete-user.component.html',
  styleUrl: './alert-delete-user.component.scss'
})
export class AlertDeleteUserComponent {
  data: any;
  constructor(public dialogRef: MatDialogRef<AlertDeleteUserComponent>) {
    this.data = dialogRef._containerInstance._config.data;
  }

  confirmarEliminar(): void {
    this.dialogRef.close(true);
  }

  cancelarEliminar(): void {
    this.dialogRef.close(false);
  }
}
