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
  CategoriesName: string = '';

  globalId: number = 0;

  // categoriesTagOptions = [
  //   { id: 1, name: 'Angular' },
  //   { id: 2, name: 'DevExtreme' },
  //   { id: 3, name: 'TypeScript' },
  //   { id: 4, name: 'C#' }
  // ];

  categoriesDataList: CategoriesDataModel[] = [];
  ProductTagOptions: ProductsDataModel[] = [];

  ngOnInit(): void {
    // this.getCategoriesProductData();
    this.getCategoryProductItemDetail();
  }

  constructor(
    private api: ApiService
  ) { }




  onSelectedTagsChanged(e: any) {
    const event = e as TagValueChangedEvent;

    this.categorySelectedTags = e.value;
  }


  onProductSelectedTagsChanged(e: any) {
    const event = e as TagValueChangedEvent;

    this.productSelectedTags = e.value;
  }


  // products
  productPopupShow(data: any) {
    this.productVisible = true;
    this.CategoriesName = data.issueCategoriesName;
    this.globalId = data.issueCategoriesId;
    this.getProductItem(data.issueCategoriesId);
  }

  productPopupHide() {
    this.productVisible = false;
    this.productSelectedTags = []
  }

  // get [products , category ] data
  getCategoryProductItemDetail() {

    this.api.get("api/GET/Categories/item").subscribe((res: any) => {
      this.categoriesDataList = res
      // console.log(res);

    })


  }


  getProductItem(id: number) {
    this.api.get(`api/GET/unmappedCategories/${id}`).subscribe((res: any) => {
      this.ProductTagOptions = res
      console.log(res);

    })


  }

    onProductSaveData() {
    // console.log('id:', this.globalId);
    // console.log('Tags:', this.productSelectedTags);
    // สามารถส่งไป backend หรือทำอย่างอื่นต่อ


    var newData = {
      categoriesId : this.globalId,
      productsId : this.productSelectedTags

    }
    this.api.post(`api/MAPS/MappingCategoriesProduct` , newData).subscribe((res :any )=> {

      console.log(res);
      
    })
  }



  // getCategoriesProductData(){
  //   this.api.get("api/GET/Products").subscribe((res: any) => {
  //     this.ProductTagOptions = res
  //   })

  // }
}
