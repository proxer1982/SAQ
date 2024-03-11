import { Component, OnInit, inject } from '@angular/core';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { MenuService } from '../../../services/menu.service';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [
    MatExpansionModule,
    MatIconModule,
    MatListModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.scss'
})
export class MenuComponent implements OnInit {
  menus: any;


  constructor(private apiService: MenuService) {

  }
  ngOnInit(): void {
    this.apiService.getMenus().subscribe((res: any) => {
      this.menus = res.data;
    })
  }


}
