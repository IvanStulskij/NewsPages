import {Component, OnInit} from '@angular/core';
import {InspectionApiService} from "../../inspection-api.service";
import {Observable} from "rxjs";

@Component({
  selector: 'app-add-edit-inspection',
  templateUrl: './add-edit-inspection.component.html',
  styleUrls: ['./add-edit-inspection.component.css']
})
export class AddEditInspectionComponent implements OnInit {

  constructor(private service: InspectionApiService) { }

  ngOnInit(): void {

  }

  addByURL(url: string) : void{
    if (url != ""){
      this.service.addNewsPage(url).subscribe({
        next: () => {
          alert("news page added");
        },
        error: () => {
          alert("error")
        }
      });
    }
  }

  delete(url: string){
    if (url != ""){
      this.service.deleteByUrl(url).subscribe({
        next: () => {
          alert("news page deleted");
        },
        error: () => {
          alert("error")
        }
      });
    }
  }
}
