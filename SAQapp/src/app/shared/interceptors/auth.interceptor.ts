import { HttpInterceptorFn } from '@angular/common/http';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const SAQToken = JSON.parse(localStorage.getItem('SAQtoken')!);

  if (SAQToken?.data && req.headers.has('No_auth') === false) {
    const cloneReq = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${SAQToken.data}`)
    })

    return next(cloneReq);
  } else {
    /*if (req.headers.has('Authorization')) {
      const cloneReq = req.clone({
        headers: req.headers.delete('Authorization')
      })
*/
    //return next(cloneReq);

    //}
    return next(req);
  }

};
