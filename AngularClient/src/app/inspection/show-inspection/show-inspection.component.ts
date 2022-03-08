import { Component, Input, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {InspectionApiService} from "../../inspection-api.service";

@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.css']
})

export class ShowInspectionComponent implements OnInit {
  constructor(private service: InspectionApiService) { }

  ngOnInit(): void {
    this.id = this.newsPage.id;
    this.text = this.newsPage.text;
    this.text_html = this.newsPage.text_html;
    this.title = this.newsPage.title;
    this.url = this.newsPage.title;
    this.date = this.newsPage.date;
  }

  @Input() newsPage: any;
  id: number = 0;
  text_html: string = "";
  text: string = "";
  url: string = "";
  title: string = "";
  date: string = "";
}
