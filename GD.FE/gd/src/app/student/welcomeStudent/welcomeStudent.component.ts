import { Component, OnInit } from '@angular/core';
import { ErrorResponse } from 'src/app/responses/error-response';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-welcomeStudent',
  templateUrl: './welcomeStudent.component.html',
  styleUrls: ['./welcomeStudent.component.less'],
})
export class WelcomeStudentComponent implements OnInit {
  radioValue: any = 'A';

  questions = ['Câu hỏi 1', 'Câu hỏi 2', 'Câu hỏi 3', 'Câu hỏi 5', 'Câu hỏi 5'];

  datas: any = [
    {
      id: 1,
      question: 'Câu hỏi 1. Đây là gì?',
      image: 'https://www.tugo.com.vn/wp-content/uploads/1-3339-1415416821.jpg',
      listAnswer: [
        { id: 1, ans: 'Đáp án A' },
        { id: 2, ans: 'Đáp án B' },
        { id: 3, ans: 'Đáp án C' },
        { id: 4, ans: 'Đáp án D' },
      ],
      selected: null,
      isMultipleSelect: true,
    },
    {
      id: 2,
      question: 'Câu hỏi 2. Đây là gì?',
      image: null,
      listAnswer: [
        { id: 1, ans: 'Đáp án A' },
        { id: 2, ans: 'Đáp án B' },
        { id: 3, ans: 'Đáp án C' },
        { id: 4, ans: 'Đáp án D' },
      ],
      selected: null,
      isMultipleSelect: true,
    },
    {
      id: 3,
      question: 'Câu hỏi 3. Đây là gì?',
      image:
        'https://indochinapost.com/wp-content/uploads/dich-vu-giao-hang-nhanh-tu-anh-quoc-ve-viet-nam.jpg',
      listAnswer: [
        { id: 1, ans: 'Đáp án A' },
        { id: 2, ans: 'Đáp án B' },
        { id: 3, ans: 'Đáp án C' },
        { id: 4, ans: 'Đáp án D' },
      ],
      selected: null,
      isMultipleSelect: false,
    },
    {
      id: 4,
      question: 'Câu hỏi 4. Đây là gì?',
      image: 'https://i.ytimg.com/vi/FN7ALfpGxiI/maxresdefault.jpg',
      listAnswer: [
        { id: 1, ans: 'Đáp án A' },
        { id: 2, ans: 'Đáp án B' },
        { id: 3, ans: 'Đáp án C' },
        { id: 4, ans: 'Đáp án D' },
      ],
      selected: null,
      isMultipleSelect: false,
    },
    {
      id: 5,
      question: 'Câu hỏi 5. Đây là gì?',
      image:
        'https://duhoctms.edu.vn/wp-content/uploads/2021/07/dien-tich-nuoc-anh-1-2.jpg',
      listAnswer: [
        { id: 1, ans: 'Đáp án A' },
        { id: 2, ans: 'Đáp án B' },
        { id: 3, ans: 'Đáp án C' },
        { id: 4, ans: 'Đáp án D' },
      ],
      selected: null,
      isMultipleSelect: true,
    },
  ];
  constructor(private htppService: HttpService) {}
  ngOnInit() {
    this.htppService.HttpGet('Quizs').subscribe((data) => {
      console.log(data);
      this.datas = data;
    });
  }

  Submit() {
    console.log(this.datas);
  }
  SelectChange(value: string[], id: number): void {
    this.datas.find((x) => x.id == id).selected = value;
  }
}
