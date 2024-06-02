import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css'],
  providers: [
    UserService
  ]
})
export class NavbarComponent implements OnInit {

constructor(private service: UserService, 
            private router: Router) { }

ngOnInit(): void {
}

isLog(): boolean
{
  return this.service.isLogged();
}

onLogout()
{
  this.service.logout();
  return this.router.navigate(['/user/login']);
}
}
