import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.less']
})
export class StudentComponent implements OnInit {
  isCollapsed = false;
  constructor() { }

  ngOnInit() {
  }

}
