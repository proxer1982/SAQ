import { Component } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { imagesSAQ } from '../../../../../shared/util/images';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../../../../services/auth/auth.service';
import { ApiResponse } from '../../../../../interfaces/response.interface';
import { ValidateService } from '../../../../../services/validate.service';
import { UtilityService } from '../../../../../services/utility.service';
import { Subscription } from 'rxjs';
//import { PositionService } from '../../../../../services/position.service';
import { MatSelectModule } from '@angular/material/select';
import { MapperService } from '../../../../../services/mapper.service';
//import { Usuario } from '../../../../../interfaces/usuario.interface';
import { MatStepperModule } from '@angular/material/stepper';
import { UsuarioService } from '../../../../../services/usuario.service';
import { CommonModule } from '@angular/common';
import { TeamService } from '../../../../../services/team.service';
import { Study } from '../../../../../interfaces/study.interface';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { Usuario } from '../../../../../interfaces/usuario.interface';

@Component({
  selector: 'app-active',
  standalone: true,
  imports: [
    MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    CommonModule,
    FormsModule,
    MatTooltipModule,
    MatStepperModule,
    MatIconModule,
    MatSlideToggleModule
  ],
  templateUrl: './init.component.html',
  styleUrl: './init.component.scss'
})
export class InitComponent {
  formUser: FormGroup;
  groupOne: FormGroup;
  groupTwo: FormGroup;

  clase_password = 'password_show';
  txt_btn_pss = 'Cambiar contraseña';
  color_btn_pss = 'primary';
  state_btn_pss = false;
  img_user: string = imagesSAQ.USER;

  listEquipos: any[] = []; // Inicializar como un array
  estadosStudy: any[] = [
    {
      id: 1,
      estado: "Terminado"
    },
    {
      id: 2,
      estado: "En proceso"
    },
    {
      id: 3,
      estado: "Pendiente"
    }
  ];
  equiposSubscription: Subscription | undefined;

  loader = true;

  user: any;
  studies: Study[] = [];

  constructor(
    private _fb: FormBuilder,
    private _route: ActivatedRoute,
    private _router: Router,
    private _auth: AuthService,
    private _validateService: ValidateService,
    private _util: UtilityService,
    private _teamService: TeamService,
    private _mapper: MapperService,
    private _userService: UsuarioService
  ) {

    this.equiposSubscription = _teamService.getTeams().subscribe((resp: ApiResponse) => {
      if (resp.isSuccess) {
        this.listEquipos = resp.data;

      } else {
        this.listEquipos = []
      }

    });

    this.groupOne = this._fb.group({
      password: ['', [Validators.required, _validateService.passwordValidator]],
      alias: ['', [Validators.required]],
      teamId: [0, [Validators.required]]
    })

    this.groupTwo = this._fb.group({
      study: this._fb.array(this.studies)
    })


    this.formUser = this._fb.group({
      userId: [''],
      roleId: [''],
      positionId: [0, Validators.min(1)],
      userName: [''],
      firstName: [''],
      lastName: [''],
      urlImage: [''],
      status: [0],
      softSkills: [false],
      careerId: [0],
      teamId: [0, [Validators.required]],
      groupOne: this.groupOne,
      groupTwo: this.groupTwo
    })



    this.user = this._userService.getUserById(this._auth.getUserLogged().userId).subscribe(
      (resp: ApiResponse) => {
        if (resp.isSuccess) {
          this.user = resp.data;
          this.loader = false;
          console.log("este es el llamado del usuario: ", this.user)

          this.groupOne = this._fb.group({
            password: ["", [Validators.required, _validateService.passwordValidator]],
            alias: [this.user.alias, [Validators.required]],
            teamId: [this.user.teamId, [Validators.required]]
          })

          this.groupTwo = this._fb.group({
            study: this.setStudy(this.user.study)
          })


          this.formUser = this._fb.group({
            userId: [this.user.userId],
            roleId: [this.user.roleId],
            positionId: [this.user.positionId, Validators.min(1)],
            userName: [this.user.userName],
            firstName: [this.user.firstName],
            lastName: [this.user.lastName],
            urlImage: [this.user.urlImage],
            status: [1],
            softSkills: [this.user.softSkills],
            careerId: [this.user.careerId],
            groupOne: this.groupOne,
            groupTwo: this.groupTwo
          })

          this.addStudy();
        } else {
          this._auth.deleteSessionUser();
          this._router.navigate(['/login']);
        }
      }
    );
  }

  setStudy(studies: Study[]) {
    studies.forEach(stud => {
      this.studies.push(stud);

      const studyGroup = this._fb.group({
        studyId: [stud.studyId],
        studyName: [stud.studyName, [Validators.required]],
        studyLocation: [stud.studyLocation, [Validators.required]],
        status: [stud.status, [Validators.required, Validators.min(1)]],
        userId: [stud.userId]
      });

      // Establecer el valor del estado del estudio
      studyGroup.get('status')?.setValue(stud.status);

      this.studyArray.push(studyGroup);
    });

    return this.studyArray;
  }
  addStudy() {
    const st: Study = {
      studyId: null,
      studyName: '',
      studyLocation: '',
      userId: this.user.userId,
      status: 0
    }
    this.studies.push(st);
    const studyGroup = this._fb.group({
      studyId: [st.studyId],
      studyName: [st.studyName, [Validators.required]],
      studyLocation: [st.studyLocation, [Validators.required]],
      status: [st.status, [Validators.required, Validators.min(1)]],
      userId: [st.userId]
    });

    this.studyArray.push(studyGroup);
  }

  // Método para eliminar un estudio del FormArray
  removeStudy(index: number) {
    this.studyArray.removeAt(index);
  }

  // Getter para acceder al FormArray de estudios
  get studyArray() {
    return this.groupTwo.get('study') as FormArray;
  }

  changePassword() {
    this.groupOne.get('password')?.setValue(this._util.generateSecurePassword(12));
  }

  activeUser() {
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

    const user: Usuario = this.formUser.value;
    if (this.formUser.valid) {
      user.activeTkn = "";

      user.alias = this.groupOne.get('alias')?.value;
      user.teamId = this.groupOne.get('teamId')?.value;
      user.password = this.groupOne.get('password')?.value;

      user.study = this.groupTwo.get('study')?.value;

      console.log("este es el usuario a guardar ", user);
      /*
      this._userService.updateUser(user, user.userId).subscribe((resp: ApiResponse) => {
        if (resp.isSuccess) {
          this._util.viewAlert("Usuario se ha actulizado correctamente", "success");
          this._auth.deleteSessionUser();
          this._router.navigate(['/login']);
        } else {
          this._util.viewAlert(resp.message, "warn");
        }
      })*/
    }
  }
}
