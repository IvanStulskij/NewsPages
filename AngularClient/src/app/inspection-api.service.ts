import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {

  readonly inpectionApiURL = "https://localhost:7092/NewsPages"

  constructor(private http$: HttpClient) {
  }

  getNewsPage() : Observable<any[]>{
    return this.http$.get<any[]>(this.inpectionApiURL + "/GetAllPages");
  }

  findByWord(newsPageId: number) : Observable<string[]>{
    return this.http$.get<string[]>(this.inpectionApiURL + "/NewsPages/FindByWord");
  }

  addNewsPage(url : string){
    //this.http$.
    /*this.http({
      url: this.inpectionApiURL + "/NewsPages",
      method: "POST"
    });*/
    return this.http$.post( this.inpectionApiURL + "/AddByUrl?url=", url);
  }

  updateNewsPage(id: number|string, data : any){
    return this.http$.put(this.inpectionApiURL + '/NewsPages', data)
  }

  deleteNewsPage(id: string|number, data : any){
    return this.http$.delete(this.inpectionApiURL + `?id=` + id, data)
  }

  deleteById(id : number|string){
    return this.http$.delete(this.inpectionApiURL + `?id=` + id);
  }

  deleteByUrl(url: string){

  }
}
