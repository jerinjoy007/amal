using Gramboo.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace project.Classes
{
    class MenuControl
    {

        public static void LoadForm(string Menu, string Group,GrbTreeview treeview,Form frm)
        {
            if (Group == "Master Files")
            {
                switch (Menu )
                {

                    /* 
               
       
                       case "Manual PunchEntry":
                           ShowForm(project.Forms.HR.ManualPunchEntry.Instance, treeview.SelectedNode.Text, frm);
                           break;
                    
                    case "Employee Group Master":
                           ShowForm(project.Forms.HR.HRGroupMaster.Instance, treeview.SelectedNode.Text, frm);
                           break;
                        */


                    case "Age Group Master":
                           ShowForm(project.Forms.GENERALFORMS.AgeGrpMaster.Instance, treeview.SelectedNode.Text, frm);
                           break;
 
                       case "Menu Group Master":
                           ShowForm(project.Forms.SYST.FormMenuGroupMaster.Instance, treeview.SelectedNode.Text, frm);
                           break;
                       case "Menu Master":
                           ShowForm(project.Forms.SYST.FormMenuMaster.Instance,  treeview.SelectedNode.Text,frm);
                           break;

                       /*case "Reminder":
                           ShowForm(project.Forms.GENERALFORMS.FrmReminder.Instance, treeview.SelectedNode.Text, frm);
                           break; */


                       case "Change Password":
                           ShowForm(project.Forms.SYST.ChangePassword.Instance,  treeview.SelectedNode.Text,frm);
                           break;
                       case "User Category":
                           ShowForm(project.Forms.SYST.UserCategory.Instance,  treeview.SelectedNode.Text,frm);
                           break;
                       case "User Registration":
                           ShowForm(project.Forms.SYST.UserRegistration.Instance,  treeview.SelectedNode.Text,frm);
                           break;
                    case "PaymentandMessage":
                        ShowForm(project.Forms.ADD.PaymentandMessage.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Fee Type":
                        ShowForm(project.Forms.MST.Fee_Type.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Fee Due Date":
                        ShowForm(project.Forms.MST.Fee_Due_Date.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Fee Group":
                        ShowForm(project.Forms.MST.Fee_Group.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Fees":
                        ShowForm(project.Forms.MST.FeeDetails.Fees.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Main Schemes":
                        ShowForm(project.Forms.MST.Main_Schemes.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Additional Schemes":
                        ShowForm(project.Forms.MST.Additional_Schemes.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sub Schemes":
                        ShowForm(project.Forms.MST.Sub_Schemes.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //Add Address Type
                    case "Add Address Type":
                        ShowForm(project.Forms.MST.Addressdetails.Add_Address_Type.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Add State":
                        ShowForm(project.Forms.MST.Addressdetails.Add_State.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Add Country":
                        ShowForm(project.Forms.MST.Addressdetails.Add_Country.Instance, treeview.SelectedNode.Text, frm);
                        break;
                        /* case "Add New Book":
                            ShowForm(project.Forms.SYST.BranchMaster.Instance,  treeview.SelectedNode.Text,frm);
                            break;
                        case "Company Master":
                            ShowForm(project.Forms.SYST.CompanyMaster.Instance,  treeview.SelectedNode.Text,frm);
                            break;*/
                        
                         
 
                        case "Customer Group Master":
                            ShowForm(project.Forms.CRM.CustomerGroupMaster.Instance,  treeview.SelectedNode.Text,frm);
                            break;
                        case "Customer Type Master":
                            ShowForm(project.Forms.CRM.CustomerTypeMaster.Instance,  treeview.SelectedNode.Text,frm);
                            break;

                        case "Customer Master":
                            ShowForm(project.Forms.CRM.CustomerMasterr.Instance,  treeview.SelectedNode.Text,frm);
                            break;
  

                        


                        case "Employee Master":
                            ShowForm(project.Forms.EMP.EmployeeMaster.Instance, treeview.SelectedNode.Text, frm);
                            break;
                        //case "Booking Master":
                        //    ShowForm(project.Forms.SALE.FrmBooking.Instance, treeview.SelectedNode.Text, frm);
                        //    break;


                        case "Employee Department Master":
                            ShowForm(project.Forms.EMP.frmDepartmentMaster.Instance, treeview.SelectedNode.Text, frm);
                            break;

                        case "Employee Designation Master":
                                ShowForm(project.Forms.EMP.frmDesignationMaster.Instance, treeview.SelectedNode.Text, frm);
                            break;
                        case "Employee Type Master":
                            ShowForm(project.Forms.EMP.frmEmployeeTypeMaster.Instance, treeview.SelectedNode.Text, frm);
                            break;
                    case "Manual Punch":
                        ShowForm(project.Forms.HR.ManualPunchEntry.Instance, treeview.SelectedNode.Text, frm);
                        break;


                    default:
                               treeview.SelectedNode = treeview.Nodes[0];
                               break;



                }
            }


            else if (Group == "Transactions")
            {
                switch (Menu)
                {

                    /*case "Stock Service Issue":
                        ShowForm(new project.Forms.STOCK.StockTransferEntryNew(15), treeview.SelectedNode.Text, frm);
                        break;

                    case "Stock Service Receipt":
                        ShowForm(new project.Forms.STOCK.StockTransferEntryNew(6), treeview.SelectedNode.Text, frm);
                        break;
                    case "Membership Entry":
                        ShowForm(project.Forms.SALE.MembershipMaster.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Expiry Entry":
                        ShowForm(project.Forms.ITEM.ExpiredItems.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Consumptional Entry":
                        ShowForm(project.Forms.ITEM.FrmConceptionalmaster.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //case " Customer Repair Issue":
                    //    ShowForm(project.Forms.Services.CustomerRepairIssue.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "Customer Repair Receipt":
                    //    ShowForm(project.Forms.Services.CustomerRepairReceipt.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    case "Customer Search":
                        ShowForm(project.REPORTS.SALE.CustomerSerarch.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //case "Customer Repair Issue":
                    //    ShowForm(project.Forms.Services.CustomerRepairIssue.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    case "Customer Receipt Entry":
                        ShowForm(project.Forms.SALE.FrmCustomerReceiptEntry.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Billing Entry":
                        ShowForm(project.Forms.SALE.BillingMaster.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Booking Entry":
                        ShowForm(project.Forms.SALE.FrmBooking.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Cancellation Entry":
                        ShowForm(project.REPORTS.SALE.FrmCancellation.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //case "Services Master":
                    //    ShowForm(project.Forms.ITEM.ServiceMaster.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "Packages":
                    //    ShowForm(project.Forms.SALE.PackagesMaster.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "Booking":
                    //    ShowForm(project.Forms.SALE.FrmBooking.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "Membership Type":
                    //    ShowForm(project.Forms.SALE.MembershipTypeMaster.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "Giftvouher":
                    //    ShowForm(project.Forms.SALE.GiftVouherCode.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    case "Customer Payment Entry":
                        ShowForm(project.Forms.CRM.FrmCustomerPayment.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Customer Opening Balance":
                        ShowForm(project.Forms.ACC.CustomerOpeningBalance.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //case "BarCode Verification":
                    //    ShowForm(project.Forms.STOCK.BarCodeVerification.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "BarCode Print":
                    //    ShowForm(project.Forms.STOCK.FrmPriceList.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "Tablet Estimation":
                    //    ShowForm(project.Forms.SALE.TabletEstimation.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    
                    //case "Testing Return Entry":
                    //    ShowForm(project.Forms.STOCK.TestingReturnEntry.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    case "Purchase Entry":
                        ShowForm(project.Forms.PUR.PurchaseEntry.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    //case "Stock Transfer Issue":
                    //    ShowForm(new project.Forms.STOCK.StockTransferEntryNew(15),  treeview.SelectedNode.Text,frm);
                    //    break;
                    //case "Stock Transfer Receipt":
                    //    ShowForm(new project.Forms.STOCK.StockTransferEntryNew(6),  treeview.SelectedNode.Text,frm);
                    //    break;

                    case "Purchase Return Entry":
                        ShowForm(project.Forms.PUR.PurchaseReturnEntry.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    //case "BarCode Entry":
                    //    ShowForm(project.Forms.STOCK.StockEntry.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;
                    //case "Gold Booking":
                    //    ShowForm(project.Forms.SALE.GoldBookingMaster.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;

                    
                        ShowForm(project.Forms.SALE.frmSalesEntry.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Sales Order Entry":
                        ShowForm(project.Forms.SALE.frmSalesOrder.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //case "Metal Mix Entry":
                    //    ShowForm(project.Forms.PROD.MetalMixEntry.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;

                    //case "Supplier Settlement":
                    //    ShowForm(project.Forms.PUR.SupplierSettlement.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;

                    //case "Supplier Opening Balance Entry":
                    //    ShowForm(project.Forms.PUR.SupplierOpeningBalanceEntry.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;

                    //case "Item Conversion":
                    //    ShowForm(project.Forms.STOCK.ItemConversion.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;

                    //case "Aciding Entry":
                    //    ShowForm(project.Forms.PROD.AcidingEntry.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;
                    //case "Testing Issue Entry":
                    //    ShowForm(project.Forms.STOCK.TestingIssueEntry.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;
                    //case "Repair Receipt Entry":
                    //    ShowForm(project.Forms.STOCK.RepairEntry.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;
                    //case "Repair Issue Entry":
                    //    ShowForm(project.Forms.STOCK.RepairIssueEntry.Instance, treeview.SelectedNode.Text, frm);
                    //    break;

                    //case "BarCode Print":
                    //    ShowForm(MOD.REPORTS.STOCK.BarCodePrint.Instance, treeview.SelectedNode.Text, frm);
                    //    break;

                
                    //case "Colouring Return Entry":
                    //    ShowForm(MOD.Forms.PROD.ColouringReturn.Instance, treeview.SelectedNode.Text,frm);
                    ////    break;

                    //case "Old Gold Receipt Entry":
                    //    ShowForm(project.Forms.SALE.OldGoldReceiptNew.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;

                    
                   
                    //case "Repair Receipt Entry":
                    //      ShowForm(MOD.Forms.STOCK.RepairEntry.Instance,  treeview.SelectedNode.Text,frm);
                    //      break;

                    case "Payment":
                       FA.FORMS.IssueOrReciept frmacci = new  FA.FORMS.IssueOrReciept( );
                      //frmacci.ShowForm(
                        break;

                    case "Receipt":
                          FA.FORMS.IssueOrReciept frmaccR = new  FA.FORMS.IssueOrReciept( );
                          //ShowForm(frmaccR, treeview.SelectedNode.Text, frmaccR);   
                        break;

                    case "Sales Deletion":
                        ShowForm(project.Forms.SALE.FrmSalesDeletion.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    //case "Contra":
                    //    ShowForm(MOD.Forms.ACC.AccountingVoucher.ContraInstance,  treeview.SelectedNode.Text,frm);
                    //    break;

                    //case "Journal":
                    //    ShowForm(MOD.Forms.ACC.AccountingVoucher.JournalInstance,  treeview.SelectedNode.Text,frm);
                    //    break;
                    //case "Stock Compare Entry":
                    //    ShowForm(project.Forms.STOCK.StockCompareEntry.Instance, treeview.SelectedNode.Text, frm);
                    //    break;

                    case "Complements Purchase":
                    ShowForm(new project.Forms.PUR.ComplementsPurchase(),  treeview.SelectedNode.Text,frm);
                    break;


                    case "Department Opening Stock Entry":
                        ShowForm(project.Forms.STOCK.DepartmentOpeningStkEntry.Instance,  treeview.SelectedNode.Text,frm);
                        break;

                    //case "Adjust Entry":
                    //    ShowForm(project.Forms.STOCK.AdjustEntry.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;

                    case "Continuous Bill Print":

                        ShowForm(project.Forms.PUR.ContinuousBillPrint.Instance,  treeview.SelectedNode.Text,frm);
                        break;

                    //case "Gold Booking Cancelation":
                    //    ShowForm(project.Forms.SALE.GoldBookingCancelationEntry.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;

                    case"Advance Payment":
                           ShowForm(project.Forms.HR.AdvancePayment.Instance,  treeview.SelectedNode.Text,frm);
                        break;


                    case "Must Roll Generation":
                          ShowForm(project.Forms.HR.GenerateMustRoll.Instance,  treeview.SelectedNode.Text,frm);
                          break;

                    case "Complement Issue":
                         ShowForm(project.Forms.SALE.ComplemetIssueEntry.Instance,  treeview.SelectedNode.Text,frm);
                         break;

                    case "Accounts Generation":
                         ShowForm(new project.Forms.ACC.AccountsGeneration(), treeview.SelectedNode.Text, frm);
                         break;

                    case "Budget Variance":
                         ShowForm(new FA.FORMS.BudgetVariance(), treeview.SelectedNode.Text, frm);
                         break;
                    case "Sales Return BarCode Print":
                         ShowForm(project.Forms.SALE.FrmSalesReturnPrint.Instance, treeview.SelectedNode.Text, frm);
                         break;

                    
                    case "Cash Transaction Entry":
                         ShowForm(project.Forms.SALE.CashTransactionEntry.Instance,  treeview.SelectedNode.Text,frm);
                         break;

                    //case "Melting Entry":
                    //     ShowForm(project.Forms.PROD.MeltingEntry.Instance,treeview.SelectedNode.Text,frm);
                    //     break;

                    case "Sales Bill Settings":
                         ShowForm(project.Forms.SALE.SalesBillSettings.Instance, treeview.SelectedNode.Text, frm);
                         break;

                    //case "colouring Issue Entry":
                    //     ShowForm(project.Forms.PROD.ColoringIssueEntry.Instance, treeview.SelectedNode.Text, frm);
                    //     break;




                    case "Sales Balance Receipt Entry":
                         ShowForm(project.Forms.SALE.SalesBalanceReceiptEntry.Instance, treeview.SelectedNode.Text, frm);
                         break;

                    //case "Stock Comparison":
                    //     ShowForm(project.Forms.STOCK.StockCompareEntry.Instance, treeview.SelectedNode.Text, frm);
                    //     break;

                    case "Product Code Verification":
                         ShowForm(project.Forms.STOCK.frmStockVerification.Instance, treeview.SelectedNode.Text, frm);
                         break;
                    //case "BarCode Details":
                    //    ShowForm(project.Forms.STOCK.BarcodeDetails.Instance, treeview.SelectedNode.Text, frm);
                    //     break;
                    case"Bill Copy Print":
                            ShowForm(project.Forms.SALE.FrmBillCopyPrint.Instance, treeview.SelectedNode.Text, frm);
                         break;*/

                    

                    default:
                        treeview.SelectedNode = treeview.Nodes[0];
                        break;
                }
            }



            else if (Group == "Reports")
            {
                switch (Menu)
                {
                   /* case "Customer Repair Pending Report":
                        ShowForm(project.REPORTS.Services.CustomerRepairPendingReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "PackageWise Billing Report":
                        ShowForm(project.REPORTS.SALE.FrmPackageWiseReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "MembershipWise Billing Report":
                        ShowForm(project.REPORTS.SALE.FrmMembershipWiseReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "EmployeeWise Billing Report":
                        ShowForm(project.REPORTS.SALE.FrmEmployeeWiseBillingReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Membership Type List":
                        ShowForm(project.REPORTS.SALE.FrmMembershiptypeList.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Package List Report":
                        ShowForm(project.REPORTS.SALE.FrmpackageListReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Billing Date Wise Report":
                        ShowForm(project.REPORTS.SALE.FrmBillingDateWiseReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Customer Repair Issue Report":
                        ShowForm(project.REPORTS.Services.CustomerRepairIssueReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Customer Search":
                        ShowForm(project.REPORTS.SALE.CustomerSerarch.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Booking Reports":
                        ShowForm(project.REPORTS.SALE.BookingReports.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Membership Report":
                        ShowForm(project.REPORTS.SALE.MembershipReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Customer Receipt Report":
                        ShowForm(project.REPORTS.SALE.FrmCustomerReceiptEntryReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Customer Payment Report":
                        ShowForm(project.REPORTS.SALE.FrmCustomerPaymentEntryReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Customer Balance Report":
                        ShowForm(project.REPORTS.SALE.FrmCustomerBalanceReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Customer Transaction Report":
                        ShowForm(project.REPORTS.SALE.FrmCustomerTransaction.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Menu List":
                        ShowForm(project.REPORTS.SALE.FrmServiceMenuReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Cheque Receipt Report":
                        ShowForm(project.REPORTS.SALE.ChequeReceiptReportfrm.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Cheque Paid Report":
                        ShowForm(project.REPORTS.SALE.OldGoldReceiptReportfrm.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //case "Old Purchase Analysis":
                    //    ShowForm(project.REPORTS.SALE.OldPurchaseAnalysisReport.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    case "SalesMan Bill CountWise Summary":
                        ShowForm(project.REPORTS.SALE.RptSalesManWiseBillCount.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sales Analysis Summary":
                        ShowForm(project.REPORTS.SALE.SalesAnalysisReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //case "Customer Transaction Report":
                    //    ShowForm(MOD.REPORTS.SALE.FrmCustomerTransaction.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "RTGS Paid Report":
                    //    ShowForm(project.REPORTS.SALE.FrmOldGoldRTGS.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "RTGS Receipt Report":
                    //    ShowForm(project.REPORTS.SALE.FrmRTGS.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    case "Stock Value Report":
                        ShowForm(project.Forms.STOCK.FrmStockValueReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "StockTransfer Service Issue List":
                        ShowForm(project.Reports.STOCK.StockTransferPendingListRptFrm.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Brandwise Stock Report":
                        ShowForm(project.REPORTS.STOCK.FrmBrandWiseStockReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sales Order Pending Report":
                        ShowForm(project.REPORTS.SALE.FrmSalesOrderPendingReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                        case "Advance Sold Report":
                        ShowForm(project.REPORTS.SALE.FrmAdvanceSoldReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Advance Received Report":
                        ShowForm(project.REPORTS.SALE.FrmAdvanceReceivedReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //case "Saving Scheme Joining Report":
                    //    ShowForm(MOD.REPORTS.SALE.SavingSchemeJoiningGridReport.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;
                    //case "Saving Scheme Payment Report":
                    //    ShowForm(MOD.REPORTS.SALE.SavingSchemePaymentGridReport.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;
                    //case "Saving Scheme Cancellation Report":
                    //    ShowForm(MOD.REPORTS.SALE.SchemeCancellationEntryGridReport.Instance,  treeview.SelectedNode.Text,frm);
                    //    break;
                    
                    //case "Saving Scheme Reports":
                    //    ShowForm(project.REPORTS.SALE.SupplierBalnce.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "Sales Order Details Report":
                    //    ShowForm(project.REPORTS.SALE.SalesOrderDetailsReport.Instance, treeview.SelectedNode.Text, frm);
                    //    break;

                    //case "Sales Order Master Report":
                    //    ShowForm(project.Forms.SALE.SalesOrderMasterReport.Instance, treeview.SelectedNode.Text, frm);
                    ////    break;

                    //case "Saving Scheme Total Payments Report":
                    //      ShowForm(project.REPORTS.SALE.SavingSchemeTotalPayment.Instance, treeview.SelectedNode.Text, frm);
                    //    break;


                    //case "Daily Collection Report":
                    //    ShowForm(project.REPORTS.SALE.FrmDailyCollectionreport.Instance, Menu, frm);
                    //    break;
                    case "Ledger Report":
                        ShowForm(project.REPORTS.SALE.frmledgerreport.Instance, Menu, frm);
                        break;
                    //case "EmployeeWise Joining Report":
                    //    ShowForm(MOD.REPORTS.SALE.frmEmployeeWiseJoining.Instance, Menu, frm);
                    //    break;
                    case "Salesmanwise Collection Report":
                        ShowForm(project.REPORTS.SALE.frmSalesmanwiseCollectionRpt.Instance, Menu, frm);
                        break;

                    case "SalesManPeriodWise Collection Report":
                        ShowForm(project.REPORTS.SALE.SalesManPeriodWiseCollectionRpt.Instance, Menu, frm);
                        break;
                    case "Closing Report":
                        ShowForm(project.REPORTS.SCHEME.FrmClosingReport.Instance, Menu, frm);
                        break;
                    case "Salesmanwise Joining Report":
                        ShowForm(project.REPORTS.SALE.SalesManWiseJoinNoFrm.Instance, Menu, frm);
                        break;


                    case "Pending Report":
                        ShowForm(new project.REPORTS.SALE.Frmpending(), Menu, frm);
                        break;
                    //case"Supplier Report":
                    //ShowForm(new project.Reports.PUR.FrmSupplierDetailBalanceReport.Instance, treeview.SelectedNode.Text,frm);
                    //    break;
                    case "Supplier Credit Report":
                        ShowForm(project.Reports.PUR.FrmSupplierDetailBalanceReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
//Purchase
                    case "Purchase Return Details Report":
                        ShowForm(project.REPORTS.PUR.PurchaseReturnDetailsReport.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Purchase Return Master Report":
                        ShowForm(project.REPORTS.PUR.PurchaseReturnEntryMasterReport.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Puchase Master  Report":
                        ShowForm(project.REPORTS.PUR.PurchaseEntryMasterReport.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Purchase Details  Report":
                        ShowForm(project.REPORTS.PUR.PurchaseDetailsReport.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Supplier Settlement Master Report":
                        ShowForm(project.REPORTS.PUR.SupplierSettlementMasterReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    //case "Supplier Settlement Details Report":
                    //    ShowForm(project.REPORTS.PUR.SupplierSettlementDetailsReport.Instance, treeview.SelectedNode.Text, frm);
                    //    break;

                    //case "Supplier Due Report":
                    //    ShowForm(project.REPORTS.PUR.SupplierDueReport.Instance, treeview.SelectedNode.Text, frm);
                    //    break;

                    //case "Supplier Balance Report":
                    //    ShowForm(project.REPORTS.PUR.SupplierBalnce.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    //case "Supplier Balance Rpt":
                    //    ShowForm(MOD .REPORTS .PUR .FrmSupplierBalanceReport .Instance ,treeview .SelectedNode .Text ,frm );
                    ////    break;

                    //case "Gold Transaction Report":
                    //    ShowForm(project.REPORTS.PUR.GoldTransactionReport.Instance, treeview.SelectedNode.Text, frm);
                    //    break;

                    //case "Silver Transaction Report":
                    //    ShowForm(project.REPORTS.PUR.SilverTransactionReport.Instance, treeview.SelectedNode.Text, frm);
                    //    break;

                    case "Complements Purchase Master Report":
                        ShowForm(project.REPORTS.PUR.ComplementsPurchaseMasterReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Complements Purchase Details Report":
                        ShowForm(project.REPORTS.PUR.ComplementsPurchaseDetailsReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Suppler Balance Report -Itemwise":
                        ShowForm(project.REPORTS.PUR.frmSupplierBalance.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Salary Detailed Report":
                        ShowForm(project.REPORTS.HR.SalaryDetailsReport.Instance,treeview.SelectedNode.Text,frm);
                        break;

                    case"Advance Payment Report":
                        ShowForm(project.REPORTS.HR.AdvancePaymentReport.Instance, treeview.SelectedNode.Text,frm);
                        break;
                    case "Advance Payment Detail":
                        ShowForm(project.REPORTS.SALE.FrmAdvancePaymentDetail.Instance, treeview.SelectedNode.Text, frm);
                        break;



////Production
//                    case "Melting Report":
//                        ShowForm(project.REPORTS.PROD.RptMetalMixEntry.Instance, treeview.SelectedNode.Text, frm);
//                        break;
//                    case "Aciding Report":
//                        ShowForm(project.REPORTS.PROD.AcidingReport.Instance, treeview.SelectedNode.Text, frm);
//                        break;

                    case "Employee Wise Salary Report":
                        ShowForm(project.REPORTS.HR.EmployeeWiseSalaryReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
//Stock
                    //case "Stock Transfer Receipt Report":
                    //    ShowForm(MOD.REPORTS.STOCK.StockTransferReceiptGridReport.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    case "Stock Transfer Issue Report":
                        ShowForm(project.REPORTS.STOCK.StockTransferIssueGridReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    
                    //case "Old Gold Transaction":
                    //    ShowForm(project.REPORTS.STOCK.OldGoldReport.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    case "Department Opening Stock Report":
                        ShowForm(project.REPORTS.STOCK.DepartmentOpeningStockReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Adjustment Report":
                        ShowForm(project.REPORTS.STOCK.AdjustmentReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Ageing Report":
                        ShowForm(project.REPORTS.STOCK.AgeingReportfrm.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Current Stock Item Wise":
                        ShowForm(project.Forms.STOCK.FrmCurrentStockItemWiseReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Product Code History Report":
                        ShowForm(project.REPORTS.STOCK.ProdCodeHistoryReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Stock Status Report":
                        ShowForm(project.REPORTS.STOCK.frmStockStatus.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Stock Datewise Report":
                        ShowForm(project.REPORTS.STOCK.FrmStockDatewise.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Daily Summary Report":
                        ShowForm(project.REPORTS.STOCK.frmDailySummary.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Complement Stock Report":
                        ShowForm(project.REPORTS.STOCK.ComplementStock.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Testing Pending Details":
                        ShowForm(project.REPORTS.STOCK.TestingPendingList.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Barcode Detailed Report":
                        ShowForm(project .REPORTS .STOCK .BarcodeDetailedGridReport .Instance ,treeview .SelectedNode .Text ,frm );
                        break;

                    case "Itemwise Barcode Summary":
                        ShowForm(project.REPORTS.STOCK.frmItemWisebarcodeSummary.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case"Item Below Reorder Level":
                        ShowForm(project.REPORTS.STOCK.ItemsBelowReorderLevel.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Current Stock Report":
                        ShowForm(project.REPORTS .STOCK .FrmCurrentStockReport.Instance ,treeview .SelectedNode .Text ,frm );
                        break;

                    case "Item Conversion Reports":
                        ShowForm(project.REPORTS.STOCK.ItemConversionReports.Instance,treeview.SelectedNode.Text,frm);
                        break;

                    case "BarCode Details":
                        ShowForm(project.REPORTS.STOCK.BarCodePrint.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Productcode Register":

                        ShowForm(project.REPORTS.STOCK.frmproductcoderegister.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    //case "Customer Repair Receipt Report":
                    //    ShowForm(project.Forms.Services.cmb_type.Instance, treeview.SelectedNode.Text, frm);
                    //    break;
                    case "Purchase Cheque Details Report":
                        ShowForm(project.REPORTS.SALE.OldGoldReceiptReportfrm.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "ChequePaid Report":
                        ShowForm(project.REPORTS.SALE.FrmChequePaidReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sales Old Summary":
                        ShowForm(project.REPORTS.SALE.FrmSalesOldSummary.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Itemwise Sales Summary":
                        ShowForm(project.REPORTS.SALE.FrmItemwiseSalesSummary.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Discount Allowed Report":
                        ShowForm(project.REPORTS.SALE.DiscountAllowedReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sales Details Report":
                        ShowForm(project.REPORTS.SALE.SalesDetailsGridReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sales Master Report":
                        ShowForm(project.REPORTS.SALE.SalesMasterReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Gold Booking Cancellation Report":
                        ShowForm(project.REPORTS.SALE.GoldBookingCancelationEntryReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Supplier ItemWise Sales Report":
                        ShowForm(project.REPORTS.SALE.SupplierItemWiseSales.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Gold Booking Report":
                        ShowForm(project.REPORTS.SALE.GoldBookingMasterReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sales Customer Wise Report":
                        ShowForm(project.REPORTS.SALE.SalescutomerWiseRpt.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sales Cash or Credit Report":
                        ShowForm(project.REPORTS.SALE.SalesMasterCashorCreditReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sales Chart Report":
                        //ShowForm(MOD.REPORTS.SALE.SalesChart.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Complement Report":
                        ShowForm(project.REPORTS.SALE.ComplementGridReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "ProdCodeWise Sales Details":
                        ShowForm(project .REPORTS .SALE .frmProdCodewiseSalesDetails .Instance ,treeview .SelectedNode .Text ,frm );
                        break;

                    case "ItemConversion BarcodeWise Report":
                        ShowForm(project .REPORTS .SALE.frmProdcodewiseItemconversionIssueReport.Instance,treeview.SelectedNode.Text,frm);
                        break;


                    case "Gold Booking Pending Report":
                        ShowForm(project .REPORTS .SALE .FrmGoldBookingPendingRpt .Instance ,treeview .SelectedNode .Text  ,frm );
                        break;

                    case "Item Conversion ItemWise Summary":
                        ShowForm(project.REPORTS.STOCK.FrmItemConversionItemWiseSummary.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Sales Summary":
                        ShowForm(project.REPORTS.SALE.SalesSummary.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Sales Date Wise Summary":
                        ShowForm(project.REPORTS.SALE.SalesDatewiseSummaryReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Sales Period Summary":
                        ShowForm(project.REPORTS.SALE.FrmSalesPeriodReport.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Brandwise Sales Summary":
                        ShowForm(project.REPORTS.SALE.FrmBrandwiseSalesReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Gold Booking Sold And UnSold Report":
                        ShowForm(project .REPORTS .SALE .FrmGoldBookingSoldAndUnsold .Instance ,treeview .SelectedNode .Text ,frm );
                        break;

                    case "Sales Item Wise Summary":
                        ShowForm(project.REPORTS.SALE.SalesItemwiseSummaryReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case "Salesman Wise Summary":
                        ShowForm(project.REPORTS.SALE.SalesmanwiseSummary.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    //case "Old Gold Receipt Report":
                    //    ShowForm(MOD.Forms.SALE.OldGoldReceiptGridReport.Instance, treeview.SelectedNode.Text, frm);
                    //    break;

                    case "Old Gold Item Wise":
                        ShowForm(project.REPORTS.SALE.OldGoldItemWiseReport.Instance,treeview.SelectedNode.Text,frm);
                        break;

                    //case "Repair Receipt Report":
                    //      ShowForm(MOD.REPORTS.STOCK.RepairReceiptGridReport.Instance, treeview.SelectedNode.Text, frm);
                    //      break;

                    //case "Repair Issue Report":
                    //      ShowForm(MOD.REPORTS.STOCK.RepairIssueDetailsGridReport.Instance, treeview.SelectedNode.Text, frm);
                    //      break; 

                    case"Supplier Wise Sales Report":
                          ShowForm(project.REPORTS.SALE.SupplierWiseSalesReport.Instance,treeview.SelectedNode.Text,frm);
                          break;
                        

                          case"Current stock":
                          ShowForm(project.REPORTS.STOCK. FrmStockNew.Instance,treeview.SelectedNode.Text,frm);
                          break;

                    case "Sales Balance Pending Report":
                          ShowForm(project.REPORTS.SALE.SalesBalancePendingReport.Instance,treeview.SelectedNode.Text,frm);
                          break;

                    case "Average VA Report":
                          ShowForm(project.REPORTS.SALE.AverageVAReport.Instance, treeview.SelectedNode.Text, frm);
                          break;

                    case "ItemWise ProdCode Sales Summary":
                          ShowForm(project .REPORTS .SALE .FrmItemwiseBarcodeSummary .Instance,treeview.SelectedNode.Text,frm);
                          break;
                    case "Sales Order Report":
                          ShowForm(project.REPORTS.SALE.SalesOrderContinous.Instance, treeview.SelectedNode.Text, frm);
                          break;
                    //case "Customer Search":
                    //      ShowForm(MOD.REPORTS.SALE.CustomerSearch1.Instance, treeview.SelectedNode.Text, frm);
                    //      break;
                   
                    case "Sales Search":
                          //ShowForm(MOD.REPORTS.SALE.SalesSearch.Instance,treeview.SelectedNode.Text,frm);
                          //break;

                    case "Daily Stock Register":
                          ShowForm(project.REPORTS.STOCK.DailyStockAccountReport.Instance, treeview.SelectedNode.Text,frm);
                          break;
                    case "Supplier Report":
                          ShowForm(project.REPORTS.STOCK.FrmSupplierBalanceReport.Instance, treeview.SelectedNode.Text, frm);
                          break;

             

 //Accounts     
                   case "Chart Of Accounts":
                        ShowForm(FA.frmChartOfAccounts.Instance,treeview.SelectedNode.Text,frm);
                        break;
                    case "Ledger Book":
                        ShowForm(FA.LedgerBook.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Day Book":
                        ShowForm(FA.DayBook.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Cash Book":
                        ShowForm(FA.CashBook.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Group Summary":
                        ShowForm(FA.GroupSummary.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Trial Balance":
                         ShowForm(FA.TrialBalance.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Profit And Loss Accounts":
                        ShowForm(FA.REPORTS.ProfitAndLoss.Instance,  treeview.SelectedNode.Text,frm);
                        break;
                    case "Cheque Transactions":
                        ShowForm(new FA.FORMS.ChequeIssueOrReciept(), treeview.SelectedNode.Text, frm);
                        break;


           
                 
//HR

                    case "Attendence List":
                        ShowForm(project.REPORTS.HR.AbsentpresentReportFrm.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Attendence Report":
                        ShowForm(project.REPORTS.HR.MustRollRptFrm.Instance, treeview.SelectedNode.Text, frm);
                        break;

                      

//Continuous Print

                    case "Continuous Bill Print":
                        ShowForm(project.Forms.PUR.ContinuousBillPrint.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Salary Payslip Continuous Print":
                        ShowForm(project.REPORTS.HR.SalarySlipContinousPrint.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "All Transactions Report":
                        ShowForm(project.REPORTS.STOCK.AllTransactionsReport.Instance, treeview.SelectedNode.Text, frm);
                        break;

//e files
                    case "Purchase":
                        ShowForm(project.REPORTS.PUR.e_File_Purchase.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Sales":
                        ShowForm(project.REPORTS.SALE.e_File_Sales.Instance, treeview.SelectedNode.Text, frm);
                        break;

                    case"Customers Address Print":
                        ShowForm(project.REPORTS.SALE.CustomersAddressPrint.Instance,treeview.SelectedNode.Text,frm);
                        break;*/
  
                    default:
                        break;
                }
            }
            else if (Group == "Add_New")
            {
                switch (Menu)
                {

                     case "Classification":
                        ShowForm(project.Forms.ADD.Classification.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case " Author":
                        ShowForm(project.Forms.ADD.Author.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Publisher":
                        ShowForm(project.Forms.ADD.Publisher.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Book language":
                        ShowForm(project.Forms.ADD.Book_language.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Book division":
                        ShowForm(project.Forms.ADD.Book_division.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Book subject":
                        ShowForm(project.Forms.ADD.Book_subject.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Shelf ":
                        ShowForm(project.Forms.ADD.Shelf.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Supplier":
                        ShowForm(project.Forms.ADD.Supplier.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Library Section":
                        ShowForm(project.Forms.ADD.Library_Section.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Member category":
                        ShowForm(project.Forms.ADD.Member_category.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Transaction Type":
                        ShowForm(project.Forms.ADD.Transaction_Type.Instance, treeview.SelectedNode.Text, frm);
                        break;
                    case "Book Binder":
                        ShowForm(project.Forms.ADD.Book_binder.Instance, treeview.SelectedNode.Text, frm);
                        break;
                     case "Add New Book":
                        ShowForm(project.Forms.ADD.Add_New_Book.Instance, treeview.SelectedNode.Text, frm);
                        break;


                    default:
                        treeview.SelectedNode = treeview.Nodes[0];
                        break;
                }
            }


        }
        public static void ShowForm(DockContent Form, string menuname,Form MdiParent)
        {
            Form.MdiParent = MdiParent ;

            ((frmMain)MdiParent).ShowChild(Form);
            Form.Focus();
            Form.Tag = menuname;
        }
        public static void ShowForm(Form Form, string menuname, Form MdiParent)
        {
            Form.StartPosition = FormStartPosition.CenterScreen;
            Form.ShowDialog();     
            Form.Focus();
            Form.Tag = menuname;
        }


         
    }
}
