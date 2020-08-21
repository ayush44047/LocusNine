import { Injectable } from '@angular/core';
import { FormGroup, FormControl ,Validators} from "@angular/forms";
import { Observable , throwError  } from 'rxjs';
import { HttpClient, HttpErrorResponse  } from '@angular/common/http';
import { User } from '../../app/Models/user';
import { catchError } from 'rxjs/operators';



@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  getUsers(): Observable<User[]> {
    let tempVar = this.http.get<User[]>('https://localhost:44303/api/user').pipe(catchError(this.errorHandler));
    return tempVar;
    
  }
  getRoles(): Observable<any[]> {
    let tempVar = this.http.get<any[]>('https://localhost:44303/api/roles').pipe(catchError(this.errorHandler));
    return tempVar;

  }
  insertUser(user): Observable<boolean> {
    console.log(user);
    return this.http.post<boolean>('https://localhost:44303/api/user', user).pipe(catchError(this.errorHandler));
 
  }
  updateUser(user): Observable<boolean>{
    return this.http.put<boolean>('https://localhost:44303/api/user/updateuser', user).pipe(catchError(this.errorHandler));
  }
  deleteUser(userid){
    return this.http.delete<boolean>('https://localhost:44303/api/user?userid='+userid).pipe(catchError(this.errorHandler));
  }

  populateForm(user) {
    this.form.setValue(user);

  }

  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }
  


form: FormGroup = new FormGroup({
    userid: new FormControl(),
    fullname: new FormControl('',  Validators.required),
    email: new FormControl('', Validators.compose([Validators.required ,Validators.email])),
    mobile: new FormControl('' ,Validators.compose([Validators.minLength(10),Validators.maxLength(10),Validators.pattern('^[0-9]*$')])),
    rolename : new FormControl('Admin'),
    roleid : new FormControl('1',Validators.required)
  });


}
