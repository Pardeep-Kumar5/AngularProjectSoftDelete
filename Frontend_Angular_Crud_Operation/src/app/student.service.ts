import { Student } from './student';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient}from '@angular/common/http'


@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpclient:HttpClient) { }
  getStudent():Observable<any>
  {
    return this.httpclient.get<any>('https://localhost:44388/api/Student')
  }
  postStudent(newt:Student):Observable<Student>
  {
    return this.httpclient.post<Student>('https://localhost:44388/api/Student',newt)
  }
  updateStudent(editStudent:Student):Observable<Student>
  {
    return this.httpclient.put<Student>('https://localhost:44388/api/Student',editStudent)
  }
  DeleteStudent(id:number):Observable<any>
  {
    return this.httpclient.delete<any>("https://localhost:44388/api/Student?id="+id)
  }
}
