import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {} ;
  @Output() cancelRegister = new EventEmitter();
  constructor(private auth: AuthService,private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.auth.register(this.model).subscribe(
      success => {
        this.alertify.success('registered Successfully');
      },
      error => {
        this.alertify.error('register problem');
      }
    );
  }

  cancel() {
    this.cancelRegister.emit(false);
  }



}
