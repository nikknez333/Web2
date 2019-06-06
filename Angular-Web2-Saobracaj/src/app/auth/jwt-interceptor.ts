import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor() { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        console.log("Intercepted");
        // add authorization header with jwt token if available
        let jwt = localStorage.getItem('token');
        console.log("Token : ", jwt);
        if (jwt != null) {

            console.log(request)
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${jwt}`
                }
            });
            console.log(request)
        }

        return next.handle(request);
    }
}