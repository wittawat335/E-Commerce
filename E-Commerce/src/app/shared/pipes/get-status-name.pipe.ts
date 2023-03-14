import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'getStatusName',
})
export class GetStatusNamePipe implements PipeTransform {
  transform(value: any): any {
    if (value == 'A') {
      return 'Active';
    } else {
      return 'InActive';
    }
  }
}
