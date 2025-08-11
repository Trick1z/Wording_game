import { Component, OnInit } from '@angular/core';
import { ValueChangedEvent } from 'devextreme/ui/filter_builder';
import { ValueChangedEvent as TagValueChangedEvent } from 'devextreme/ui/tag_box';
import { CategoriesDataModel, ProductsDataModel } from './model/tag-option.model';
import { ApiService } from 'src/app/Services/api-service.service';
// import { ApiService } from 'src/app/Services/api-service.service';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.scss']
})
export class MasterComponent implements OnInit {
  categoryVisible = false;
  productVisible = false;

  dataList: any;
  columns = [
    { dataField: 'word', caption: 'คำ', width: 200 },
    { dataField: 'score', caption: 'คะแนน', width: 80 },
    { dataField: 'date', caption: 'วันที่', width: 150 }
  ];

  categoryTextValue: string = '';
  categorySelectedTags: number[] = [];
  productTextValue: string = '';
  productSelectedTags: number[] = [];


  // categoriesTagOptions = [
  //   { id: 1, name: 'Angular' },
  //   { id: 2, name: 'DevExtreme' },
  //   { id: 3, name: 'TypeScript' },
  //   { id: 4, name: 'C#' }
  // ];

  categoriesTagOptions: CategoriesDataModel[] = [];
  ProductTagOptions: ProductsDataModel[] = [];

  ngOnInit(): void {
    this.getCategoriesProductData();
    this.getCategoryProductItemDetail();
  }

  constructor(
    private api: ApiService
  ) { }

  onProductSaveData() {
    console.log('Text:', this.productTextValue);
    console.log('Tags:', this.productSelectedTags);
    // สามารถส่งไป backend หรือทำอย่างอื่นต่อ
  }
  onCategorySaveData() {
    console.log('Text:', this.categoryTextValue);
    console.log('Tags:', this.categorySelectedTags);
    // สามารถส่งไป backend หรือทำอย่างอื่นต่อ
  }



  onTextValueChanged(e: any) {
    const event = e as ValueChangedEvent;
    this.categoryTextValue = event.value;
  }

  onSelectedTagsChanged(e: any) {
    const event = e as TagValueChangedEvent;

    this.categorySelectedTags = e.value;
  }

  onProductTextValueChanged(e: any) {
    const event = e as ValueChangedEvent;
    this.productTextValue = event.value;
  }

  onProductSelectedTagsChanged(e: any) {
    const event = e as TagValueChangedEvent;

    this.productSelectedTags = e.value;
  }


  // category popup
  categoryPopupShow() {
    this.categoryVisible = true;
  }

  categoryPopupHide() {
    this.categoryVisible = false;
  }

  // products
  productPopupShow() {
    this.productVisible = true;
  }

  productPopupHide() {
    this.productVisible = false;
  }

  // get [products , category ] data
  getCategoryProductItemDetail() {

    this.api.get("api/GET/Categories/item").subscribe((res: any) => {
      this.categoriesTagOptions = res

    })

    this.api.get("api/GET/Products/item").subscribe((res: any) => {
      this.ProductTagOptions = res
    })
  }

  getCategoriesProductData(){
    this.api.get("api/GET/Products").subscribe((res: any) => {
      this.ProductTagOptions = res
    })

  }
}
