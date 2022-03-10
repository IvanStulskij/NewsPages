import { Component, OnInit } from '@angular/core';
import {InspectionApiService} from "../../inspection-api.service";
import {Observable} from "rxjs";

@Component({
  selector: 'app-add-edit-inspection',
  templateUrl: './add-edit-inspection.component.html',
  styleUrls: ['./add-edit-inspection.component.css']
})
export class AddEditInspectionComponent implements OnInit {
  baseUrl$!: string;
  elements$!: Observable<any>;

  constructor(private service: InspectionApiService) { }

  ngOnInit(): void {

  }

  addByURL(url: string) : void{
    this.service.addNewsPage(url).subscribe({
      next: (result) => {
        alert("news page added");
      },
      error: () => {
        alert("error")
      }
    });
  }

  delete(url: string){
    this.service.deleteByUrl(url).subscribe({
      next: (result) => {
        alert("news page deleted");
      },
      error: () => {
        alert("error")
      }
    });
  }
}
