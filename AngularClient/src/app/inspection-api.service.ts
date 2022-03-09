import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {

  readonly inpectionApiURL = "https://localhost:7092"

  constructor(private http: HttpClient) { }

  getNewsPage() : Observable<any[]>{
    return this.http.get<any[]>(this.inpectionApiURL + "/NewsPages");
  }

  addNewsPage(data : any){
    return this.http.post(this.inpectionApiURL + "/NewsPages", data);
  }

  updateNewsPage(id: number|string, data : any){
    return this.http.put(this.inpectionApiURL + '/NewsPages', data)
  }

  deleteNewsPage(id: string|number, data : any){
    return this.http.delete(this.inpectionApiURL + `/NewsPages/${id}`, data)
  }

  deleteById(id : number|string){
    return this.http.delete(this.inpectionApiURL + `/NewsPages/${id}`)
  }
}
