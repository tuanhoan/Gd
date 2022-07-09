import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page',
  templateUrl: './teacher.component.html',
  styleUrls: ['./teacher.component.less']
})
export class TeacherComponent implements OnInit {
  isCollapsed = false;
  constructor() { }

  ngOnInit() {
  }

}
