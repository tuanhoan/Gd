import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment'; 

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private httpClient: HttpClient) { }
  HttpGet(url:string): Observable<any> {
    return this.httpClient.get<any>(`${environment.apiUrl}/${url}`);
  }

  public Post(url: string, data: any, newOption: any = null): Observable<any> {
    url = `${environment.apiUrl}/${url}`;
    // if (newOption != null) {
    //   this.httpOptions = newOption;
    // }
    return this.httpClient.post<any>(url, data);
  }
}