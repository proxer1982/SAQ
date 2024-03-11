import { Component, OnDestroy, OnInit } from '@angular/core';
import { HeaderComponent } from '../../../../../shared/components/header/header.component';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

import { UsuarioService } from '../../../../../services/usuario.service';
import { ActivatedRoute, Router, RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { PositionService } from '../../../../../services/position.service';
import { ApiResponse } from '../../../../../interfaces/response.interface';
import { ValidateService } from '../../../../../services/validate.service';
import { UtilityService } from '../../../../../services/utility.service';
import { MatIconModule } from '@angular/material/icon';
import { Subscription } from 'rxjs';
import { UsuarioDTO } from '../../../../../interfaces/userDTOInterface';
import { MapperService } from '../../../../../services/mapper.service';
import { MicrosoftService } from '../../../../../services/microsoft.service';

@Component({
  selector: 'app-new-user',
  standalone: true,
  imports: [
    HeaderComponent,
    ReactiveFormsModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatIconModule,
    RouterLink, RouterLinkActive, RouterOutlet],
  templateUrl: './edit-user.component.html',
  styleUrl: './edit-user.component.scss'
})
export class EditUserComponent implements OnDestroy {
  formUser: FormGroup;
  clase_password = 'password_show';
  txt_btn_pss = 'Cambiar contraseña';
  color_btn_pss = 'primary';
  state_btn_pss = false;

  loader = false;


  user: UsuarioDTO = {
    roleId: 0,
    positionId: 0,
    userName: '',
    password: '',
    firstName: "",
    lastName: "",
    alias: '',
    softSkills: false,
    careerId: null,
    urlImage: "",
    teamId: null,
    status: 1,
  };

  listcargos: any[] = []; // Inicializar como un array
  listRoles: any[] = [
    { roleId: 1, title: 'Administrador' },
    { roleId: 2, title: 'Mentor' },
    { roleId: 3, title: 'Colaborador' }
  ];

  cargosSubscription: Subscription | undefined;
  usuarioId: string;

  constructor(
    private _fb: FormBuilder,
    private _route: ActivatedRoute,
    private _userService: UsuarioService,
    _positionService: PositionService,
    private _validateService: ValidateService,
    private _util: UtilityService,
    private _router: Router,
    private _mapper: MapperService,
    private _mss: MicrosoftService
  ) {

    this.usuarioId = this._route.snapshot.paramMap.get('id')?.toString()!;

    this.formUser = this._fb.group({
      roleId: [null, [Validators.min(1)]],
      positionId: [this.user.positionId, Validators.min(1)],
      userName: [this.user.userName, [Validators.required, Validators.email, _validateService.validateEmailDomain], [_validateService.mailRegisteredValidator()]],
      /*password: [_util.generateSecurePassword(12), [Validators.required, _validateService.passwordValidator]],*/
      password: ['123456Aa*', [Validators.required, _validateService.passwordValidator]],
      firstName: [this.user.firstName, [Validators.required, _validateService.validateName]],
      lastName: [this.user.lastName, [Validators.required, _validateService.validateName]],
      urlImage: [this.user.urlImage],
      status: new FormControl(1, [Validators.required]),
      alias: [''],
      softSkills: [false],
      careerId: [null],
      teamId: [null]
    })

    if (this.usuarioId != undefined) {


      this._userService.getUserById(this.usuarioId).subscribe((resp: ApiResponse) => {
        if (resp.isSuccess) {
          this.user = this._mapper.mapUsuarioToUserDTO(resp.data);
          console.log(this.user)

          this.clase_password = 'password_hide';

          this.formUser = this._fb.group({
            roleId: [this.user.roleId, [Validators.min(1)]],
            positionId: [this.user.positionId, Validators.min(1)],
            userName: [this.user.userName, [Validators.required]],
            password: [this.user.password, [Validators.required, _validateService.passwordValidator]],
            firstName: [this.user.firstName, [Validators.required, _validateService.validateName]],
            lastName: [this.user.lastName, [Validators.required, _validateService.validateName]],
            urlImage: [this.user.urlImage],
            status: [this.user.status, [Validators.required]],
            alias: [this.user.alias],
            softSkills: [this.user.softSkills],
            careerId: [this.user.careerId],
            teamId: [this.user.teamId]
          })

          console.log(this.formUser.controls);
        } else {
          // Redirigir a la ruta /usuarios
          this._router.navigate(['/app/usuarios']);
        }
      })
    }



    this.cargosSubscription = _positionService.getPositions().subscribe((resp: ApiResponse) => {
      if (resp.isSuccess) {
        this.listcargos = resp.data;

      } else {
        this.listcargos = []
      }

    });

  }

  ngOnDestroy(): void {
    if (this.cargosSubscription) {
      this.cargosSubscription.unsubscribe();
    }
  }

  changePassword() {
    this.formUser.get('password')?.setValue(this._util.generateSecurePassword(12));
  }

  guardarUsuario() {
    this.formUser.updateValueAndValidity();

    const camposInvalidos: string[] = [];
    const controles = this.formUser.controls;

    for (const nombreControl in controles) {
      if (controles.hasOwnProperty(nombreControl)) {
        const control = controles[nombreControl];
        if (control.invalid) {
          camposInvalidos.push(nombreControl);
        }
      }
    }

    const user = this.formUser.value;
    if (this.formUser.valid) {


      if (this.usuarioId == "" || this.usuarioId == undefined) {

        this._userService.createUser(user).subscribe((resp: ApiResponse) => {
          if (resp.isSuccess) {
            this._util.viewAlert("Usuario creado correctamente", "success");
            this._router.navigate(['/app/usuarios']);
          }
        })
      } else {

        this._userService.updateUser(user, this.usuarioId).subscribe((resp: ApiResponse) => {
          if (resp.isSuccess) {
            this._util.viewAlert("Usuario se ha actulizado correctamente", "success");
            this._router.navigate(['/app/usuarios']);
          }
        })
      }
    }
  }

  newPassword() {
    if (!this.state_btn_pss) {
      this.formUser.get('password')?.setValue(this._util.generateSecurePassword(12));
      this.clase_password = 'password_show';
      this.txt_btn_pss = 'No cambiar contraseña';
      this.color_btn_pss = 'success';
      this.state_btn_pss = true;
    } else {
      this.formUser.get('password')?.setValue(this.user.password);
      this.clase_password = 'password_hide';
      this.txt_btn_pss = 'Cambiar contraseña';
      this.color_btn_pss = 'primary';
      this.state_btn_pss = false;
    }
  }

  incluirImagenAvatar(event: any) {
    const userNameControl = this.formUser.get('userName');

    var datos: any = {};

    if (userNameControl?.status == 'VALID') {
      this.loader = true;
      this._mss.getDataUser(userNameControl.value).subscribe((resp: any) => {
        this.loader = false;
        if (resp?.body.isSuccess) {
          console.log(resp?.body.data);
          datos = resp?.body.data;

          this.user.urlImage = 'data:image/jpeg;base64,' + datos.urlImage;
          this.user.firstName = datos.firstName;
          this.user.lastName = datos.lastName;
          this.user.userName = userNameControl.value;
          this.user.password = this.formUser.get('password')?.value;

          this.formUser.patchValue(this.user);
        }
      });
    }

  }
}
