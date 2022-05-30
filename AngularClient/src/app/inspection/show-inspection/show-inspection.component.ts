import {Component, Input, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {InspectionApiService} from "../../inspection-api.service";

@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.scss']
})

export class ShowInspectionComponent implements OnInit {
  newsPagesList$!: Observable<any[]>;
  wordsAtNewsPage$!: Observable<string[]>;
  entitiesAtNewsPage$!: Observable<string[]>;
  selectedItem$: any;

  constructor(private service: InspectionApiService) {
  }

  ngOnInit(): void {
    this.getAll();
  }

  getAll(){
    this.newsPagesList$ = this.service.getNewsPage();
  }

  getEntitiesAtPage(url: string, entity: string){
    if (url != "" && entity != ""){
      this.entitiesAtNewsPage$ = this.service.findEntitiesAtPage(url, entity);
    }
  }

  getPagesByEntity(entity: string){
    if (entity != ""){
      this.newsPagesList$ = this.service.findPagesByEntity(entity);
    }
  }

  getPagesByName(name: string){
    if (name == ""){
      this.getAll();
    }
    else{
      this.newsPagesList$ = this.service.findPagesByName(name);
    }
  }

  getWordsAtPage(url: string, wordPart: string){
    if (url != "" && wordPart != "") {
      this.wordsAtNewsPage$ = this.service.findByWordPart(url, wordPart);
    }
  }

  @Input() newsPage: any;
  id: number = 0;
  text_html: string = "";
  text: string = "";
  url: string = "";
  title: string = "";
  date: string = "";
}
