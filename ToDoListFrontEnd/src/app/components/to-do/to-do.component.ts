import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ResponseObject } from 'src/app/models/ResponseObject';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-to-do',
  templateUrl: './to-do.component.html',
  styleUrls: ['./to-do.component.css']
})
export class ToDoComponent implements OnInit {
  taskName: string;
  toDoList: any;
  isAdd: boolean;

  constructor(
    private toDoService: TodoService
  ) { }

  ngOnInit(): void {
    this.getTodoList();
  }

  getTodoList() {
    this.toDoService.getToDoList().subscribe((response: ResponseObject) => {
      if (response.statusCode === 200) {
        this.toDoList = response.result;
      }
    },
      (err: HttpErrorResponse) => {
        console.log(err.message);
      });
  }

  addTask() {
    if (this.taskName) {
      this.toDoService.addTask(this.taskName).subscribe((response: ResponseObject) => {
        if (response.statusCode === 200) {
          this.toDoList = response.result;
          this.isAdd = false;
        }
      },
        (err: HttpErrorResponse) => {
          console.log(err.message);
        });
    } else{
      alert('Please add task name');
    }
  }

  onChecked(Id: number, status: boolean) {
    if (Id > 0) {
      this.toDoList.forEach(element => {
        if (element.taskId === Id)
          element.taskStatus = status;
      });
      this.toDoService.updateTaskStatus(Id, status).subscribe((response: ResponseObject) => {
        if (response.statusCode === 200) {
          this.toDoList = response.result;
          this.isAdd = false;
        }
      },
        (err: HttpErrorResponse) => {
          console.log(err.message);
        });
    }
  }
}
