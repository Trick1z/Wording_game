export class AuthRoute {
    static prefix: string = `auth`;

    static Login: string = `login`;
    static LoginFullPath: string = `${AuthRoute.prefix}/${AuthRoute.Login}`;
    // register path
    static Register: string = `register`;
    static RegisterFullPath: string = `${AuthRoute.prefix}/${AuthRoute.Register}`;

    // static TransferRequestEntry: string = `transfer-request-entry`;
    // static TransferRequestEntryFullPath: string = `${TransferRoute.prefix}/${TransferRoute.TransferRequestEntry}`;

    // static TransferRequestView: string = `transfer-request-view`;
    // static TransferRequestViewFullPath: string = `${TransferRoute.prefix}/${TransferRoute.TransferRequestView}`;

    // static TransferApproveList: string = `transfer-approve-list`;
    // static TransferApproveListFullPath: string = `${TransferRoute.prefix}/${TransferRoute.TransferApproveList}`;

    // static TransferApproveEntry: string = `transfer-approve-entry`;
    // static TransferApproveEntryFullPath: string = `${TransferRoute.prefix}/${TransferRoute.TransferApproveEntry}`;

    // static TransferRequestAccountList: string = `transfer-request-account-list`
    // static TransferRequestAccountListFullPath: string = `${TransferRoute.prefix}/${TransferRoute.TransferRequestAccountList}`

    // static TransferRequestAccountEntry: string = `transfer-request-account-entry`
    // static TransferRequestAccountEntryFullPath: string = `${TransferRoute.prefix}/${TransferRoute.TransferRequestAccountEntry}`

    // static TransferRequestFOList: string = `transfer-request-fo-list`
    // static TransferRequestFOListFullPath: string = `${TransferRoute.prefix}/${TransferRoute.TransferRequestFOList}`

    // static TransferRequestFOEntry: string = `transfer-request-fo-entry`
    // static TransferRequestFOEntryFullPath: string = `${TransferRoute.prefix}/${TransferRoute.TransferRequestFOEntry}`

    // static TransferRequestAdmin: string = `transfer-request-admin`
    // static TransferRequestAdminFullPath: string = `${TransferRoute.prefix}/${TransferRoute.TransferRequestAdmin}`
}