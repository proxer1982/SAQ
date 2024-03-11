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
  templateUrl: './list-usuarios.component.html',
  styleUrl: './list-usuarios.component.scss'
})
export class ListUsuariosComponent {
  displayedColumns: string[] = ['Active', 'Nombre', 'Correo', 'Actions'];
  dataSource: Usuario[] = [];

  @ViewChild(MatTable) table: MatTable<Usuario> | undefined;

  constructor(private userService: UsuarioService, private _util: UtilityService, public dialog: MatDialog) {
    this.userService.getAllUsersActive().subscribe((res: ApiResponse) => {
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

  eliminarUsuario(IDusuario: string) {
    this.userService.deleteUser(IDusuario).subscribe((res: ApiResponse) => {
      if (res.isSuccess) {
        const index = this.dataSource.findIndex(u => u.userId === IDusuario);
        if (index !== -1) {
          console.log("eliminar este usuario", index);
          this.dataSource.splice(index, 1);

          this.table?.renderRows();
          this._util.viewAlert("Usuario eliminado correctamente", "success");
        }
      } else {
        this._util.viewAlert("Upps! Algo salio mal", "alert");
      }
    })

  }

  toggleDesactiveUser(usuario: Usuario) {
    const dialogRef = this.dialog.open(AlertDeleteUserComponent, {
      width: '300px',
      data: usuario,
      enterAnimationDuration: '200ms',
      exitAnimationDuration: '500ms',
    });

    dialogRef.afterClosed().subscribe((result: boolean) => {
      if (result) {
        this.eliminarUsuario(usuario.userId)
      } else {
        usuario.status = !usuario.status
      }
    })
  }
}
