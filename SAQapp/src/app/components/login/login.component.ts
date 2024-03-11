import { ChangeDetectorRef, Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Login } from '../../interfaces/login.interface';

import { UtilityService } from '../../services/utility.service';
import { UsuarioService } from '../../services/usuario.service';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatIconModule
  ],

  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  formLogin: FormGroup;
  inputType = 'password';
  visible: boolean = false;
  //loading: boolean = false;


  constructor(
    private _fb: FormBuilder,
    private _router: Router,
    private _util: UtilityService,
    private _auth: AuthService,
    private cd: ChangeDetectorRef
  ) {

    if (this._auth.isLoggedIn) {
      this._router.navigate(['/app']);
    }

    this.formLogin = this._fb.group({
      username: new FormControl('admin@satrack.com', [Validators.required]), // ['admin@satrack.com', [Validators.required]],
      password: new FormControl('123AA', [Validators.required]), // ['123AA', [Validators.required]]
    })
  }

  ngOnInit(): void {

  }

  login(): void {
    //this.loading = true;

    if (this.formLogin.invalid) {
      return Object.values(this.formLogin.controls).forEach((controls) => {
        controls.markAllAsTouched();
      });
    }

    const reqt: Login = {
      username: this.formLogin.value.username,
      password: this.formLogin.value.password
    }

    this._auth.login(reqt).subscribe({
      next: (res) => {

        if (res.isSuccess) {
          this._router.navigate(['/app']);
        } else {
          this._util.viewAlert(res.message, 'warning');
        }
      },
      error: (err) => {
        console.error('Error en la autenticación:', err);
      },
      complete: () => {
        console.log('Autenticación completada');
      }
    });
  }

  toggleVisibility() {
    if (this.visible) {
      this.inputType = 'password';
      this.visible = false;
      this.cd.markForCheck();
    } else {
      this.inputType = 'text';
      this.visible = true;
      this.cd.markForCheck();

    }
  }

}
