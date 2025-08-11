export class AuthRoute {
  static prefix: string = `auth`;

  static Login: string = `login`;
  static LoginFullPath: string = `${AuthRoute.prefix}/${AuthRoute.Login}`;
  // register path
  static Register: string = `register`;
  static RegisterFullPath: string = `${AuthRoute.prefix}/${AuthRoute.Register}`;

  // static LandingPage: string = `Landing`;
  // static LandingPageFullPath: string = `${AuthRoute.prefix}/${AuthRoute.LandingPage}`;
}

export class ViewsRoute {
  static prefix: string = `view`;

  static Home: string = `home`;
  static HomeFullPath: string = `${ViewsRoute.prefix}/${ViewsRoute.Home}`;
}
export class GamesRoute {
  static prefix: string = `game`;

  static Word: string = `word-scoring`;
  static WordFullPath: string = `${GamesRoute.prefix}/${GamesRoute.Word}`;
}


export class CustomerRoute {
  static prefix: string = `customer`;

  static CustomerForm: string = `form`;
  static CustomerFormFullPath: string = `${GamesRoute.prefix}/${GamesRoute.Word}`;

  static CustomerAddForm: string = `add-form`;
  static CustomerAddFormFullPath: string = `${GamesRoute.prefix}/${GamesRoute.Word}`;
}

export class UserRoute {
  static prefix: string = `user`;

  static UserForm: string = `form`;
  static UserFormFullPath: string = `${GamesRoute.prefix}/${GamesRoute.Word}`;

}

export class AdminRoute {
  static prefix: string = `admin`;

  static AdminForm: string = `master`;
  static AdminFormFullPath: string = `${GamesRoute.prefix}/${GamesRoute.Word}`;

  static AdminAddCategories: string = `categories-product`;
  static AdminAddCategoriesFullPath: string = `${GamesRoute.prefix}/${GamesRoute.Word}`;

}
