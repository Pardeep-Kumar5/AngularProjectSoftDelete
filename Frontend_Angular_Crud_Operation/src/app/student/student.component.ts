import { StudentService } from './../student.service';
import { Component } from '@angular/core';
import { Student } from '../student';
import Swal from 'sweetalert2';



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
  imageStudent:Student=new Student();
  img:any;
  constructor(private studservice:StudentService){}
  ngOnInit()
  {
    this.Getall();
  }
  onFileSelected(event: any) {
   
    const file: File = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = (event:any) => {
      this.img=event.target.result;
      const base64Image: any = reader.result as string
      console.log(base64Image); // This is the base64 encoded image
      this.imageStudent.image=base64Image
      this.editStudent.image=base64Image
    };
  }

//   saveImage()
//   {
//     this.studservice.saveimage(this.imageStudent)
     
// this.Getall
// this.newStudent.name="";
// this.newStudent.address="";
// this.newStudent.phoneNumber="";
      
//   }

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
  saveimage(){
    
    this.studservice.postStudent(this.imageStudent).subscribe(
      (response)=>{
this.Getall();
this.imageStudent.name="";
this.imageStudent.address="";
this.imageStudent.phoneNumber="";
this.imageStudent.image="";
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
    Swal.fire({  
      title: 'Are you sure want to remove?',  
      text: 'You will not be able to recover this file!',  
      icon: 'warning',  
      showCancelButton: true,  
      confirmButtonText: 'Yes, delete it!',  
      cancelButtonText: 'No, keep it'  
    }).then((result) => {  
      if (result.value) {  
        this.studservice.DeleteStudent(id).subscribe(
      
          (response)=>{
            
         
          this.Getall();
        }
        )
        Swal.fire(  
          'Deleted!',  
          'Your imaginary file has been deleted.',  
          'success'  
        )  
      } else if (result.dismiss === Swal.DismissReason.cancel) {  
        Swal.fire(  
          'Cancelled',  
          'Your imaginary file is safe :)',  
          'error'  
        )  
      }  
    })  
   
  }

}

