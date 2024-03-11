import { Component, ViewChild } from '@angular/core';
import { HeaderComponent } from '../../../../../shared/components/header/header.component';
import { MatButtonModule } from '@angular/material/button';
import { MatTable, MatTableModule } from '@angular/material/table';
import { UsuarioService } from '../../../../../services/usuario.service';
import { Usuario } from '../../../../../interfaces/usuario.interface';
import { ApiResponse } from '../../../../../interfaces/response.interface';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { FormBuilder, FormGroup, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { AlertDeleteUserComponent } from '../../../../../shared/components/alert-delete-user/alert-delete-user.component';
import { UtilityService } from '../../../../../services/utility.service';
import { SnackBarCustomComponent } from '../../../../../shared/components/snack-bar-custom/snack-bar-custom.component';

@Component({
  selector: 'app-list-usuarios',
  standalone: true,
  imports: [
    HeaderComponent,
    MatButtonModule,
    MatTableModule,
    MatIconModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    MatSlideToggleModule,
    FormsModule
  ],
  templateUrl: './list-usuarios-inactivos.component.html',
  styleUrl: './list-usuarios-inactivos.component.scss'
})
export class ListUsuariosInactivosComponent {
  displayedColumns: string[] = ['Active', 'Nombre', 'Correo', 'date-delete'];
  dataSource: Usuario[] = [];

  @ViewChild(MatTable) table: MatTable<Usuario> | undefined;

  constructor(private userService: UsuarioService, private _util: UtilityService, public dialog: MatDialog) {
    this.userService.getAllUsersInactive().subscribe((res: ApiResponse) => {
      if (res.isSuccess) {
        res.data.forEach((user: Usuario, index: number) => {
          res.data[index].status = user.status == 0 ? false : true
        });

        this.dataSource = res.data;


        console.log(this.dataSource)
      }
    });

  }

  editarUsuario(IDusuario: string) {
    // Lógica para editar el usuario
  }

  verUsuario(IDusuario: string) {
    // Lógica para ver los detalles del usuario
  }

  activarUsuario(IDusuario: string) {


  }

  toggleActiveUser(usuario: Usuario) {
    this.userService.activeUser(usuario).subscribe((res: ApiResponse) => {
      if (res.isSuccess) {
        const index = this.dataSource.findIndex(u => u.userId === usuario.userId);
        if (index !== -1) {
          this.dataSource.splice(index, 1);

          this.table?.renderRows();
          this._util.viewAlert("Usuario actualizado correctamente", "success");
        }
      } else {
        this._util.viewAlert("Upps! Algo salio mal", "alert");
      }
    })
  }

  fijarFecha(fecha: string) {
    const receivedDate = new Date(fecha); // Fecha en formato UTC
    return receivedDate.toLocaleString();
  }
}
