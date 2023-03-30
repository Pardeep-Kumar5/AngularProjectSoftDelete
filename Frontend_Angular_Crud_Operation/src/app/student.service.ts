import { Student } from './student';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders}from '@angular/common/http'
import Swal from 'sweetalert2';


@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private httpclient:HttpClient) { }

  saveimage(base64Image: Student) {
    // set the headers for the POST request
    // const headers = new HttpHeaders()
    //   .set('Content-Type', 'application/json');
  
    // create a data object to send to the server
    const data = {   
      image: base64Image
    };
    // send the POST request to the server-side endpoint
    this.httpclient.post('https://localhost:44388/api/Student', data).subscribe(response => {
      console.log('Image saved successfully', response);
    }, error => {
      console.error('Error saving image', error);
    });
  }
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
