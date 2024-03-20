import { Component, OnDestroy } from '@angular/core';
import { HeaderComponent } from '../../../../../shared/components/header/header.component';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
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
import { imagesSAQ } from '../../../../../shared/assets/images';
import { MatFormFieldModule } from '@angular/material/form-field';
import { symbols } from '../../../../../shared/assets/symbols';

@Component({
  selector: 'app-new-user',
  standalone: true,
  imports: [
    HeaderComponent,
    ReactiveFormsModule,
    FormsModule, MatFormFieldModule,
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
  img_user: string = imagesSAQ.USER

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
    status: 2,
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
      status: new FormControl(this.user.status, [Validators.required]),
      alias: [''],
      softSkills: [false],
      careerId: [null],
      teamId: [null]
    })

    if (this.usuarioId != undefined) {


      this._userService.getUserById(this.usuarioId).subscribe((resp: ApiResponse) => {
        if (resp.isSuccess) {
          this.user = this._mapper.mapUsuarioToUserDTO(resp.data);

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
    this.formUser.get('password')?.setValue(this._util.generateSecurePassword(12, symbols.str.init));
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
            const pass = encodeURIComponent(user.password);
            const name = encodeURIComponent(user.userName);
            const tkn = encodeURIComponent(resp.data.activeTkn);

            var message = `<table style="width: 600px; margin-bottom: 80px"><tr><td style="text-align: center; padding: 20px"><img src="http://localhost:4200/assets/img/logo_app.svg" width="200" ></td></tr><tr><td style="text-align: justify; padding: 20px"><h3>Hola ${user.firstName} ${user.lastName}</h3>
            <p>Se te ha otorgado acceso a la plataforma de calificación de aprendizaje técnico.
            <br>A continuación encontrarás un enlace para tu primer ingreso. Recuerda que debes cambiar tu contraseña y anexar algunos datos adicionales para poder empezar tu proceso de aprendizaje.</p><br>
            <a style="text-decoration: none; padding: 10px 20px; background-color: #007bff; color: white; border-radius: 25px;" href="http://localhost:4200/activar/${pass}/${name}/${tkn}">Activar cuenta</a><br><br><br><br><br><br><br>
            </td></tr></table>`;

            var resp_mail = this._mss.sendMail(message, "juan.zorro@satrack.com", "juan.zorro@satrack.com", "Activar cuenta SAQ").subscribe((resp: any) => {

              console.log("esta es la respuesta del envio del mail: ", resp)
            });

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
      this.formUser.get('password')?.setValue(this._util.generateSecurePassword(12, symbols.str.init));
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
    this.formUser.controls['firstName'].disable();
    this.formUser.controls['lastName'].disable();
    this.formUser.controls['password'].disable();
    this.formUser.controls['roleId'].disable();
    this.formUser.controls['positionId'].disable();

    var datos: any = {};

    if (userNameControl?.status == 'VALID') {
      this.loader = true;
      this._mss.getDataUser(userNameControl.value).subscribe((resp: any) => {
        this.loader = false;

        this.formUser.controls['firstName'].enable();
        this.formUser.controls['lastName'].enable();
        this.formUser.controls['password'].enable();
        this.formUser.controls['roleId'].enable();
        this.formUser.controls['positionId'].enable();

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
