import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  baseUrl = environment.baseUrl;

  constructor(private http: HttpClient) { }

  getToDoList() {
    return this.http.get(this.baseUrl + 'GetToDoList');
  }

  addTask(taskName: string) {
    return this.http.get(this.baseUrl + `AddTask/${taskName}`);
  }

  updateTaskStatus(Id: number, status: boolean) {
    return this.http.get(this.baseUrl + `UpdateTask/${Id}/${status}`);
  }
}
