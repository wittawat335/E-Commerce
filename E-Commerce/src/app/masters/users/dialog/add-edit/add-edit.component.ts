import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, Inject, OnInit } from '@angular/core';
import * as moment from 'moment';
import { ThisReceiver } from '@angular/compiler';
import { MAT_DATE_FORMATS } from '@angular/material/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSelect } from '@angular/material/select';
import { User } from 'src/app/shared/models/user';
import { DepartmentService } from 'src/app/shared/services/department.service';
import { Department } from 'src/app/shared/models/department';
import { UserService } from 'src/app/shared/services/user.service';

export const MY_DATE_FORMATS = {
  parse: {
    dateInput: 'DD/MM/YYYY',
  },
  display: {
    dateInput: 'DD/MM/YYYY',
    monthYearLabel: 'MMMM YYYY',
    dataA11YLabel: 'LL',
    monthYearA11yLabel: 'MMMM YYYY',
  },
};

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css'],
  providers: [{ provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }],
})
export class AddEditComponent implements OnInit {
  hide = true;
  formUser: FormGroup;
  action: string = 'Add';
  actionButton: string = 'Save';
  list: User[] = [];
  listDepartment: Department[] = [];
  //createdAt = new FormControl(new Date());
  //modifiedAt = new FormControl(new Date());

  constructor(
    private dialog: MatDialogRef<AddEditComponent>,
    @Inject(MAT_DIALOG_DATA)
    public userData: User,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private userService: UserService,
    private departmentService: DepartmentService
  ) {
    this.formUser = this.fb.group({
      firstName: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.pattern('[a-zA-Z].*'),
        ],
      ],
      lastName: [
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.pattern('[a-zA-Z].*'),
        ],
      ],
      email: ['', [Validators.required, Validators.email]],
      address: ['', [Validators.required]],
      mobile: [
        '',
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(10),
        ],
      ],
      idDepartment: ['', Validators.required],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(15),
        ],
      ],
      createdAt: ['', Validators.required],
      modifiedAt: ['', Validators.required],
    });

    // this.userService.getList().subscribe({
    //   next: (data) => {
    //     if (data.status) this.list = data.value;
    //   },
    //   error: (e) => {},
    // });
  }

  ngOnInit(): void {
    this.checkActions();
    this.getDepartment();
  }

  checkActions() {
    if (this.userData) {
      this.formUser.patchValue({
        firstName: this.userData.firstName,
        lastName: this.userData.lastName,
        email: this.userData.email,
        address: this.userData.address,
        mobile: this.userData.mobile,
        password: this.userData.password,
        idDepartment: this.userData.role,
        status: this.userData.status,
        createdAt: moment(this.userData.createdAt, 'DD/MM/YYYY'),
        modifiedAt: moment(this.userData.modifiedAt, 'DD/MM/YYYY'),
      });
      this.action = 'Edit';
      this.actionButton = 'Update';
      console.log(this.userData.role);
    }
  }

  getDepartment() {
    this.departmentService.getList().subscribe({
      next: (data) => {
        if (data.status) this.listDepartment = data.value;
      },
      error: (e) => {},
    });
  }

  showAlert(msg: string, title: string) {
    this.snackBar.open(msg, title, {
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 3000,
    });
  }

  addEdit() {
    const model: User = {
      id: this.userData == null ? 0 : this.userData.id, ///Check
      firstName: this.formUser.value.firstName,
      lastName: this.formUser.value.lastName,
      email: this.formUser.value.email,
      address: this.formUser.value.address,
      mobile: this.formUser.value.mobile,
      password: this.formUser.value.password,
      role: this.formUser.value.idDepartment,
      status: 'A',
      createdAt: moment(this.formUser.value.createdAt).format('DD/MM/YYYY'),
      modifiedAt: moment(this.formUser.value.modifiedAt).format('DD/MM/YYYY'),
    };
    if (this.userData == null) {
      ///Check Add
      this.userService.add(model).subscribe({
        next: (data) => {
          if (data.status) {
            this.showAlert('add complete', 'success');
            this.dialog.close('created');
          } else {
            this.showAlert('Error', 'Error');
          }
        },
        error(err) {},
      });
    } else {
      //Check Edit
      this.userService.update(model).subscribe({
        next: (data) => {
          if (data.status) {
            this.showAlert('Update complete', 'success');
            this.dialog.close('Updated');
          } else {
            this.showAlert('Error', 'Error');
          }
        },
        error(err) {},
      });
    }
  }
}
