import { Component, OnInit } from '@angular/core';
import { GetCodeModel } from './models/GetCodeModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-get-code',
  templateUrl: './get-code.component.html',
  styleUrls: ['./get-code.component.css']
})
export class GetCodeComponent implements OnInit {

  getCodeModel: GetCodeModel;

  constructor(private router: Router) {
    this.getCodeModel = new GetCodeModel();
  }

  ngOnInit(): void {
    if (localStorage.getItem('token') != undefined && localStorage.getItem('token') != null && localStorage.getItem('token') != '') {
      this.router.navigate(['home']);
    }
    else if (localStorage.getItem('nationalCode') != undefined && localStorage.getItem('nationalCode') != null && localStorage.getItem('nationalCode') != '') {
      this.router.navigate(['verify-code']);
    }
  }

  getCode() {
    if (this.getCodeModel.nationalCode == '1' && this.getCodeModel.mobileNumber == '2') {
      localStorage.setItem('nationalCode', this.getCodeModel.nationalCode);
      this.router.navigate(['verify-code']);
    }
    else {
      alert('Error');
    }
  }
}
