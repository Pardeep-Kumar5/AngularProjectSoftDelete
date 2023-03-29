import { StudentService } from './../student.service';
import { Component } from '@angular/core';
import { Student } from '../student';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.scss']
})
// const file = event.target.files[0];

export class StudentComponent {
  studentlist:Student[]=[];
  newStudent:Student=new Student();
  editStudent:Student=new Student();
  
  constructor(private studservice:StudentService){}
  
  ngOnInit()
  {
    this.Getall();
  }
 
  Getall()
  {
    this.studservice.getStudent().subscribe(
      (Response)=>{
        this.studentlist=Response;
        console.log(this.studentlist);
      },
      (error)=>{
        console.log(error);
      }
    );
  }
  Save(){
    
    this.studservice.postStudent(this.newStudent).subscribe(
      (response)=>{
this.Getall();
this.newStudent.name="";
this.newStudent.address="";
this.newStudent.phoneNumber="";
      }
    )
  }
  EditClick(Stu:Student)
  {
    //alert(Student.name)
    this.editStudent=Stu;
  }
  UpdateClick()
  {
    alert(this.editStudent.name)
    this.studservice.updateStudent(this.editStudent).subscribe(
      (response)=>{
        this.Getall();
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  deleteclick(id:number)
  {
    alert(id);
    this.studservice.DeleteStudent(id).subscribe(
      (response)=>{
      this.Getall();
    },
    (error)=>{
      console.log(error)
    }
    );
  }
}

