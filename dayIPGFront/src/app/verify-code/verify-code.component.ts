import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-verify-code',
  templateUrl: './verify-code.component.html',
  styleUrls: ['./verify-code.component.css']
})
export class VerifyCodeComponent implements OnInit {

  otpCode: string;

  constructor(private router: Router) { }

  ngOnInit(): void {
    if (localStorage.getItem('nationalCode') === undefined || localStorage.getItem('nationalCode') == null || localStorage.getItem('nationalCode') == '') {
      this.router.navigate(['']);
    }
  }

  login() {
    if (this.otpCode == '3') {
      localStorage.setItem('token', '12345648784')
      this.router.navigate(['home']);
    }
    else {
      alert('Error');
    }
  }

}
