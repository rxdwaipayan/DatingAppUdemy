import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  username: string;

  constructor(public auth: AuthService,private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login(){
    this.auth.login(this.model).subscribe(next =>{
       this.alertify.success('Logged in Successfully');
    },
    error => {
      this.alertify.error('Unsuccessful login');
    }
    );
  }

  loggedIn()
  {
    this.username = localStorage.getItem('username');
    return this.auth.loggedIn();
  }

  loggedOff()
  {
    localStorage.removeItem('token');
    localStorage.removeItem('username');
    this.alertify.message('logged out');
  }

}
