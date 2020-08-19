import { Component, OnInit } from '@angular/core';
import { InstalmentModel } from './models/InstalmentModel';

@Component({
  selector: 'app-instalment',
  templateUrl: './instalment.component.html',
  styleUrls: ['./instalment.component.css']
})
export class InstalmentComponent implements OnInit {

  jsonData = '[{"id":1, "price":1200000,"insuranceNumber":"123","dueDate":"1399/01/01"},{"id":2, "price":2400000,"insuranceNumber":"1596455","dueDate":"1399/06/01"}]';

  instalments: InstalmentModel[];

  constructor() {
    this.instalments = JSON.parse(this.jsonData);
  }

  ngOnInit(): void {
  }

  pay(id: number) {
    alert(id)
  }

}
