import { GetStatusNamePipe } from './get-status-name.pipe';

describe('GetStatusNamePipe', () => {
  it('create an instance', () => {
    const pipe = new GetStatusNamePipe();
    expect(pipe).toBeTruthy();
  });
});
