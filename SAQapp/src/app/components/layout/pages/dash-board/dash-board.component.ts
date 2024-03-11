import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { HeaderComponent } from '../../../../shared/components/header/header.component';

@Component({
  selector: 'app-dash-board',
  standalone: true,
  imports: [MatButtonModule, HeaderComponent],
  templateUrl: './dash-board.component.html',
  styleUrl: './dash-board.component.scss'
})
export class DashBoardComponent {

}
