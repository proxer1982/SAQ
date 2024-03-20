import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { imagesSAQ } from '../../shared/assets/images';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { ApiResponse } from '../../interfaces/response.interface';
import { ValidateService } from '../../services/validate.service';
import { UtilityService } from '../../services/utility.service';
import { Subscription } from 'rxjs';
import { PositionService } from '../../services/position.service';
import { MatSelectModule } from '@angular/material/select';
import { MapperService } from '../../services/mapper.service';

@Component({
  selector: 'app-active',
  standalone: true,
  imports: [
    MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTooltipModule,
    MatIconModule
  ],
  template: `
  <div>
    <h1>Unos Momentos validamos tus credenciales</h1>
  </div>
`,
  styles: `
  div {
    display: flex;
    justify-content: center;
    align-items: center;
  }
  `
})
export class ActiveComponent {
  userName: string = '';
  token: string = '';
  pass: string = '';

  user: any = {};

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _auth: AuthService
  ) {
    this.userName = decodeURIComponent(this._route.snapshot.paramMap.get('user')?.toString()!);
    this.token = decodeURIComponent(this._route.snapshot.paramMap.get('token')?.toString()!);
    this.pass = decodeURIComponent(this._route.snapshot.paramMap.get('pass')?.toString()!);

    this._auth.deleteSessionUser();

    this.user = this._auth.initUser(this.userName, this.token, this.pass).subscribe(
      (resp: ApiResponse) => {
        console.log(resp);
        if (resp.isSuccess) {
          this._router.navigate(['/app/init']);
        } else {
          this._router.navigate(['/login']);
        }
      }
    );
  }
}
