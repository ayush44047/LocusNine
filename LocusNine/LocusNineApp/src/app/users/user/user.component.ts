import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { MatDialogRef } from '@angular/material';
import { IconService } from '../../shared/icon.service';
import { NotificationService } from '../../shared/notification.service';
import { MatSnackBar } from '@angular/material';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  roles:any[] ;
status:boolean;
status2;
errorMsg:string;
  
  constructor(private service:UserService,public dialogRef:MatDialogRef<UserComponent>,private iconService:IconService
  ,private notificationService:NotificationService) { 
    this.iconService.registerIcons();
  }

  ngOnInit() {
    this.getRoles();

  }
  getRoles() {

    this.service.getRoles().subscribe(
      (responseData : any[])=> {
          this.roles=responseData;
           
      });    
      
  }


  onSubmit() {
    if (this.service.form.valid)
    console.log(this.service.form.get('userid').value); {
      if (this.service.form.get('userid').value==null)      {
        
        this.service.insertUser(this.service.form.value).subscribe(
          
          responseLoginStatus => {            
            this.status = responseLoginStatus;
          },
          responseLoginError => {
            this.errorMsg = responseLoginError;
          },
          () => console.log("Insert  Form method executed successfully")
        );
        
      
      }
      else
      {
        console.log("here");
        console.log(this.service.form.value);
      this.service.updateUser(this.service.form.value).subscribe(
          
        responseLoginStatus => {
          
          this.status = responseLoginStatus;
        },
        responseLoginError => {
          this.errorMsg = responseLoginError;
        },
        () => console.log("Update Form method executed successfully")
      );
    }
      this.service.form.reset();
     
      this.notificationService.success(":: Submitted successfully");
      this.onClose();
    }
  }

  onClose() {
    this.service.form.reset();
    this.dialogRef.close();
 
  }

  onDelete(userid){
    console.log(userid);
    if(confirm('Are you sure to delete this record ?')){
    this.service.deleteUser(userid).subscribe(
      responseStatus => {
        this.status2 = responseStatus;
        if (this.status2) {
          this.notificationService.warn('! Deleted successfully');
          this.ngOnInit();
        }
        else {
          alert(this.status2);
        }
      },
      responseError => {
        this.errorMsg = responseError;
        this.notificationService.warn('Oops! Something went wrong');
      },
      () => console.log("RemoveUser executed successfully")
    );;
    
    this.dialogRef.close();
    }
}

}
