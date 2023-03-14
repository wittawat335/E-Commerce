import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserService } from 'src/app/shared/services/user.service';

import { User } from 'src/app/shared/models/user';
import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css'],
})
export class DeleteComponent implements OnInit {
  constructor(
    private UserService: UserService,
    private dialog: MatDialogRef<DeleteComponent>,
    @Inject(MAT_DIALOG_DATA)
    public userDelete: User
  ) {}
  ngOnInit(): void {}

  delete() {
    if (this.userDelete) {
      this.dialog.close('delete');
    }
  }
}
