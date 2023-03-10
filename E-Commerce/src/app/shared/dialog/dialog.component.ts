import { UserService } from './../services/user.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, Inject, OnInit } from '@angular/core';
import * as moment from 'moment';
import { ThisReceiver } from '@angular/compiler';
import { MAT_DATE_FORMATS } from '@angular/material/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSelect } from '@angular/material/select';
import { User } from '../models/user';

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
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css'],
  providers: [{ provide: MAT_DATE_FORMATS, useValue: MY_DATE_FORMATS }],
})
export class DialogComponent implements OnInit {
  hide = true;
  formUser: FormGroup;
  action: string = 'Add';
  actionButton: string = 'Save';
  list: User[] = [];

  constructor(
    private dialog: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA)
    public userData: User,
    private fb: FormBuilder,
    private snackBar: MatSnackBar,
    private userService: UserService
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
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(15),
        ],
      ],
      createdAt: [Validators.required],
      modifiedAt: [Validators.required],
    });

    this.userService.getList().subscribe({
      next: (data) => {
        if (data.status) this.list = data.value;
      },
      error: (e) => {},
    });
  }

  ngOnInit(): void {}

  showAlert(msg: string, title: string) {
    this.snackBar.open(msg, title, {
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 3000,
    });
  }

  addEdit() {
    const model: User = {
      id: 0,
      firstName: this.formUser.value.firstName,
      lastName: this.formUser.value.lastName,
      email: this.formUser.value.email,
      address: this.formUser.value.address,
      mobile: this.formUser.value.mobile,
      password: this.formUser.value.password,
      role: this.formUser.value.role,
      status: this.formUser.value.status,
      createdAt: moment(this.formUser.value.createdAt).format('DD/MM/YYYY'),
      modifiedAt: moment(this.formUser.value.modifiedAt).format('DD/MM/YYYY'),
    };

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
  }
}
