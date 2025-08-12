import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/Services/api-service.service';
import { InsertCategoriesDataModel, InsertProductDataModel } from '../../master/model/insert-categories.model';
import { categoriesDeleteFormData, ProductDeleteFormData } from 'src/app/Components/models/categories.model';

@Component({
  selector: 'app-add-categories-product-main',
  templateUrl: './add-categories-product-main.component.html',
  styleUrls: ['./add-categories-product-main.component.scss']
})
export class AddCategoriesProductMainComponent implements OnInit {
  ngOnInit(): void {
    this.getCategoriesProductDataList();
  }

  constructor(
    private api: ApiService
  ) { }
  // popup
  categoryVisible: boolean = false;
  productVisible: boolean = false;
  // valiavble
  categoryTextValue: string = "";
  productTextValue: string = "";
  isProgram: boolean = false;

  categoryDataList: Array<any> = [];
  productDataList: Array<any> = [];

  // columns = [
  //   { dataField: 'issueCategoriesId', caption: 'id' , width: 200 },
  //   { dataField: 'categoryName', caption: 'ชื่อ', width: 80 },
  //   { dataField: 'date', caption: 'วันที่', width: 150 },
  // ];

  // columns = [
  //   { dataField: 'issueCategoriesId', caption: 'id', width: 80, alignment: 'center' },
  //   { dataField: 'categoryName', caption: 'ชื่อ', width: 150, alignment: 'left' },
  //   {
  //     dataField: 'isActive',
  //     caption: 'สถานะ',
  //     width: 100,
  //     alignment: 'center',

  //   }, {
  //     dataField: 'isProgramIssue',
  //     caption: 'ปัญหาโปรแกม',
  //     width: 100,
  //     alignment: 'center',

  //   },
  //   {
  //     dataField: 'createTime',
  //     caption: 'Create Time',
  //     width: 150,
  //     alignment: 'center',
  //     cellTemplate: 'dateCellTemplate'
  //   },
  //   {
  //     dataField: 'modifiedTime',
  //     caption: 'Modified Time',
  //     width: 100,
  //     alignment: 'center',
  //     cellTemplate: 'dateCellTemplate'
  //   },
  // ];


  categoryPopupShow() {
    this.categoryVisible = true;
  }
  productPopupShow() {
    this.productVisible = true;
  }


  // onCheckboxChanged(e: any) {
  //   console.log("Checkbox value:", e.value); // true หรือ false
  // }

  categoryPopupHide() {
    this.categoryVisible = false;
    this.categoryTextValue = ''
    this.isProgram = false;

  }
  productPopupHide() {
    this.productVisible = false;
    this.productTextValue = ''

  }

  onTextValueChanged(e: any) {
    this.categoryTextValue = e.value;
  }
  onProductTextValueChanged(e: any) {
    this.productTextValue = e.value;
  }



  testLog() {

    console.log(this.categoryTextValue,
      this.isProgram);
    console.log(this.productTextValue);

  }
  getCategoriesProductDataList() {

    this.api.get("api/GET/Categories/item").subscribe((res: any) => {


      this.categoryDataList = res
    })

    this.api.get("api/GET/Products/item").subscribe((res: any) => {


      this.productDataList = res
    })

  }


  onCategoriesSubmit() {

    var data: InsertCategoriesDataModel = {
      categoryName: this.categoryTextValue,
      isProgramIssue: this.isProgram

    }

    this.api.post('api/InsertCategories/add-categories', data).subscribe((res: any) => {

      console.log(res);

      this.getCategoriesProductDataList();

      return this.categoryPopupHide()
    })
  }

  onProductSubmit() {

    var data: InsertProductDataModel = {
      productName: this.productTextValue,

    }

    this.api.post('api/InsertCategories/add-product', data).subscribe((res: any) => {
      console.log(res);

      this.getCategoriesProductDataList();

      return this.productPopupHide()


    })
  }


  onDeleteCategory(data: categoriesDeleteFormData) {

    var newData : categoriesDeleteFormData= {
      issueCategoriesId: data.issueCategoriesId,
      issueCategoriesName: data.issueCategoriesName,
    }


    this.api.post(`api/DELETE/Categories`, newData).subscribe((res: any) => {

      console.log(res);
      this.getCategoriesProductDataList();
    });


  }
  onDeleteProduct(data: ProductDeleteFormData) {

    var newData: ProductDeleteFormData = {
      productId: data.productId,
      productName: data.productName,

    }


    this.api.post(`api/DELETE/Product`, newData).subscribe((res: any) => {

      console.log(res);
      this.getCategoriesProductDataList();
    });


  }

}
