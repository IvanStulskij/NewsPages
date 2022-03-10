import { Component, Input, OnInit } from '@angular/core';
import {Observable} from "rxjs";
import {InspectionApiService} from "../../inspection-api.service";

@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.css']
})

export class ShowInspectionComponent implements OnInit {
  newsPagesList$!: Observable<any[]>;
  wordsAtNewsPage$!: Observable<string[]>;
  selectedItem$!: any;


  constructor(private service: InspectionApiService) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.newsPagesList$ = this.service.getNewsPage();
  }

  getWordsAtPage(url: string, wordPart: string){
    this.wordsAtNewsPage$ = this.service.findByWordPart(url, wordPart);
  }

  @Input() newsPage: any;
  id: number = 0;
  text_html: string = "";
  text: string = "";
  url: string = "";
  title: string = "";
  date: string = "";
}
