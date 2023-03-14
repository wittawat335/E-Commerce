import { Pipe, PipeTransform } from '@angular/core';
import { DepartmentService } from '../services/department.service';

@Pipe({
  name: 'getDepartmentName',
})
export class GetDepartmentNamePipe implements PipeTransform {
  private data: any = null;
  constructor(private service: DepartmentService) {}

  transform(value: number): any {
    if (value == 1) {
      return 'admin';
    } else if (value == 2) {
      return 'customer';
    } else if (value == 3) {
      return 'Owner';
    }
    // this.service.getNameById(value).subscribe({
    //   next: (data) => {
    //     if (data.status) {
    //       this.data = data.value.name;
    //     } else {
    //       this.data = 'No Data';
    //     }
    //     // if (data.status) this.result = data.value;
    //     console.log(this.data);
    //     return this.data;
    //   },
    //   error: (e) => {},
    // });
  }
}
