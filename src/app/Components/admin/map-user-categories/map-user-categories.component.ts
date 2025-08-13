import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/Services/api-service.service';
import { MappingCategoriesModel, SetUserIdUserName, UnMappingCategoriesModel } from '../models/mapping.model';

@Component({
  selector: 'app-map-user-categories',
  templateUrl: './map-user-categories.component.html',
  styleUrls: ['./map-user-categories.component.scss']
})
export class MapUserCategoriesComponent implements OnInit {
  ngOnInit(): void {
    this.getUserByRoleSupport()
    // this.getUnmappedCategoriesItem()
    // this.getMappedCategoriesItem()
  }

  constructor(
    private api: ApiService
  ) { }

  userDataList: any;
  labelUsername: string = 'unknown'
  labelRole: string = 'unknown'
  mapDetailVisible: boolean = false;
  globalId: number = 0;
  unmappedItem: UnMappingCategoriesModel[] = [];
  mappedItem: MappingCategoriesModel[] = []




  getUserByRoleSupport() {
    this.api.get("api/GET/userByRole").subscribe((res: any) => {
      // console.log(res);

      this.userDataList = res
    })

  }
  // label 


  onMapDetailPopupHide() {
    this.mapDetailVisible = false;
  }
  onMapDetailPopupShow(data: any) {
    this.globalId = data.userId
    this.labelUsername = data.username
    this.labelRole = data.roleName

    this.getUnmappedCategoriesItem(data.userId)
    this.getMappedCategoriesItem(data.userId)

    this.mapDetailVisible = true;
    // console.log(data);



  }
  productPopupHide() {
    this.mapDetailVisible = false
  }

  getUnmappedCategoriesItem(id: number) {
    this.api.get(`api/GET/mappedUserId/${id}`).subscribe((res: any) => {
      this.mappedItem = res
      // console.log(res);



    })
  }

  getMappedCategoriesItem(id: number) {
    this.api.get(`api/GET/unmappedUserId/${id}`).subscribe((res: any) => {
      this.unmappedItem = res
      // console.log(res);


    })
  }

  onMapSubmit(data: any) {
    var newData = {
      userId: this.globalId,
      issueCategoriesId: data.issueCategoriesId

    }


    this.api.post(`api/MAP/MappingUserCategories`, newData).subscribe((res: any) => {
      // console.log(res);

      this.getMappedCategoriesItem(this.globalId)
      this.getUnmappedCategoriesItem(this.globalId)
    })

  }

  onUnMapSubmit(data: any) {
    var newData  = {
      userId: this.globalId,
      issueCategoriesId: data.issueCategoriesId,
      createTime : data.createTime

    }
    
    this.api.post(`api/MAP/UnmappingUserCategories`, newData).subscribe((res: any) => {
      // console.log(res);

      this.getMappedCategoriesItem(this.globalId)
      this.getUnmappedCategoriesItem(this.globalId)
    })

  }



  // 
}
