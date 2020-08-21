import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { User } from '../../Models/user';
import { MatTableDataSource, MatSort, MatPaginator } from '../../../../node_modules/@angular/material';
import { IconService } from '../../shared/icon.service';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { UserComponent } from '../user/user.component';


@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: User[];
  searchKey: string;
  statusActivity = ['Active','Inactive','Pending'];


  listData: MatTableDataSource<User>;
  displayedColumns: String[] = ['fullname', 'email', 'rolename', 'status', 'actions'];
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private service: UserService, private iconService: IconService, private dialog: MatDialog) {
   
   }


  ngOnInit() {
    this.getUsers();
    this.iconService.registerIcons();
  }
  getUsers() {

    this.service.getUsers().subscribe(
      (responseData: User[]) => {
        this.users = responseData;
        this.listData = new MatTableDataSource(responseData);
        this.listData.sort = this.sort;
        this.listData.paginator = this.paginator;
      });
  }

  applyFilter() {
    this.listData.filter = this.searchKey.trim().toLowerCase();
  }

  onCreate() {
    const dialogCOnfig = new MatDialogConfig();
    dialogCOnfig.disableClose=true;
    dialogCOnfig.autoFocus=true;
    dialogCOnfig.width="25%";
    dialogCOnfig.height="60%";
    dialogCOnfig.panelClass='user-dialog';
    this.dialog.afterAllClosed.subscribe(data=> this.getUsers() )
    this.dialog.open(UserComponent,dialogCOnfig);

  }
  onEdit(row){
    this.service.populateForm(row);
    const dialogCOnfig = new MatDialogConfig();
    dialogCOnfig.disableClose=true;
    dialogCOnfig.autoFocus=true;
    dialogCOnfig.width="25%";
    dialogCOnfig.height="60%";
    dialogCOnfig.panelClass='user-dialog';
    this.dialog.afterAllClosed.subscribe(data=> this.getUsers() )
    this.dialog.open(UserComponent,dialogCOnfig);
  }
}