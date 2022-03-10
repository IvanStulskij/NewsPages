import { Component, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {InspectionApiService} from "../inspection-api.service";

@Component({
  selector: 'app-inspection',
  templateUrl: './inspection.component.html',
  styleUrls: ['./inspection.component.css']
})
export class InspectionComponent implements OnInit {
  newsPagesList$!: Observable<any[]>;
  selectedItem$!: any;

  constructor(private service: InspectionApiService) { }

  ngOnInit(): void {
    this.newsPagesList$ = this.service.getNewsPage();
  }

}
