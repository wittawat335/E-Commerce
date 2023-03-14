import { UserService } from './../../shared/services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatPaginator } from '@angular/material/paginator';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { User } from 'src/app/shared/models/user';
import { AddEditComponent } from './dialog/add-edit/add-edit.component';
import { DeleteComponent } from './dialog/delete/delete.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css'],
})
export class UsersComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'Id',
    'Email',
    'Mobile',
    'Role',
    'Status',
    'CreatedAt',
    'ModifiedAt',
    'Actions',
  ];
  data = new MatTableDataSource<User>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private snackbar: MatSnackBar,
    private UserService: UserService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar
  ) {}

  applyFilter(event: Event) {
    const value = (event.target as HTMLInputElement).value;
    this.data.filter = value.trim().toLowerCase();
  }

  show() {
    this.UserService.getList().subscribe({
      next: (data) => {
        if (data.status) {
          this.data.data = data.value;
        }
      },
      error: (e) => {},
    });
  }

  ngOnInit(): void {
    this.show();
  }
  ngAfterViewInit(): void {
    this.data.paginator = this.paginator;
  }
  addNewUser() {
    this.dialog
      .open(AddEditComponent, {
        disableClose: true,
        width: '400px',
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'created') {
          this.show();
        }
      });
  }

  viewUser(user: User) {
    this.dialog
      .open(AddEditComponent, {
        disableClose: false,
        data: user,
        width: '400px',
      })
      .afterClosed();
  }

  editUser(user: User) {
    this.dialog
      .open(AddEditComponent, {
        disableClose: true,
        data: user,
        width: '400px',
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'Updated') {
          this.show();
        }
      });
  }

  deleteUser(user: User) {
    this.dialog
      .open(DeleteComponent, {
        disableClose: true,
        data: user,
        width: '400px',
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'delete') {
          this.UserService.delete(user.id).subscribe({
            next: (data) => {
              if (data.status) {
                this.showAlert('deleted', 'success');
                this.show();
              } else {
                this.showAlert('Error', 'error');
              }
            },
            error(err) {},
          });
        }
      });
  }

  showAlert(msg: string, title: string) {
    this.snackBar.open(msg, title, {
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 3000,
    });
  }
}
