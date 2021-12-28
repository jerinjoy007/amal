using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.Classes
{


    public static class DotMarixPrinting
    {


        private static Gramboo.DataController DBConn;
        private static string Company, SalesMan, Comp_Add1, Comp_Add2, Comp_Place, Comp_City, Comp_Dist, Comp_State, Comp_pin, Comp_phone,
            TinNo, CstNo, CompId, greetings,greetings1,greetings2, notepadfooter, statename, statecode, customerGSTNO, B2B;


        #region Sales Print
        //SALES
        private static string CustomerName, InvoiceNo, BookingNo,
            Address1, PhoneNo, OldNo, BranchName, CreatedBy, hsncode;
        private static float DisAmt, oldGoldRpt, netTotal, SAmount_Ret, TaxAmt, FinalAmt, GrandTotal, TaxPerc, CashPaid,
            CreditCardPaid, totalProdVal, AdvancePaid, AmtPayable, SchemeAmount, Rate, RateDiff, BookingAmount,
            CGSTperc,SGSTPerc,IGSTPerc,CGST,SGST,IGST;
        private static long oldGoldNoSales;
        private static DateTime InvoiceDate, CreatedTime, DueDate;

        #region Get Sales Details

        private static bool GetSalesDetails(long SalesId)
        {
            DBConn = new Gramboo.DataController();
            using (DataTable dt = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                  ("Select  *  FROM SALE.VSalesMaster WHERE SalesId='" + SalesId + "'")).Tables[0])
            {
                if (dt.Rows.Count > 0)
                {
                    CompId = (dt.Rows[0]["Company_Id"] == DBNull.Value ? "" : dt.Rows[0]["Company_Id"].ToString());
                    Company = (dt.Rows[0]["Comp_Name"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Name"].ToString());
                    SalesMan = (dt.Rows[0]["Sales Man Name"] == DBNull.Value ? "" : dt.Rows[0]["Sales Man Name"].ToString());
                    Comp_Add1 = (dt.Rows[0]["Comp_Addr1"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Addr1"].ToString());
                    Comp_Add2 = (dt.Rows[0]["Comp_Addr2"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Addr2"].ToString());
                    Comp_Place = (dt.Rows[0]["Comp_Place"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Place"].ToString());
                    Comp_City = (dt.Rows[0]["Comp_City"] == DBNull.Value ? "" : dt.Rows[0]["Comp_City"].ToString());
                    Comp_Dist = (dt.Rows[0]["Comp_District"] == DBNull.Value ? "" : dt.Rows[0]["Comp_District"].ToString());
                    Comp_State = (dt.Rows[0]["Comp_State"] == DBNull.Value ? "" : dt.Rows[0]["Comp_State"].ToString());
                    Comp_pin = dt.Rows[0]["Comp_Pin"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Pin"].ToString();
                    Comp_phone = (dt.Rows[0]["Comp_Phone"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Phone"].ToString());
                    statename = (dt.Rows[0]["StateName"] == DBNull.Value ? "" : dt.Rows[0]["StateName"].ToString());
                    statecode = (dt.Rows[0]["StateCode"] == DBNull.Value ? "" : dt.Rows[0]["StateCode"].ToString());
                    TinNo = (dt.Rows[0]["GSTNo"] == DBNull.Value ? "" : dt.Rows[0]["GSTNo"].ToString());
                    customerGSTNO = (dt.Rows[0]["cust GSTNO"] == DBNull.Value ? "" : dt.Rows[0]["cust GSTNO"].ToString());
                    InvoiceDate = Convert.ToDateTime(dt.Rows[0]["Invoice Date"] == DBNull.Value ? "" : dt.Rows[0]["Invoice Date"].ToString());
                    CreatedTime = Convert.ToDateTime(dt.Rows[0]["Created Date"] == DBNull.Value ? "" : dt.Rows[0]["Created Date"].ToString());
                    //Rate = Convert.ToSingle(dt.Rows[0]["GoldRate"] == DBNull.Value ? "" : dt.Rows[0]["GoldRate"].ToString());
                    DisAmt = Convert.ToSingle(dt.Rows[0]["DiscAmount"] == DBNull.Value ? "0" : dt.Rows[0]["DiscAmount"].ToString());
                    //  oldGoldRpt = Convert.ToSingle(dt.Rows[0]["TotalOldGoldReceipt"] == DBNull.Value ? "0" : dt.Rows[0]["TotalOldGoldReceipt"].ToString());
                    // netTotal = Convert.ToSingle(dt.Rows[0]["NetTotal"] == DBNull.Value ? "0" : dt.Rows[0]["NetTotal"].ToString());
                    // SAmount_Ret = Convert.ToSingle(dt.Rows[0]["TotalReturnAmount"] == DBNull.Value ? "0" : dt.Rows[0]["TotalReturnAmount"].ToString());
                    TaxAmt = Convert.ToSingle(dt.Rows[0]["TotalTaxAmount"] == DBNull.Value ? "0" : dt.Rows[0]["TotalTaxAmount"].ToString());
                    FinalAmt = Convert.ToSingle(dt.Rows[0]["FinalAmount"] == DBNull.Value ? "0" : dt.Rows[0]["FinalAmount"].ToString());
                    InvoiceNo = (dt.Rows[0]["Invoice No"] == DBNull.Value ? "" : dt.Rows[0]["Invoice No"].ToString());
                    CustomerName = (dt.Rows[0]["Customer Name"] == DBNull.Value ? "" : dt.Rows[0]["Customer Name"].ToString());
                    Address1 = (dt.Rows[0]["Address1"] == DBNull.Value ? "" : dt.Rows[0]["Address1"].ToString());
                    PhoneNo = (dt.Rows[0]["PhoneNo"] == DBNull.Value ? "" : dt.Rows[0]["PhoneNo"].ToString());
                    GrandTotal = Convert.ToSingle(dt.Rows[0]["GrandTotal"] == DBNull.Value ? "0" : dt.Rows[0]["GrandTotal"].ToString());
                    TaxPerc = Convert.ToSingle(dt.Rows[0]["TaxPerc"] == DBNull.Value ? "0" : dt.Rows[0]["TaxPerc"].ToString());
                    //  OldNo = (dt.Rows[0]["old Gold No"] == DBNull.Value ? "" : dt.Rows[0]["old Gold No"].ToString());
                    BranchName = (dt.Rows[0]["BranchName"] == DBNull.Value ? "" : dt.Rows[0]["BranchName"].ToString());
                    CashPaid = Convert.ToSingle(dt.Rows[0]["CashPaid"] == DBNull.Value ? "0" : dt.Rows[0]["CashPaid"].ToString());
                    CreditCardPaid = Convert.ToSingle(dt.Rows[0]["CreditPaid"] == DBNull.Value ? "0" : dt.Rows[0]["CreditPaid"].ToString());
                    // oldGoldNoSales = Convert.ToInt64((dt.Rows[0]["OldGoldId"].ToString() == "" ? "0" : dt.Rows[0]["OldGoldId"].ToString()));
                    CreatedBy = (dt.Rows[0]["Created By"] == DBNull.Value ? "" : dt.Rows[0]["Created By"].ToString());
                    totalProdVal = Convert.ToSingle(dt.Rows[0]["TotalProdVal"] == DBNull.Value ? "0" : dt.Rows[0]["TotalProdVal"].ToString());
                    AdvancePaid = Convert.ToSingle(dt.Rows[0]["AdvancePaid"] == DBNull.Value ? "0" : dt.Rows[0]["AdvancePaid"].ToString());
                    SchemeAmount = Convert.ToSingle(dt.Rows[0]["SchemeAmount"] == DBNull.Value ? "" : dt.Rows[0]["SchemeAmount"].ToString());
                    RateDiff = Convert.ToSingle(dt.Rows[0]["RateDiff"] == DBNull.Value ? "0" : dt.Rows[0]["RateDiff"].ToString());
                    BookingNo = (dt.Rows[0]["Booking No"] == DBNull.Value ? "" : dt.Rows[0]["Booking No"].ToString());
                    BookingAmount = Convert.ToSingle(dt.Rows[0]["Booking Amount"] == DBNull.Value ? "0" : dt.Rows[0]["Booking Amount"].ToString());
                    BalanceAmount = Convert.ToSingle(dt.Rows[0]["BalanceAmt"].ToString() == "" ? "0" : dt.Rows[0]["BalanceAmt"].ToString());
                    AmtPayable = (netTotal - CashPaid);
                    CGST = Convert.ToSingle(dt.Rows[0]["TotalCGST"] == DBNull.Value ? "0" : dt.Rows[0]["TotalCGST"].ToString());
                    SGST = Convert.ToSingle(dt.Rows[0]["TotalSGST"] == DBNull.Value ? "0" : dt.Rows[0]["TotalSGST"].ToString());
                    IGST = Convert.ToSingle(dt.Rows[0]["TotalIGST"] == DBNull.Value ? "0" : dt.Rows[0]["TotalIGST"].ToString());
                    CGSTperc = Convert.ToSingle(dt.Rows[0]["CGSTPerc"] == DBNull.Value ? "0" : dt.Rows[0]["CGSTPerc"].ToString());

                    SGSTPerc = Convert.ToSingle(dt.Rows[0]["SGSTPerc"] == DBNull.Value ? "0" : dt.Rows[0]["SGSTPerc"].ToString());
                    IGSTPerc = Convert.ToSingle(dt.Rows[0]["IGSTPerc"] == DBNull.Value ? "0" : dt.Rows[0]["IGSTPerc"].ToString());
                  //  hsncode = Convert.ToSingle(dt.Rows[0]["IGSTPerc"] == DBNull.Value ? "0" : dt.Rows[0]["IGSTPerc"].ToString());
                    B2B = (dt.Rows[0]["B2Bcust"] == DBNull.Value ? "0" : dt.Rows[0]["B2Bcust"].ToString());
                   // B2B = Convert.ToSingle(dt.Rows[0]["B2Bcust"] == DBNull.Value ? "0" : dt.Rows[0]["B2Bcust"].ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        #endregion

        public static void SalesInvoice(long salesid, bool ViewOnly, bool ExcludeOld)
        {

            SalesInvoice(new long[] { salesid }, ViewOnly, ExcludeOld);
        }

        public static void SalesInvoice(long[] salesid, bool ViewOnly, bool ExcludeOld)
        {
            DBConn = new Gramboo.DataController();



            NotepadPrintHelper p = new NotepadPrintHelper();
            p.OpenWriter(Path.GetTempPath() + "Print.txt");





            for (long i = 0; i <= salesid.Length - 1; i++)
            {
                #region HEADER

                if (GetSalesDetails(salesid[i]))
                {
                    p.FontStyle = NotepadPrintHelper.FontStyles.Big;
                    p.NewLine = true;
                   // p.PrintAlignment = PrintAlign.Center;
                    if (CompId == "1")
                    {
                        p.PrintAlignment = PrintAlign.Left; ;
                        p.FontStyle = NotepadPrintHelper.FontStyles.Big;
                      
                        p.PrintString(   Company);
                        p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                        p.PrintAlignment = PrintAlign.Center;
                        p.PrintString(Comp_Add1 , 80);
                        p.PrintString(Comp_Add2, 80);
                        p.PrintString("PHONE:" + Comp_phone, 80);
                        p.PrintString("" + statename + "-" + statecode, 80);
                        p.PrintAlignment = PrintAlign.Left;
                        p.PrintString("GST :" + TinNo);
                        p.PrintString("");
                        p.PrintString("");
                        p.PrintAlignment = PrintAlign.Left;
                        p.PrintString("");
                        p.PrintAlignment = PrintAlign.Center;

                        //p.PrintString("THE KERALA VALUE ADDED TAX RULES,2005");
                        //p.PrintString("FORM NO. 8J");
                        if (B2B == "True")
                        {
                            p.PrintString("TAX INVOICE");
                            p.PrintString("CASH");
                        }
                        else
                        {
                            p.PrintString("RETAIL INVOICE");
                            p.PrintString("CASH");
                        }
                    }
                    else
                    {

                        p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                        p.PrintString("SALES ORDER/INVOICE");
                        p.PrintAlignment = PrintAlign.Left;
                        p.PrintString("TIN :" + TinNo);
                    }
                    p.PrintString("  ");
                    p.PrintString("  ");
                    p.PrintAlignment = PrintAlign.Left;

                    p.NewLine = false;
                    p.PrintString("INVOICE No: " + InvoiceNo, 30);

                    p.PrintAlignment = PrintAlign.Right;
                  //  p.PrintString("HSN Code :  " +
                    p.PrintString("Date :  " + InvoiceDate.ToString("dd/MMM/yyyy"), 50);
                    p.NewLine = true;
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString("Name & Address  " + CustomerName);
                    p.PrintString("Phone:" + PhoneNo);
                    if (B2B == "True")
                    {
                        p.PrintString("Customer GSTNO:" + customerGSTNO);
                    }
                    // p.PrintString("Rate:" + Rate.ToString("f2"));
                    p.PrintLine('-', 80);

                    p.NewLine = false;

                    p.PrintAlignment = PrintAlign.Left;                   
                    p.PrintString("ItemName", 9);
                    p.PrintString("Brand", 7);
                    p.PrintString("code", 6);
                    p.PrintAlignment = PrintAlign.Right;                        
                    p.PrintString("MRP..", 7);

                    p.PrintString("HSNCode", 7);
                    p.PrintString("Disc..", 7);
                    p.PrintString("Unitprice", 8);
                    p.PrintString("Tax%",5);
                    p.PrintString("SGST", 6);
                    p.PrintString("CGST", 7);
                    p.PrintString("Amount", 10);
                    p.NewLine = true;
                    p.PrintLine('-', 80);
                #endregion

                    #region SALES
                    int Qty;
                    float Gwt, StWt, NetWt, StoneCash, VaPerc, Total, VaPercAftDis, MC, Wst, WstCash, DiaWt, DiaNo, DiaRate, DiaCash
                        , totcgst = 0, totigst = 0, totsgst = 0, TotAmt = 0, TotStCash = 0, TotDiaWt = 0, TotDiaNo = 0, TotDiaRate = 0, TotDiaCash = 0,
                        TotGwt = 0, ToMRP = 0, Totalunit=0;
                    string ProdCode, ItemName, floorname = "", Brand, code,HSNcode;
                    float Disc, TotalAmount, TotalSGst, TotalCgst, TotalIGst, MRP, Totdis = 0, Costprice,TaxPer;
                    using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                ("Select prodCode,ItemName,Qty,BrandName,Code,Disc,TotalAmount,TotalSGst,TotalCgst,TotalIGst,CalcuCGST,CalcuIGST,MRP,Costprice,Taxper,HSNcode FROM SALE.SalesDotPrint WHERE SalesId='" + salesid[i] + "' and Type='S'")).Tables[0])
                    {
                        if (dtdetails.Rows.Count > 0)
                        {

                            foreach (DataRow r in dtdetails.Rows)
                            {

                                //ProdCode = r["prodCode"].ToString();
                                ItemName = r["ItemName"].ToString();
                                Brand = r["BrandName"].ToString();
                                code = r["Code"].ToString();
                                MRP = Convert.ToSingle(r["MRP"].ToString());
                                HSNcode = r["HSNcode"].ToString();
                                Disc = Convert.ToSingle(r["Disc"].ToString());
                                Costprice = Convert.ToSingle(r["Costprice"].ToString());
                                TaxPer = Convert.ToSingle(r["Taxper"].ToString());
                                TotalSGst = Convert.ToSingle(r["CalcuCGST"].ToString());
                                TotalCgst = Convert.ToSingle(r["CalcuCGST"].ToString());
                                //TotalIGst = Convert.ToSingle(r["CalcuIGST"].ToString());
                                TotalAmount = Convert.ToSingle(r["TotalAmount"].ToString());
                                //
                                //StoneCash = Convert.ToSingle(r["StoneCash"].ToString());
                                //DiaNo = Convert.ToSingle(r["DiaNo"].ToString());
                                //DiaWt = Convert.ToSingle(r["DiaWt"].ToString());
                                //DiaRate = Convert.ToSingle(r["DiaRate"].ToString());
                                //DiaCash = Convert.ToSingle(r["DiaCash"].ToString());
                                //VaPerc = Convert.ToSingle(r["VAPerc"].ToString());
                                //Total = Convert.ToSingle(r["TotalAmount"].ToString());
                                //VaPercAftDis = Convert.ToSingle(r["VApercAftDis"].ToString());
                                //MC = Convert.ToSingle(r["MC"].ToString());
                                //Wst = Convert.ToSingle(r["Wastage"].ToString());
                                //WstCash = Convert.ToSingle(r["WastageCash"].ToString());
                                //if (ViewOnly)
                                //    floorname = r["FloorName"].ToString();
                                //       p.PrintAlignment = PrintAlign.Left;

                                p.NewLine = false;
                                //p.PrintString((ProdCode.Length == 0 ? " " : ProdCode), 12);
                                ItemName = ItemName.Trim(); 
                                if (ItemName.Length > 6)
                                    ItemName = ItemName.Substring(0,6);                                                                        
                                p.PrintString(ItemName, 3);
                                if (Brand.Length > 8)
                                    Brand = Brand.Substring(0, 9);
                                p.PrintString(Brand, 7);
                                p.PrintAlignment = PrintAlign.Right;
                                p.PrintString(code, 6);
                                p.PrintString(MRP.ToString("f0"), 7);
                                if (HSNcode.Length > 6)
                                    HSNcode = HSNcode.Substring(0, 7);
                                p.PrintString(HSNcode, 8);                             
                                p.PrintString(Disc.ToString("f2"), 7);
                                p.PrintString(Costprice.ToString("f2"), 10);
                                p.PrintString(""+TaxPer.ToString() + "%", 4); 
                                p.PrintString(TotalSGst.ToString("f2"), 8);
                                p.PrintString(TotalCgst.ToString("f2"), 8);
                                //p.PrintString(TotalIGst.ToString("f2"), 6);
                                p.PrintString(TotalAmount.ToString("f0"), 7);
                                // p.PrintString(r["VA"].ToString(), 8);
                                // p.PrintString(StoneCash.ToString("f2"), 8);
                                //  p.PrintString(Total.ToString("f2"), 10);
                                if (ViewOnly)
                                    p.PrintString(floorname, 10);
                                p.NewLine = true;
                                //if (DiaWt > 0)
                                //{
                                //    p.PrintAlignment = PrintAlign.Left;

                                //    p.NewLine = false;
                                //    p.PrintString("  ", 12);
                                //    p.PrintString("DIamond", 12);

                                //    p.PrintAlignment = PrintAlign.Right;
                                //    p.PrintString(DiaNo.ToString(), 3);
                                //    p.PrintString(DiaRate.ToString("f0"), 6);
                                //    p.PrintString(DiaWt.ToString("f0"), 12);
                                //    p.PrintString(DiaCash.ToString("f2"), 22);
                                //    p.NewLine = true;
                                //}
                                Disc += Disc;
                                //totigst += TotalIGst; 
                                totcgst += TotalCgst; totsgst += TotalSGst;
                                //TotVa += Convert.ToSingle(r["VA"]);
                                TotAmt += TotalAmount;
                                Totalunit += Costprice;
                                //TotStCash += StoneCash;
                                //TotDiaNo += DiaNo; TotDiaWt += DiaWt; TotDiaCash += DiaCash;

                            }

                            p.NewLine = true;                         
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('-', 80);
                            p.NewLine = false;
                            p.PrintAlignment = PrintAlign.Right;
                            // p.PrintString(TotQty.ToString(), 27);
                            p.PrintString(ToMRP.ToString("f2"), 27);                         
                            p.PrintString(Totdis.ToString("f2"), 14);
                            p.PrintString(Totalunit.ToString("f2"), 10);
                            p.PrintString((totsgst).ToString("f2"), 12);
                            p.PrintString((totcgst).ToString("f2"),8);
                           // p.PrintString((totigst).ToString("f2"), 6);
                            p.PrintString(TotAmt.ToString("f0"), 7);
                            p.NewLine = true;

                            if (TotDiaWt > 0)
                            {
                                p.NewLine = false; ;
                                p.PrintAlignment = PrintAlign.Left;


                                p.PrintString("Diamond Total", 12);
                                p.PrintAlignment = PrintAlign.Right;
                                p.PrintString(TotDiaNo.ToString(),14);
                                p.PrintString(TotDiaWt.ToString("f0"), 18);
                                p.PrintString(TotDiaCash.ToString("f2"), 22);
                                p.NewLine = true;
                            }
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('-', 80);
                            p.PrintAlignment = PrintAlign.Right;
                        }
                    }
                    #endregion

                    #region SALES RETURN

                    float TotQty = 0; TotGwt = 0; //TotNetWt = 0; TotStWt = 0; TotVa = 0;
                    // TotAmt = 0; TotStCash = 0;

                    using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                ("Select prodCode,ItemName,Qty FROM SALE.SalesDotPrint WHERE SalesId='" + salesid[i] + "' and Type='R'")).Tables[0])
                    {

                        p.PrintAlignment = PrintAlign.Center;
                        if (dtdetails.Rows.Count > 0)
                        {
                            p.PrintString("SALES RETURN DETAILS");
                            p.PrintString(" ");
                            p.PrintAlignment = PrintAlign.Left;
                            foreach (DataRow r in dtdetails.Rows)
                            {

                                ProdCode = r["prodCode"].ToString();
                                ItemName = r["ItemName"].ToString();

                                Qty = Convert.ToInt32(r["Qty"].ToString());
                                Rate = Convert.ToSingle(r["Rate"].ToString());
                                Gwt = Convert.ToSingle(r["Gwt"].ToString());
                                StWt = Convert.ToSingle(r["StoneWt"].ToString());
                                NetWt = Convert.ToSingle(r["NetWt"].ToString());
                                StoneCash = Convert.ToSingle(r["StoneCash"].ToString());

                                DiaNo = Convert.ToSingle(r["DiaNo"].ToString());
                                DiaWt = Convert.ToSingle(r["DiaWt"].ToString());
                                DiaRate = Convert.ToSingle(r["DiaRate"].ToString());
                                DiaCash = Convert.ToSingle(r["DiaCash"].ToString());

                                VaPerc = Convert.ToSingle(r["VAPerc"].ToString());
                                Total = Convert.ToSingle(r["TotalAmount"].ToString());
                                VaPercAftDis = Convert.ToSingle(r["VApercAftDis"].ToString());
                                MC = Convert.ToSingle(r["MC"].ToString());
                                Wst = Convert.ToSingle(r["Wastage"].ToString());
                                WstCash = Convert.ToSingle(r["WastageCash"].ToString());
                                floorname = r["FloorName"].ToString();
                                p.PrintAlignment = PrintAlign.Left;

                                p.NewLine = false;
                                p.PrintString((ProdCode.Length == 0 ? " " : ProdCode), 12);

                                if (ItemName.Length > 12)
                                    ItemName = ItemName.Substring(0, 11);
                                p.PrintString(ItemName, 12);
                                p.PrintAlignment = PrintAlign.Right;
                                p.PrintString(Qty.ToString(), 3);

                                p.PrintString(Rate.ToString("f0"), 6);

                                p.PrintString(Gwt.ToString("f2"), 6);
                                p.PrintString(StWt.ToString("f2"), 6);

                                p.PrintString(NetWt.ToString("f2"), 6);
                                p.PrintString(r["VA"].ToString(), 8);
                                p.PrintString(StoneCash.ToString("f2"), 8);
                                p.PrintString(Total.ToString("f2"), 10);



                                if (ViewOnly)
                                    p.PrintString(floorname, 10);
                                p.NewLine = true;

                                if (DiaWt > 0)
                                {
                                    p.PrintAlignment = PrintAlign.Left;
                                    p.PrintString("", 12);
                                    p.NewLine = false;
                                    p.PrintString("DIamond", 12);

                                    p.PrintAlignment = PrintAlign.Right;
                                    p.PrintString(DiaNo.ToString(), 3);
                                    p.PrintString(DiaRate.ToString("f0"), 6);
                                    p.PrintString(DiaWt.ToString("f0"), 12);
                                    p.PrintString(Total.ToString("f2"), 32);
                                    p.NewLine = true;
                                }
                                TotQty += Qty; TotGwt += Gwt; //TotNetWt += NetWt; TotStWt += StWt; TotVa += Convert.ToSingle(r["VA"]);
                                TotAmt += Total;
                                TotStCash += StoneCash;
                                TotDiaNo += DiaNo; TotDiaWt += DiaWt; TotDiaCash += DiaCash;

                            }

                            p.NewLine = true;
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('-', 80);
                            p.NewLine = false;
                            p.PrintAlignment = PrintAlign.Right;
                            p.PrintString(TotQty.ToString(), 27);

                            p.PrintString(TotGwt.ToString("f2"), 12);
                            //   p.PrintString(TotStWt.ToString("f2"), 6);

                            //p.PrintString(TotNetWt.ToString("f2"), 6);
                            // p.PrintString(TotVa.ToString(), 8);
                            p.PrintString(TotStCash.ToString("f2"), 8);
                            p.PrintString(TotAmt.ToString("f2"), 10);
                            p.NewLine = true;
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('-', 80);
                            p.PrintAlignment = PrintAlign.Right;

                        }
                    }
                    #endregion


                    #region  OLD GOLD

                    if (CompId == "2")
                    {
                        if (oldGoldNoSales != 0 && !ExcludeOld)
                        {
                            p.NewLine = true;

                            p.PrintAlignment = PrintAlign.Center;
                            p.PrintString("OLD GOLD DETAILS");
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('=', 80);

                            p.NewLine = false;
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintString("ItemName", 20);
                            p.PrintAlignment = PrintAlign.Right;
                            p.PrintString("Gwt", 10);
                            p.PrintString("LessWt", 10);
                            p.PrintString("NetWt", 10);
                            p.PrintString("Rate", 10);
                            p.PrintString("Amount", 20);
                            p.NewLine = true;
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('-', 80);
                            p.NewLine = true;
                            p.PrintAlignment = PrintAlign.Left;
                            using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                            ("Select [Item Name],LessWt,Gwt,Rate,NetWt,Amount FROM SALE.VOldGoldReceiptMaterialsNew WHERE EntryId='" + oldGoldNoSales + "'")).Tables[0])
                            {
                                foreach (DataRow r in dtdetails.Rows)
                                {

                                    p.PrintAlignment = PrintAlign.Left;

                                    p.NewLine = false;
                                    p.PrintString("" + r["Item Name"].ToString(), 20);
                                    p.PrintAlignment = PrintAlign.Right;
                                    p.PrintString("" + Convert.ToSingle(r["Gwt"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["LessWt"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["NetWt"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["Rate"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["Amount"].ToString()).ToString("F2"), 20);


                                }
                                p.NewLine = true;
                                p.PrintAlignment = PrintAlign.Left;
                                p.PrintLine('-', 80);
                                p.NewLine = false;
                                p.PrintString("Total", 20);

                            }
                            float SGwt = 0, SLessWt = 0, SNetWt = 0, SRate = 0, SAmount = 0;
                            using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                           ("Select ISNULL(SUM(LessWt),0) as TotLessWt,ISNULL(SUM(Gwt),0) as TotGwt, ISNULL(SUM(NetWt),0) as TotNetWt,ISNULL(SUM(Amount),0)  as TotAmount FROM SALE.VOldGoldReceiptMaterialsNew WHERE EntryId= " + oldGoldNoSales + " ")).Tables[0])
                            {
                                DataRow r = dtdetails.Rows[0];
                                SGwt = Convert.ToSingle(r["TotGwt"].ToString());
                                SLessWt = Convert.ToSingle(r["TotLessWt"].ToString());
                                SNetWt = Convert.ToSingle(r["TotNetWt"].ToString());
                                SAmount = Convert.ToSingle(r["TotAmount"].ToString());

                                p.PrintAlignment = PrintAlign.Right;
                                p.PrintString("" + SGwt, 10);
                                p.PrintString("" + SLessWt, 10);
                                p.PrintString("" + SNetWt, 10);
                                p.PrintString("" + SAmount, 30);
                            }


                        }
                    }
                    #endregion

                    #region FOOTER
                    p.NewLine = true;
                    p.PrintLine('-');
                    p.PrintAlignment = PrintAlign.Right;
                    if (RateDiff == 0)
                    {
                        p.PrintString("Total ".PadRight(30 - (totalProdVal - TaxAmount + DisAmt).ToString("f2").Length) + (totalProdVal - TaxAmount + DisAmt).ToString("f2"));
                    }
                    else
                    {
                        p.PrintString("Current Value ".PadRight(30 - (totalProdVal + RateDiff).ToString("f2").Length) + (totalProdVal + RateDiff).ToString("f2"));
                        p.PrintString("Rate Diff.".PadRight(30 - RateDiff.ToString("f2").Length) + RateDiff.ToString("f2"));

                        p.PrintString("Net Value ".PadRight(30 - totalProdVal.ToString("f2").Length) + totalProdVal.ToString("f2"));

                    }
                    p.PrintString("Cash Discount ".PadRight(30 - DisAmt.ToString("f2").Length) + DisAmt.ToString("f2"));
                    if (Convert.ToSingle(CGST.ToString("f2")) != 0)
                        p.PrintString("TOTAL CGST               ".PadRight(17 - (CGST).ToString("f2").Length) + (CGST).ToString("f2"));
                    if (Convert.ToSingle(SGST.ToString("f2")) != 0)
                        p.PrintString("TOTAL SGST               ".PadRight(17 - (SGST).ToString("f2").Length) + (SGST).ToString("f2"));
                    if (Convert.ToSingle(IGST.ToString("f2")) != 0)
                        p.PrintString("TOTAL IGST               ".PadRight(17 - (IGST).ToString("f2").Length) + (IGST).ToString("f2"));
                    //p.PrintLine('-', 40);
                    //p.PrintString("Grand Total  ".PadRight(30 - txtNetTotal.Text.Length) + txtNetTotal.Text);
                    //p.PrintLine('-', 40);
                    if (SAmount_Ret != 0)
                        p.PrintString(("Return Amount ").PadRight(30 - SAmount_Ret.ToString("f2").Length) + SAmount_Ret.ToString("f2"));

                    if (oldGoldRpt != 0)
                        p.PrintString(("Old Bill No " + OldNo).PadRight(30 - oldGoldRpt.ToString("f2").Length) + oldGoldRpt.ToString("f2"));


                    if (BookingAmount != 0)
                        p.PrintString(("Booking No " + BookingNo).PadRight(30 - BookingAmount.ToString("f2").Length) + BookingAmount.ToString("f2"));


                    if (AdvancePaid != 0)
                        p.PrintString(("Advance Amount ").PadRight(30 - AdvancePaid.ToString("f2").Length) + AdvancePaid.ToString("f2"));



                    if (SchemeAmount != 0)
                        p.PrintString(("Scheme Amount ").PadRight(30 - SchemeAmount.ToString("f2").Length) + SchemeAmount.ToString("f2"));

                    p.FontStyle = NotepadPrintHelper.FontStyles.Big;

                    float NetAmt = CashPaid + CreditCardPaid + BalanceAmount;
                    if (NetAmt >= 0)
                        p.PrintString("Net Total  ".PadRight(30 - NetAmt.ToString("f2").Length) + NetAmt.ToString("f2"));
                    else
                        p.PrintString("Refund Amount ".PadRight(30 - NetAmt.ToString("f2").Length) + NetAmt.ToString("f2"));


                    //p.PrintLine('-', 20);
                    p.FontStyle = NotepadPrintHelper.FontStyles.Regular;

                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintLine('-', 100);
                    p.PrintString("GRAND TOTAL IN WORDS : " + ToWords.ConvertToWords(NetAmt));
                    p.PrintLine('-', 100);

                    p.PrintAlignment = PrintAlign.Right;
                    p.PrintLine('-', 20);

                    if (BalanceAmount != 0 || CreditCardPaid != 0)
                    {
                        if (CashPaid != 0)
                            p.PrintString(("Cash Paid ").PadRight(30 - (CashPaid).ToString("f2").Length) + (CashPaid).ToString("f2"));
                        if (CreditCardPaid != 0)
                            p.PrintString(("Credit Card Paid ").PadRight(30 - CreditCardPaid.ToString("f2").Length) + CreditCardPaid.ToString("f2"));


                        p.PrintLine('-', 20);
                        //   double netamt = CreditCardPaid + CashPaid;

                        if (BalanceAmount != 0)
                            p.PrintString("Balance  ".PadRight(30 - BalanceAmount.ToString("f2").Length) + BalanceAmount.ToString("f2"));
                    }

                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString("Sales Man :" + SalesMan);
                    p.PrintString("E&OE");
                    p.PrintString(" ");
                    p.PrintAlignment = PrintAlign.Right;
                    p.PrintString("Authorised Signatory ");
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString(CreatedBy);
                    using (DataTable dt = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                     ("SELECT  SalesBillGreetingsMsg,SalesBillGreetingsMsg1,SalesBillGreetingsMsg2,SalesBillFooterNote from SYST.Settings where EntryId ='" + 11010001 + "'")).Tables[0])
                    {

                        greetings = (dt.Rows[0]["SalesBillGreetingsMsg"] == DBNull.Value ? "" : dt.Rows[0]["SalesBillGreetingsMsg"].ToString());
                        greetings1 = (dt.Rows[0]["SalesBillGreetingsMsg1"] == DBNull.Value ? "" : dt.Rows[0]["SalesBillGreetingsMsg1"].ToString());
                        greetings2 = (dt.Rows[0]["SalesBillGreetingsMsg2"] == DBNull.Value ? "" : dt.Rows[0]["SalesBillGreetingsMsg2"].ToString());
                     
                        notepadfooter = (dt.Rows[0]["SalesBillFooterNote"] == DBNull.Value ? "" : dt.Rows[0]["SalesBillFooterNote"].ToString());

                        p.PrintString(greetings);
                        p.FontStyle = NotepadPrintHelper.FontStyles.Compressed;
                        if (B2B == "True")
                        {
                            p.PrintString(greetings1);
                            p.FontStyle = NotepadPrintHelper.FontStyles.Compressed;
                            p.PrintString(greetings2);
                            p.FontStyle = NotepadPrintHelper.FontStyles.Compressed;
                        }
                        if (ViewOnly)
                        {
                            p.FontStyle = NotepadPrintHelper.FontStyles.Compressed;
                            p.PrintString("Print On " + CreatedTime.ToString("dd-MMM-yyyy hh:mm:ss tt"));

                            p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                        }

                        p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                        p.PrintString(" ");
                        p.FontStyle = NotepadPrintHelper.FontStyles.Regular;

                        while (notepadfooter.Length != 0)
                        {
                            if (notepadfooter.Length > 80)
                            {
                                p.PrintString(notepadfooter.Substring(0, 80));
                                notepadfooter = notepadfooter.Substring(79, notepadfooter.Length - 80);
                            }
                            else
                            {
                                p.PrintString(notepadfooter);
                                notepadfooter = "";
                            }
                        }
                        //  p.PrintString("seven days from the date of purchase");

                    }
                    if (!ExcludeOld)
                    {
                        if (CompId == "1")
                        {
                            if (!ViewOnly)
                            {

                                for (int j = 0; j <= 10; j++)
                                {

                                    p.PrintString(" ");
                                }
                            }

                            OldGoldInvoice(oldGoldNoSales, p);
                        }
                    }
                    #endregion



                }
            }
            if (!ViewOnly)
            {
                p.Print();
            }
            else
            {
                p.CloseWriter();
            }


        }



        #endregion

        #region Sales ORder Print
        static float BalanceAmount;

        private static bool GetSalesOrderDetails(long SalesOrderID)
        {


            using (DataTable dtMaster = DBConn.GetData(new System.Data.SqlClient.SqlCommand
           ("Select * FROM SALE.VSalesOrderMaster WHERE SalesId=" + SalesOrderID + "")).Tables[0])
            {
                if (dtMaster.Rows.Count > 0)
                {
                    CompId = (dtMaster.Rows[0]["Company_Id"] == DBNull.Value ? "" : dtMaster.Rows[0]["Company_Id"].ToString());
                    Company = (dtMaster.Rows[0]["Comp_Name"] == DBNull.Value ? "" : dtMaster.Rows[0]["Comp_Name"].ToString());
                    Comp_Add1 = (dtMaster.Rows[0]["Comp_Addr1"] == DBNull.Value ? "" : dtMaster.Rows[0]["Comp_Addr1"].ToString());
                    Comp_Add2 = (dtMaster.Rows[0]["Comp_Addr2"] == DBNull.Value ? "" : dtMaster.Rows[0]["Comp_Addr2"].ToString());

                    SalesMan = (dtMaster.Rows[0]["Sales Man Name"] == DBNull.Value ? "" : dtMaster.Rows[0]["Sales Man Name"].ToString());
                    Comp_Place = (dtMaster.Rows[0]["Comp_Place"] == DBNull.Value ? "" : dtMaster.Rows[0]["Comp_Place"].ToString());
                    Comp_City = (dtMaster.Rows[0]["Comp_City"] == DBNull.Value ? "" : dtMaster.Rows[0]["Comp_City"].ToString());
                    TinNo = (dtMaster.Rows[0]["GSTNo"] == DBNull.Value ? "" : dtMaster.Rows[0]["GSTNo"].ToString());
                    InvoiceDate = Convert.ToDateTime(dtMaster.Rows[0]["Invoice Date"] == DBNull.Value ? "" : dtMaster.Rows[0]["Invoice Date"].ToString());
                    CreatedTime = Convert.ToDateTime(dtMaster.Rows[0]["Created Date"] == DBNull.Value ? "" : dtMaster.Rows[0]["Created Date"].ToString());

                    InvoiceNo = (dtMaster.Rows[0]["Invoice No"] == DBNull.Value ? "" : dtMaster.Rows[0]["Invoice No"].ToString());
                    CustomerName = (dtMaster.Rows[0]["Customer Name"] == DBNull.Value ? "" : dtMaster.Rows[0]["Customer Name"].ToString());
                    statename = (dtMaster.Rows[0]["StateName"] == DBNull.Value ? "" : dtMaster.Rows[0]["StateName"].ToString());
                    statecode = (dtMaster.Rows[0]["statecode"] == DBNull.Value ? "" : dtMaster.Rows[0]["statecode"].ToString());
                    // oldGoldNoSales = Convert.ToInt64(dtMaster.Rows[0]["OldGoldId"] == DBNull.Value ? "0" : dtMaster.Rows[0]["OldGoldId"].ToString());
                    // Rate = Convert.ToSingle(dtMaster.Rows[0]["Gold Rate"] == DBNull.Value ? "" : dtMaster.Rows[0]["Gold Rate"].ToString());

                    CreditCardPaid = Convert.ToSingle(dtMaster.Rows[0]["CreditPaid"] == DBNull.Value ? "" : dtMaster.Rows[0]["CreditPaid"].ToString());
                    //                            TotalCashPaid = Convert.ToSingle(dtMaster.Rows[0]["TotalCashPaid"] == DBNull.Value ? "" : dtMaster.Rows[0]["TotalCashPaid"].ToString());
                    CashPaid = Convert.ToSingle(dtMaster.Rows[0]["CashPaid"] == DBNull.Value ? "" : dtMaster.Rows[0]["CashPaid"].ToString());
                    // oldGoldRpt = Convert.ToSingle(dtMaster.Rows[0]["TotalOldGoldReceipt"] == DBNull.Value ? "" : dtMaster.Rows[0]["TotalOldGoldReceipt"].ToString());
                    totalProdVal = Convert.ToSingle(dtMaster.Rows[0]["TotalProdVal"] == DBNull.Value ? "" : dtMaster.Rows[0]["TotalProdVal"].ToString());
                    CreatedBy = (dtMaster.Rows[0]["Created By"] == DBNull.Value ? "" : dtMaster.Rows[0]["Created By"].ToString());
                    BalanceAmount = totalProdVal - (oldGoldRpt + CashPaid + CreditCardPaid);
                    return true;
                }

                else
                {
                    return false;
                }
            }
        }

        public static void SalesOrderInvoice(long salesorderid, bool ViewOnly)
        {
            SalesOrderInvoice(new long[] { salesorderid }, ViewOnly);
        }

        public static void SalesOrderInvoice(long[] salesorderid, bool ViewOnly)
        {
            DBConn = new Gramboo.DataController();

            NotepadPrintHelper p = new NotepadPrintHelper();
            p.OpenWriter(Path.GetTempPath() + "Print.txt");

            for (int i = 0; i <= salesorderid.Length - 1; i++)
            {

                if (GetSalesOrderDetails(salesorderid[i]))
                {
                    p.FontStyle = NotepadPrintHelper.FontStyles.Big;
                    p.NewLine = true;
                    p.PrintAlignment = PrintAlign.Center;
                    p.PrintString(Company);
                    p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                    p.PrintString(Comp_Add1 + "," + Comp_Add2);
                    p.PrintString(statename + "," + statecode);
                    p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                    p.PrintString("GSTIN: " + TinNo, 10);
                    //p.PrintString("");
                    p.PrintAlignment = PrintAlign.Left;
                    //p.PrintString("");

                    p.PrintAlignment = PrintAlign.Center;
                    p.PrintString("SALES ORDER INVOICE");


                    p.PrintAlignment = PrintAlign.Left;
                    p.NewLine = false;
                    p.PrintString("INVOICE No: " + InvoiceNo, 30);

                    p.PrintAlignment = PrintAlign.Right;
                    p.PrintString("Date :  " + InvoiceDate.ToString("dd/MMM/yyyy"), 50);
                    p.NewLine = true;
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString("Name & Address  :" + CustomerName);
                    p.PrintString("Phone:  ...........");
                    //  p.PrintString("Rate:" + Rate.ToString("f2"));
                    p.PrintLine('-', 80);
                    p.NewLine = false;

                    p.PrintAlignment = PrintAlign.Left;
                    // p.PrintString("ProdCode", 12);
                    p.PrintString("ItemName", 12);
                    p.PrintString("BrandName", 12);
                    p.PrintString("Code", 10);
                    p.PrintAlignment = PrintAlign.Right;
                    p.PrintString("Qty", 5);
                    p.PrintString("MRP", 8);
                    p.PrintString("Disc", 8);
                    //  p.PrintString("Gr.Wt", 8);
                    // p.PrintString("VA", 8);
                    //  p.PrintString("St.Cash", 8);
                    p.PrintString("Amount", 10);
                    p.NewLine = true;
                    p.PrintLine('-', 80);

                    #region SALESORDER
                    float Gwt, Qty, StWt, NetWt, StoneCash, VaPerc, Total, VaPercAftDis, MC, Wst, WstCash, Disc, MRP
                                          , TotQty = 0, TotGwt = 0, TotNetWt = 0, TotStWt = 0, TotVa = 0, TotAmt = 0, TotStCash = 0, totmrp = 0,
                                          totdis = 0;
                    string ProdCode, ItemName, brand, code;

                    using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                ("Select ItemName,BrandName,Code,Qty,MRP,Disc,TotalAmount FROM SALE.SalesOrderDotPrint WHERE SalesId=" + salesorderid[i] + "")).Tables[0])
                    {
                        foreach (DataRow r in dtdetails.Rows)
                        {


                            ItemName = r["ItemName"].ToString();
                            brand = r["BrandName"].ToString();
                            code = r["Code"].ToString();
                            Qty = Convert.ToInt32(r["Qty"].ToString());
                            MRP = Convert.ToSingle(r["MRP"].ToString());
                            Disc = Convert.ToSingle(r["Disc"].ToString());
                            // NetWt = Convert.ToSingle(r["NetWt"].ToString());
                            //StoneCash = Convert.ToSingle(r["StoneCash"].ToString());
                            //VaPerc = Convert.ToSingle(r["VAPerc"].ToString());
                            Total = Convert.ToSingle(r["TotalAmount"].ToString());
                            //VaPercAftDis = Convert.ToSingle(r["VApercAftDis"].ToString());
                            //MC = Convert.ToSingle(r["MC"].ToString());
                            //Wst = Convert.ToSingle(r["Wastage"].ToString());
                            //WstCash = Convert.ToSingle(r["WastageCash"].ToString());
                            p.PrintAlignment = PrintAlign.Left;

                            p.NewLine = false;

                            p.PrintString(ItemName, 12);
                            p.PrintString(brand, 12);
                            p.PrintString(code, 12);
                            //     p.PrintAlignment = PrintAlign.Right;
                            p.PrintString(Qty.ToString(), 8);
                            p.PrintString(MRP.ToString("f2"), 12);
                            // p.PrintString(StWt.ToString("f2"), 8);
                            p.PrintString(Disc.ToString("f2"), 8);
                            // p.PrintString(r["VA"].ToString(), 8);
                            //p.PrintString(StoneCash.ToString("f2"), 8);
                            p.PrintString(Total.ToString("f2"), 6);
                            p.NewLine = true;
                            TotQty += Qty; totmrp += MRP; totdis += Disc; //TotVa += Convert.ToSingle(r["VA"]); TotAmt += Total; 
                            //TotStCash += StoneCash;

                        }

                        p.NewLine = true;
                        p.PrintAlignment = PrintAlign.Left;
                        p.PrintLine('-', 80);
                        p.NewLine = false;
                        p.PrintAlignment = PrintAlign.Right;
                        p.PrintString(TotQty.ToString(), 29);
                        p.PrintString(totmrp.ToString("f2"), 8);
                        p.PrintString(totdis.ToString("f2"), 8);
                        // p.PrintString(TotGwt.ToString("f2"), 8);
                        //  p.PrintString(TotVa.ToString(), 8);
                        //  p.PrintString(TotStCash.ToString("f2"), 8);
                        p.PrintString(TotAmt.ToString("f2"), 10);
                        p.NewLine = true;
                        p.PrintAlignment = PrintAlign.Left;
                        p.PrintLine('-', 80);
                        p.PrintAlignment = PrintAlign.Right;
                    }
                    #endregion


                    #region OLD GOLD
                    if (CompId == "2")
                    {
                        if (oldGoldNoSales != 0)
                        {
                            p.NewLine = true;

                            p.PrintAlignment = PrintAlign.Center;
                            p.PrintString("OLD GOLD DETAILS");
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('=', 80);

                            p.NewLine = false;
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintString("ItemName", 20);
                            p.PrintAlignment = PrintAlign.Right;
                            p.PrintString("Gwt", 10);
                            p.PrintString("LessWt", 10);
                            p.PrintString("NetWt", 10);
                            p.PrintString("Rate", 10);
                            p.PrintString("Amount", 20);
                            p.NewLine = true;
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('-', 80);
                            p.NewLine = true;
                            p.PrintAlignment = PrintAlign.Left;
                            using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                         ("Select [Item Name],LessWt,Gwt,Rate,NetWt,Amount FROM SALE.VOldGoldReceiptMaterialsNew WHERE EntryId='" + oldGoldNoSales + "'")).Tables[0])
                            {
                                foreach (DataRow r in dtdetails.Rows)
                                {

                                    p.PrintAlignment = PrintAlign.Left;

                                    p.NewLine = false;
                                    p.PrintString("" + r["Item Name"].ToString(), 20);
                                    p.PrintAlignment = PrintAlign.Right;
                                    p.PrintString("" + Convert.ToSingle(r["Gwt"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["LessWt"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["NetWt"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["Rate"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["Amount"].ToString()).ToString("F2"), 20);


                                }
                                p.NewLine = true;
                                p.PrintAlignment = PrintAlign.Left;
                                p.PrintLine('-', 80);
                                p.NewLine = false;
                                p.PrintString("Total", 20);

                            }
                            float SGwt = 0, SLessWt = 0, SNetWt = 0, SRate = 0, SAmount = 0;
                            using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                           ("Select ISNULL(SUM(LessWt),0) as TotLessWt,ISNULL(SUM(Gwt),0) as TotGwt, ISNULL(SUM(NetWt),0) as TotNetWt,ISNULL(SUM(Amount),0)  as TotAmount FROM SALE.VOldGoldReceiptMaterialsNew WHERE EntryId= " + oldGoldNoSales + " ")).Tables[0])
                            {
                                DataRow r = dtdetails.Rows[0];
                                SGwt = Convert.ToSingle(r["TotGwt"].ToString());
                                SLessWt = Convert.ToSingle(r["TotLessWt"].ToString());
                                SNetWt = Convert.ToSingle(r["TotNetWt"].ToString());
                                SAmount = Convert.ToSingle(r["TotAmount"].ToString());

                                p.PrintAlignment = PrintAlign.Right;
                                p.PrintString("" + SGwt, 10);
                                p.PrintString("" + SLessWt, 10);
                                p.PrintString("" + SNetWt, 10);
                                p.PrintString("" + SAmount, 30);
                            }
                        }
                    }

                    #endregion

                    p.PrintLine('-');
                    p.PrintAlignment = PrintAlign.Right;
                    p.PrintString("Net Value: ".PadRight(29 - totalProdVal.ToString("f2").Length) + totalProdVal.ToString("f2"));
                    p.PrintString(("Cash Received: ".PadRight(29 - CashPaid.ToString("f2").Length) + CashPaid.ToString("f2")));

                    p.PrintString(("Credit Received: ".PadRight(29 - CreditCardPaid.ToString("f2").Length) + CreditCardPaid.ToString("f2")));

                    if (oldGoldRpt != 0)
                        p.PrintString(("Old Received: ".PadRight(29 - oldGoldRpt.ToString("f2").Length) + oldGoldRpt.ToString("f2")));

                    p.PrintString(("Total Received: ".PadRight(29 - (CashPaid + CreditCardPaid + oldGoldRpt).ToString("f2").Length) + (CashPaid + CreditCardPaid + oldGoldRpt).ToString("f2")));

                    p.PrintString(("Balance: ".PadRight(29 - BalanceAmount.ToString("f2").Length) + BalanceAmount.ToString("f2")));

                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintLine('-', 100);
                    p.PrintString("CASH RECEIVED IN WORDS : " + ToWords.ConvertToWords(Convert.ToSingle(CashPaid)));
                    p.PrintLine('-', 100);
                    p.PrintString("Sales Man " + SalesMan);
                    p.PrintString("E&OE");
                    p.PrintString(" ");
                    p.PrintAlignment = PrintAlign.Right;
                    p.PrintString("Authorised Signatory ");
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString(CreatedBy);
                    p.PrintString("THANKS, VISIT AGAIN");

                    if (ViewOnly)
                    {
                        p.FontStyle = NotepadPrintHelper.FontStyles.Compressed;
                        p.PrintString("Created On " + CreatedTime.ToString("dd-MMM-yyyy hh:mm:ss tt"));

                        p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                    }
                    if (CompId == "1")
                    {
                        if (!ViewOnly)
                        {
                            for (int j = 0; j <= 10; j++)
                            {

                                p.PrintString(" ");
                            }
                        }

                        OldGoldInvoice(oldGoldNoSales, p);
                    }
                }




            }





            if (!ViewOnly)
            {
                p.Print();
            }
            else
            {
                p.CloseWriter();
            }

        }
        #endregion


        #region Old   Print
        private static string PSalesNo_Old;

        private static float TotAmt, LessAmt, NetAmt;
        #region Get Sales Details

        private static bool GetOldDetails(long Oldid)
        {
            DBConn = new Gramboo.DataController();
            using (DataTable dt = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                  ("Select * FROM SALE.VOldGoldReceiptPrint WHERE EntryId='" + Oldid + "'")).Tables[0])
            {
                if (dt.Rows.Count > 0)
                {

                    CompId = (dt.Rows[0]["Company_Id"] == DBNull.Value ? "" : dt.Rows[0]["Company_Id"].ToString());
                    Company = (dt.Rows[0]["Comp_Name"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Name"].ToString());
                    Comp_Add1 = (dt.Rows[0]["Comp_Addr1"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Addr1"].ToString());
                    Comp_Add2 = (dt.Rows[0]["Comp_Addr2"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Addr2"].ToString());
                    Comp_Place = (dt.Rows[0]["Comp_Place"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Place"].ToString());
                    Comp_City = (dt.Rows[0]["Comp_City"] == DBNull.Value ? "" : dt.Rows[0]["Comp_City"].ToString());
                    Comp_Dist = (dt.Rows[0]["Comp_District"] == DBNull.Value ? "" : dt.Rows[0]["Comp_District"].ToString());
                    Comp_State = (dt.Rows[0]["Comp_State"] == DBNull.Value ? "" : dt.Rows[0]["Comp_State"].ToString());

                    Comp_phone = (dt.Rows[0]["Comp_Phone"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Phone"].ToString());
                    TinNo = (dt.Rows[0]["Comp_TIN"] == DBNull.Value ? "" : dt.Rows[0]["Comp_TIN"].ToString());
                    CstNo = (dt.Rows[0]["Comp_CST"] == DBNull.Value ? "" : dt.Rows[0]["Comp_CST"].ToString());
                    InvoiceDate = Convert.ToDateTime(dt.Rows[0]["Voucher Date"] == DBNull.Value ? "" : dt.Rows[0]["Voucher Date"].ToString());
                    InvoiceNo = (dt.Rows[0]["Voucher No"] == DBNull.Value ? "" : dt.Rows[0]["Voucher No"].ToString());
                    CustomerName = (dt.Rows[0]["Customer Name"] == DBNull.Value ? "" : dt.Rows[0]["Customer Name"].ToString());
                    BranchName = (dt.Rows[0]["BranchName"] == DBNull.Value ? "" : dt.Rows[0]["BranchName"].ToString());
                    PSalesNo_Old = (dt.Rows[0]["Sales No"] == DBNull.Value ? "" : dt.Rows[0]["Sales No"].ToString());
                    TotAmt = Convert.ToSingle((dt.Rows[0]["TotalAmount"] == DBNull.Value ? "" : dt.Rows[0]["TotalAmount"].ToString()));
                    LessAmt = Convert.ToSingle((dt.Rows[0]["LessAmount"] == DBNull.Value ? "" : dt.Rows[0]["LessAmount"].ToString()));
                    NetAmt = Convert.ToSingle((dt.Rows[0]["NetAmount"] == DBNull.Value ? "" : dt.Rows[0]["NetAmount"].ToString()));


                    return true;
                }

                else
                {

                    return false;

                }
            }
        }

        #endregion
        public static void OldGoldInvoice(long Oldid, bool ViewOnly)
        {
            OldGoldInvoice(new long[] { Oldid }, ViewOnly);
        }

        public static void OldGoldInvoice(long[] salesid, bool ViewOnly)
        {
            DBConn = new Gramboo.DataController();


            NotepadPrintHelper p = new NotepadPrintHelper();
            p.OpenWriter(Path.GetTempPath() + "Print.txt");

            for (int i = 0; i <= salesid.GetLength(0) - 1; i++)
            {
                OldGoldInvoice(salesid[i], p);
            }
            if (!ViewOnly)
            {
                p.Print();
            }
            else
            {
                p.CloseWriter();
            }


        }



        public static void OldGoldInvoice(long OldID, NotepadPrintHelper p)
        {

            if (GetOldDetails(OldID))
            {
                #region Header
                p.FontStyle = NotepadPrintHelper.FontStyles.Big;
                p.NewLine = true;
                p.PrintAlignment = PrintAlign.Center;

                if (CompId == "1")
                {
                    p.PrintString(Company, 80);
                    p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                    p.PrintString(Comp_Add1 + "," + Comp_Add2, 80);
                    p.PrintString("PHONE:" + Comp_phone, 80);
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString("TIN :" + TinNo);
                    p.PrintString("");
                    p.PrintString("");
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString("");
                    p.PrintAlignment = PrintAlign.Center;

                    p.PrintString("THE KERALA VALUE ADDED TAX RULES,2005");
                    p.PrintString("FORM NO. 8E");
                    p.PrintString("PURCHASE BILL");
                    p.PrintString("CASH");

                }
                else
                {

                    p.PrintString("OLD GOLD PURCHASE BILL");
                }
                p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                p.PrintString(" ");
                p.PrintString(" ");

                p.PrintAlignment = PrintAlign.Left;

                p.NewLine = false;
                p.PrintString("BILL No.    :" + InvoiceNo, 50);
                p.PrintString("Date : " + InvoiceDate);
                p.NewLine = true;
                p.PrintAlignment = PrintAlign.Left;
                p.PrintString("Customer Name  :" + CustomerName);
                p.NewLine = true;
                p.PrintAlignment = PrintAlign.Left;
                p.PrintLine('=', 80);

                p.NewLine = false;
                p.PrintAlignment = PrintAlign.Left;
                p.PrintString("ItemName", 20);
                p.PrintAlignment = PrintAlign.Right;
                p.PrintString("Gwt", 10);
                p.PrintString("LessWt", 10);
                p.PrintString("NetWt", 10);
                p.PrintString("Rate", 10);
                p.PrintString("Amount", 20);
                p.NewLine = true;
                p.PrintAlignment = PrintAlign.Left;
                p.PrintLine('-', 80);
                p.NewLine = true;
                p.PrintAlignment = PrintAlign.Left;
                #endregion

                #region Old Details
                float SGwt = 0, SLessWt = 0, SNetWt = 0, SAmount = 0;
                using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
              ("Select [Item Name],LessWt,Gwt,Rate,NetWt,Amount FROM SALE.VOldGoldReceiptMaterialsNew WHERE EntryId=" + OldID + "")).Tables[0])
                {

                    foreach (DataRow r in dtdetails.Rows)
                    {

                        p.PrintAlignment = PrintAlign.Left;

                        p.NewLine = false;
                        p.PrintString("" + r["Item Name"].ToString(), 20);
                        p.PrintAlignment = PrintAlign.Right;
                        p.PrintString("" + Convert.ToSingle(r["Gwt"].ToString()).ToString("F2"), 10);
                        p.PrintString("" + Convert.ToSingle(r["LessWt"].ToString()).ToString("F2"), 10);
                        p.PrintString("" + Convert.ToSingle(r["NetWt"].ToString()).ToString("F2"), 10);
                        p.PrintString("" + Convert.ToSingle(r["Rate"].ToString()).ToString("F2"), 10);
                        p.PrintString("" + Convert.ToSingle(r["Amount"].ToString()).ToString("F2"), 20);
                        p.NewLine = true;


                        SGwt += Convert.ToSingle(r["Gwt"].ToString());
                        SLessWt += Convert.ToSingle(r["LessWt"].ToString());
                        SNetWt += Convert.ToSingle(r["NetWt"].ToString());
                        SAmount += Convert.ToSingle(r["Amount"].ToString());
                    }

                    p.NewLine = true;
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintLine('-', 80);
                    p.NewLine = false;
                    p.PrintString("Total", 20);


                }


                p.PrintAlignment = PrintAlign.Right;
                p.PrintString("" + SGwt.ToString("F2"), 10);
                p.PrintString("" + SLessWt.ToString("F2"), 10);
                p.PrintString("" + SNetWt.ToString("F2"), 10);
                p.PrintString("" + SAmount.ToString("F2"), 30);

                p.NewLine = true;
                p.PrintAlignment = PrintAlign.Left;
                p.PrintLine('-', 80);
                p.PrintAlignment = PrintAlign.Right;

                p.PrintString("Total Value:".PadRight(40 - TotAmt.ToString("f2").Length) + TotAmt.ToString("f2"));
                p.PrintString("Discount:".PadRight(40 - LessAmt.ToString("f2").Length) + LessAmt.ToString("f2"));
                p.PrintString("Net Purchase Cost:".PadRight(40 - NetAmt.ToString("f2").Length) + NetAmt.ToString("f2"));
                if (PSalesNo_Old != "0")
                    p.PrintString("SALES INVOICE:".PadRight(40 - PSalesNo_Old.Length) + PSalesNo_Old);
                #endregion

                p.PrintAlignment = PrintAlign.Left;
                p.PrintLine('-', 100);
                p.PrintString("NET PURCHASE COST IN WORDS : " + ToWords.ConvertToWords(NetAmt));
                p.PrintLine('-', 100);
                p.PrintString("E&OE");
                p.PrintString(" ");
                p.PrintAlignment = PrintAlign.Right;
                p.PrintString("Authorised Signatory ");
                p.PrintAlignment = PrintAlign.Left;



            }

        }
        #endregion



        #region  Booking

        private static string SalesmanName;

        private static DateTime BookingDate;

        private static float TotalAmt, CreditPaid, BookedWt, bookedrate;



        #region Get Gold Booking Details

        private static bool GetGoldBookingDetails(long BookId)
        {
            DBConn = new Gramboo.DataController();
            using (DataTable dt = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                  ("SELECT * FROM SALE.VGoldBookingMasterList where BookId ='" + BookId + "'")).Tables[0])
            {
                //[Booking No],[Customer Name],[Booking Date],[Booked Wt],[Booked Rate],[Due Date],
                //[Cash Paid],[Credit Card Paid],[Total Amount],[Sales Man Name] 
                if (dt.Rows.Count > 0)
                {

                    CompId = (dt.Rows[0]["Company_Id"] == DBNull.Value ? "" : dt.Rows[0]["Company_Id"].ToString());
                    Company = (dt.Rows[0]["Comp_Name"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Name"].ToString());
                    Comp_Add1 = (dt.Rows[0]["Comp_Addr1"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Addr1"].ToString());
                    Comp_Add2 = (dt.Rows[0]["Comp_Addr2"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Addr2"].ToString());
                    Comp_Place = (dt.Rows[0]["Comp_Place"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Place"].ToString());
                    Comp_City = (dt.Rows[0]["Comp_City"] == DBNull.Value ? "" : dt.Rows[0]["Comp_City"].ToString());
                    Comp_Dist = (dt.Rows[0]["Comp_District"] == DBNull.Value ? "" : dt.Rows[0]["Comp_District"].ToString());
                    Comp_State = (dt.Rows[0]["Comp_State"] == DBNull.Value ? "" : dt.Rows[0]["Comp_State"].ToString());
                    OldNo = (dt.Rows[0]["Old Gold No"] == DBNull.Value ? "" : dt.Rows[0]["Old Gold No"].ToString());
                    Comp_phone = (dt.Rows[0]["Comp_Phone"] == DBNull.Value ? "" : dt.Rows[0]["Comp_Phone"].ToString());
                    TinNo = (dt.Rows[0]["Comp_TIN"] == DBNull.Value ? "" : dt.Rows[0]["Comp_TIN"].ToString());
                    CstNo = (dt.Rows[0]["Comp_CST"] == DBNull.Value ? "" : dt.Rows[0]["Comp_CST"].ToString());
                    InvoiceDate = Convert.ToDateTime(dt.Rows[0]["Booking Date"] == DBNull.Value ? "" : dt.Rows[0]["Booking Date"].ToString());
                    InvoiceNo = (dt.Rows[0]["Booking No"] == DBNull.Value ? "" : dt.Rows[0]["Booking No"].ToString());
                    CustomerName = (dt.Rows[0]["Customer Name"] == DBNull.Value ? "" : dt.Rows[0]["Customer Name"].ToString());
                    SalesmanName = (dt.Rows[0]["Sales Man Name"] == DBNull.Value ? "" : dt.Rows[0]["Sales Man Name"].ToString());
                    oldGoldNoSales = Convert.ToInt64(dt.Rows[0]["OldGoldId"] == DBNull.Value ? "0" : dt.Rows[0]["OldGoldId"].ToString());
                    DueDate = Convert.ToDateTime(dt.Rows[0]["Due Date"] == DBNull.Value ? "" : dt.Rows[0]["Due Date"].ToString());
                    TotalAmt = Convert.ToSingle((dt.Rows[0]["Total Amount"] == DBNull.Value ? "" : dt.Rows[0]["Total Amount"].ToString()));
                    CashPaid = Convert.ToSingle((dt.Rows[0]["Cash Paid"] == DBNull.Value ? "" : dt.Rows[0]["Cash Paid"].ToString()));
                    CreditPaid = Convert.ToSingle((dt.Rows[0]["Credit Card Paid"] == DBNull.Value ? "" : dt.Rows[0]["Credit Card Paid"].ToString()));
                    BookedWt = Convert.ToSingle((dt.Rows[0]["Booked Wt"] == DBNull.Value ? "" : dt.Rows[0]["Booked Wt"].ToString()));
                    bookedrate = Convert.ToSingle((dt.Rows[0]["Booked Rate"] == DBNull.Value ? "" : dt.Rows[0]["Booked Rate"].ToString()));
                    oldGoldRpt = Convert.ToSingle(dt.Rows[0]["TotalOldGoldReceipt"] == DBNull.Value ? "" : dt.Rows[0]["TotalOldGoldReceipt"].ToString());
                    //  PSalesNo_Old = (dt.Rows[0]["Sales No"] == DBNull.Value ? "" : dt.Rows[0]["Sales No"].ToString());

                    return true;
                }

                else
                {

                    return false;

                }


            }

        }

        #endregion


        #region Gold Booking Print
        public static void GoldBookingInvoice(long BookId, bool ViewOnly)
        {

            GoldBookingInvoice(new long[] { BookId }, ViewOnly);
        }

        public static void GoldBookingInvoice(long[] BookId, bool ViewOnly)
        {
            DBConn = new Gramboo.DataController();


            NotepadPrintHelper p = new NotepadPrintHelper();
            p.OpenWriter(Path.GetTempPath() + "Print.txt");





            for (long i = 0; i <= BookId.Length - 1; i++)
            {
                #region HEADER


                //public static void GoldBookingInvoice(long BookId, NotepadPrintHelper p)
                //{ 
                //    #region Header


                if (GetGoldBookingDetails(BookId[i]))
                {

                    p.FontStyle = NotepadPrintHelper.FontStyles.Big;
                    p.NewLine = true;
                    p.PrintAlignment = PrintAlign.Center;

                    if (CompId == "1")
                    {
                        p.PrintString(Company, 80);
                        p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                        p.PrintString(Comp_Add1 + "," + Comp_Add2, 80);
                        p.PrintString("PHONE:" + Comp_phone, 80);
                        p.PrintAlignment = PrintAlign.Left;
                        p.PrintString("TIN :" + TinNo);
                        p.PrintString("");
                        p.PrintString("");
                        p.PrintAlignment = PrintAlign.Left;
                        p.PrintString("");
                        p.PrintAlignment = PrintAlign.Center;

                        // p.PrintString("THE KERALA VALUE ADDED TAX RULES,2005");
                        // p.PrintString("FORM NO. 8E");
                        p.PrintString("ADVANCE RECEIPT");
                        //p.PrintString("CASH");

                    }
                    else
                    {
                        p.PrintAlignment = PrintAlign.Center;
                        p.PrintString("ADVANCE RECEIPT");
                    }

                #endregion


                    p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                    p.PrintString(" ");
                    p.PrintString(" ");

                    p.PrintAlignment = PrintAlign.Left;

                    p.NewLine = false;
                    p.PrintString("Booking No.    :" + InvoiceNo, 50);
                    p.PrintString("Booking Date :" + InvoiceDate.ToString("dd/MMM/yyyy"));
                    p.NewLine = true;
                    p.PrintAlignment = PrintAlign.Left;
                    p.NewLine = false;
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString("Customer Name  :" + CustomerName, 50);
                    p.PrintString("Due Date     :" + DueDate.ToString("dd/MMM/yyyy"));
                    p.NewLine = true;
                    p.PrintAlignment = PrintAlign.Right;
                    //p.PrintLine('=', 80);
                    p.NewLine = false;
                    p.PrintAlignment = PrintAlign.Left;
                    //p.PrintString("ItemName", 20);
                    //p.PrintAlignment = PrintAlign.Right;
                    //p.PrintString("Gwt", 10);
                    //p.PrintString("LessWt", 10);
                    //p.PrintString("NetWt", 10);
                    //p.PrintString("Rate", 10);
                    //p.PrintString("Amount", 20);
                    p.PrintString("Booked Wt      :" + BookedWt, 50);
                    p.PrintString("Rate         :" + bookedrate);
                    p.NewLine = true;
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintLine('-', 80);
                    p.PrintAlignment = PrintAlign.Right;
                    p.PrintString("Cash :".PadRight(40 - CashPaid.ToString("f2").Length) + CashPaid.ToString("f2"));
                    p.PrintString("Credit:".PadRight(40 - CreditPaid.ToString("f2").Length) + CreditPaid.ToString("f2"));
                    if (oldGoldRpt != 0)
                        p.PrintString(("Old Bill No " + OldNo).PadRight(40 - oldGoldRpt.ToString("f2").Length) + oldGoldRpt.ToString("f2"));
                    p.PrintString("Total Amount :".PadRight(40 - TotalAmt.ToString("f2").Length) + TotalAmt.ToString("f2"));


                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintLine('-', 100);
                    p.PrintString("NET PURCHASE COST IN WORDS : " + ToWords.ConvertToWords(TotalAmt));
                    p.PrintLine('-', 100);
                    p.PrintString("E&OE");
                    p.NewLine = true;
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString("SalesMan Name  :" + SalesmanName);
                    p.PrintString(" ");
                    p.PrintAlignment = PrintAlign.Right;
                    p.PrintString("Authorised Signatory ");
                    p.PrintAlignment = PrintAlign.Left;


                    //p.PrintString("Cash :" + CashPaid,50);
                    //p.NewLine = true;
                    //p.PrintAlignment = PrintAlign.Right;
                    //p.PrintString("Credit  :" + CreditPaid);
                    //p.PrintLine('-', 80);
                    //p.NewLine = true;
                    //p.PrintAlignment = PrintAlign.Right;
                    //p.PrintString("Total Amount  :" + TotalAmt);

                    //p.Print();





                    #region OLD GOLD

                    if (CompId == "2")
                    {
                        if (oldGoldNoSales != 0)
                        {
                            p.NewLine = true;

                            p.PrintAlignment = PrintAlign.Center;
                            p.PrintString("OLD GOLD DETAILS");
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('=', 80);

                            p.NewLine = false;
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintString("ItemName", 20);
                            p.PrintAlignment = PrintAlign.Right;
                            p.PrintString("Gwt", 10);
                            p.PrintString("LessWt", 10);
                            p.PrintString("NetWt", 10);
                            p.PrintString("Rate", 10);
                            p.PrintString("Amount", 20);
                            p.NewLine = true;
                            p.PrintAlignment = PrintAlign.Left;
                            p.PrintLine('-', 80);
                            p.NewLine = true;
                            p.PrintAlignment = PrintAlign.Left;
                            using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                         ("Select [Item Name],LessWt,Gwt,Rate,NetWt,Amount FROM SALE.VOldGoldReceiptMaterialsNew WHERE EntryId='" + oldGoldNoSales + "'")).Tables[0])
                            {
                                foreach (DataRow r in dtdetails.Rows)
                                {

                                    p.PrintAlignment = PrintAlign.Left;

                                    p.NewLine = false;
                                    p.PrintString("" + r["Item Name"].ToString(), 20);
                                    p.PrintAlignment = PrintAlign.Right;
                                    p.PrintString("" + Convert.ToSingle(r["Gwt"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["LessWt"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["NetWt"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["Rate"].ToString()).ToString("F2"), 10);
                                    p.PrintString("" + Convert.ToSingle(r["Amount"].ToString()).ToString("F2"), 20);


                                }
                                p.NewLine = true;
                                p.PrintAlignment = PrintAlign.Left;
                                p.PrintLine('-', 80);
                                p.NewLine = false;
                                p.PrintString("Total", 20);

                            }
                            float SGwt = 0, SLessWt = 0, SNetWt = 0, SRate = 0, SAmount = 0;
                            using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                           ("Select ISNULL(SUM(LessWt),0) as TotLessWt,ISNULL(SUM(Gwt),0) as TotGwt, ISNULL(SUM(NetWt),0) as TotNetWt,ISNULL(SUM(Amount),0)  as TotAmount FROM SALE.VOldGoldReceiptMaterialsNew WHERE EntryId= " + oldGoldNoSales + " ")).Tables[0])
                            {
                                DataRow r = dtdetails.Rows[0];
                                SGwt = Convert.ToSingle(r["TotGwt"].ToString());
                                SLessWt = Convert.ToSingle(r["TotLessWt"].ToString());
                                SNetWt = Convert.ToSingle(r["TotNetWt"].ToString());
                                SAmount = Convert.ToSingle(r["TotAmount"].ToString());

                                p.PrintAlignment = PrintAlign.Right;
                                p.PrintString("" + SGwt, 10);
                                p.PrintString("" + SLessWt, 10);
                                p.PrintString("" + SNetWt, 10);
                                p.PrintString("" + SAmount, 30);
                            }
                        }
                    }

                    #endregion

                    if (ViewOnly)
                    {
                        p.FontStyle = NotepadPrintHelper.FontStyles.Compressed;
                        p.PrintString("Created On " + CreatedTime.ToString("dd-MMM-yyyy hh:mm:ss tt"));

                        p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                    }
                    if (CompId == "1")
                    {
                        if (!ViewOnly)
                        {
                            for (int j = 0; j <= 10; j++)
                            {

                                p.PrintString(" ");
                            }
                        }

                        OldGoldInvoice(oldGoldNoSales, p);
                    }



                }
            }


            if (!ViewOnly)
            {
                p.Print();
            }
            else
            {
                p.CloseWriter();
            }


        }
        #endregion


        #endregion


        #region Barcode Print
        public static void PrintBarcode(long prodcodeid)
        {
            long[] l = new long[1];
            l[0] = prodcodeid;
            PrintBarcode(l);
        }
        public static void PrintBarcode(long[] prodcodeid)
        {

            List<string> lines = new List<string>();

            foreach (long r in prodcodeid)
            {
                char c1 = '\u0002';

                DBConn = new Gramboo.DataController();

                using (DataTable dt = DBConn.GetData(new System.Data.SqlClient.SqlCommand("select * from STK.VProdCodeMaster where prodcodeid=" + r), "Data").Tables[0])
                {

                    if (dt.Rows.Count >= 1)
                    {
                        lines.Add("m");
                        lines.Add("L");
                        lines.Add("D11");
                        lines.Add("H16");
                        lines.Add("FB+");
                        //  lines.Add("D12");
                        //lines.Add("ZT");
                        //lines.Add("JF");
                        //lines.Add("O");
                        //lines.Add("R92,0");
                        //lines.Add("f100");
                        //lines.Add("N");

                        float Nos,    MRP  ;
                        string Code, Itemname;
                        //  ChqAmt = Convert.ToSingle(dt.Rows[0]["ChqAmt"] == DBNull.Value ? "0" : dt.Rows[0]["ChqAmt"].ToString());
                        Code = (dt.Rows[0]["Code"] == DBNull.Value ? "0" : dt.Rows[0]["Code"].ToString());
                        Nos = Convert.ToSingle(dt.Rows[0]["Nos"].ToString());
                        Itemname = (dt.Rows[0]["Book Name"] == DBNull.Value ? "0" : dt.Rows[0]["Book Name"].ToString());
                        //  netwt = Convert.ToSingle(dt.Rows[0]["NetWt"].ToString());
                        MRP = Convert.ToSingle(dt.Rows[0]["MRP"].ToString());
                        //  DiaNo = ConE:\LINDA\project\project\Kallans\Classes\DotMarixPrinting.csvert.ToSingle(dt.Rows[0]["DiaNo"].ToString());
                        //  DiaWt = Convert.ToSingle(dt.Rows[0]["DiaWt"].ToString());
                        lines.Add("1e1105000800120 " + dt.Rows[0]["BookCode"].ToString() + "");
                        lines.Add("191100100750380 " + dt.Rows[0]["Book Name"].ToString() + "");
                        if (dt.Rows[0]["Description"].ToString().Length > 15)
                        {
                            lines.Add("191100100250380 " + dt.Rows[0]["Description"].ToString().Substring(0, 15) + "");
                            lines.Add("191100100250380 " + dt.Rows[0]["Description"].ToString().Substring(14, dt.Rows[0]["Description"].ToString().Length - 15) + "");
                        }
                        else
                        {
                            lines.Add("191100100250380 " + dt.Rows[0]["Description"].ToString() + "");

                        }
                        lines.Add("191100101000380 Code:" + Code + "");
                        //if (Nos != 0)
                        //{
                        //    lines.Add("191100100750380 Nos:" + Nos.ToString("f0") + "");
                        //}
                        //if (DiaWt != 0)
                        //{
                        //    lines.Add("A415,35,2,1,1,1,N,\"DNo/Wt :" + DiaNo.ToString("F0") + @"/" + DiaWt.ToString("F2") + "\"");
                        //}
                        lines.Add("191100100500380 MRP :" + MRP.ToString("F0") + "");
                        //lines.Add("1a3104500700000" + r.Cells["ProdCode"].Value.ToString());
                        //lines.Add("1911A0600450010" + r.Cells["ProdCode"].Value.ToString());


                        //lines.Add("1911A0600200010" + r.Cells["Purity Name"].Value.ToString());
                        ////lines.Add("1911A0600000010 VVS EF");
                        ////lines.Add("1911A0600900275GWT    : " + r.Cells["Prod. Wt"].Value.ToString());
                        //lines.Add("1911A0600850275GWT    : " + r.Cells["Gwt"].Value.ToString());
                        //lines.Add("1911A0600680275NET WT : " + r.Cells["NetWt"].Value.ToString());

                        //lines.Add("1911A0600460275SNo    : " + r.Cells["StWt"].Value.ToString());

                        //if (Convert.ToSingle(r.Cells["DiaNo"].Value) > 0)
                        //{

                        //    lines.Add("1911A0600240275DNo    : " + r.Cells["DiaNo"].Value.ToString() + "/" + r.Cells["DiaWt"].Value.ToString());
                        //}
                        lines.Add("Q0001");
                        lines.Add("E");
                    }
                }

            } 
            System.IO.File.WriteAllLines(System.IO.Path.GetTempPath().ToString() + "Barcode.txt", lines);

            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            System.IO.File.WriteAllLines(System.IO.Path.GetTempPath().ToString() + "Barcode.bat", new string[] { " Copy  " + (char)34 + System.IO.Path.GetTempPath().ToString() + "Barcode.txt " + (char)34 + " LPT2 " });
            myProcess.StartInfo.FileName = System.IO.Path.GetTempPath().ToString() + "Barcode.bat"; 
            myProcess.Start(); 
            myProcess.Close();
             


        }
        #endregion



        #region TabletPrint
        private static long EstNo, ProdcodeId;
        private static DateTime EstDate;
        private static string ItemName, EmployeeName, ModelName, VA;
        private static float Gwt, StoneWt, Diawt, Netwt, DiamondNo, Total, DiaCash, StoneCash, TotalAmount, StRt, GoldCash, MetalRate, Wastage, mc, TaxPerc1, TaxAmount, VAP, PlNo, PlCash, PlWt;
        private static string MRP;

        #region tabletdetail
        private static bool GetTabletDetails(long EntryId)
        {
            DBConn = new Gramboo.DataController();
            using (DataTable dt = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                  ("Select  *  FROM SALE.VTabletMaster WHERE EntryId='" + EntryId + "'")).Tables[0])
            {
                if (dt.Rows.Count > 0)
                {
                    EstNo = Convert.ToInt64((dt.Rows[0]["EstNo"].ToString() == "" ? "0" : dt.Rows[0]["EstNo"].ToString()));
                    EmployeeName = (dt.Rows[0]["EmpName"] == DBNull.Value ? "" : dt.Rows[0]["EmpName"].ToString());
                    EstDate = Convert.ToDateTime(dt.Rows[0]["EstDate"] == DBNull.Value ? "" : dt.Rows[0]["EstDate"].ToString());
                    MetalRate = Convert.ToSingle(dt.Rows[0]["GoldRate"].ToString() == "" ? "0" : dt.Rows[0]["GoldRate"].ToString());
                    Total = Convert.ToSingle(dt.Rows[0]["TotalAmount"].ToString() == "" ? "0" : dt.Rows[0]["TotalAmount"].ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        #endregion tabletdetail
        public static void TabletInvoice(long Entryid, bool ViewOnly, bool ExcludeOld)
        {

            TabletInvoice(new long[] { Entryid }, ViewOnly, ExcludeOld);
        }
        public static void TabletInvoice(long[] Entryid, bool ViewOnly, bool ExcludeOld)
        {
            DBConn = new Gramboo.DataController();
            NotepadPrintHelper p = new NotepadPrintHelper();
            p.OpenWriter(Path.GetTempPath() + "Print.txt");
            for (long i = 0; i <= Entryid.Length - 1; i++)
            {
                #region HEADER
                if (GetTabletDetails(Entryid[i]))
                {
                    DBConn = new Gramboo.DataController();
                    p.FontStyle = NotepadPrintHelper.FontStyles.Big;
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString("Estimate", 80);
                    p.NewLine = true;
                    p.FontStyle = NotepadPrintHelper.FontStyles.Regular;
                    p.PrintAlignment = PrintAlign.Left;
                    p.PrintString("EstNo   : " + EstNo, 40);
                    p.PrintString("EstDate : " + EstDate.ToString("dd-MMM-yyyy"), 40);
                    p.PrintString("EmpName : " + EmployeeName, 40);
                    p.PrintString("GoldRate: " + MetalRate, 40);
                    p.PrintLine('-', 20);
                #endregion HEADER
                    #region Detail
                    if (Entryid[i] != null)
                    {
                        using (DataTable dtdetails = DBConn.GetData(new System.Data.SqlClient.SqlCommand
                          ("Select ProdcodeId,ItemName,Gwt,StoneWt,Diawt, DiaNo ,description,MetalCash,StoneRate,PlNo,PlCash,PlWt,StoneCash,EmpName,DiaCash,NetWt,TotalAmt,VA,TaxPerc,TaxAmount,VAPer,VAP FROM SALE.VTabletEstimateDetails WHERE EntryId='" + Entryid[i] + "'")).Tables[0])
                        {
                            int y = 0;
                            foreach (DataRow r in dtdetails.Rows)
                            {
                                y++;
                                Gwt = Convert.ToSingle(r["Gwt"] == DBNull.Value ? "0" : r["Gwt"].ToString());
                                ItemName = (r["ItemName"] == DBNull.Value ? "" : r["ItemName"].ToString());
                                ModelName = (r["description"] == DBNull.Value ? "" : r["description"].ToString());
                                ProdcodeId = Convert.ToInt64((r["ProdcodeId"].ToString() == "" ? "0" : r["ProdcodeId"].ToString()));
                                StRt = Convert.ToSingle(r["StoneRate"] == DBNull.Value ? "0" : r["StoneRate"].ToString());
                                StoneWt = Convert.ToSingle(r["StoneWt"] == DBNull.Value ? "0" : r["StoneWt"].ToString());
                                Diawt = Convert.ToSingle(r["Diawt"] == DBNull.Value ? "0" : r["Diawt"].ToString());
                                PlWt = Convert.ToSingle(r["PlWt"] == DBNull.Value ? "0" : r["PlWt"].ToString());
                                Netwt = Convert.ToSingle(r["Netwt"] == DBNull.Value ? "0" : r["Netwt"].ToString());
                                VAP = Convert.ToSingle(r["VAP"] == DBNull.Value ? "0" : r["VAP"].ToString());
                                if (VAP == 0)
                                {
                                    VA = r["VAPer"] == DBNull.Value ? "0" : r["VAPer"].ToString() + "%";
                                }
                                else
                                    VA = r["VA"] == DBNull.Value ? "0" : r["VA"].ToString();
                                StoneCash = Convert.ToSingle(r["StoneCash"] == DBNull.Value ? "0" : r["StoneCash"].ToString());
                                DiaCash = Convert.ToSingle(r["DiaCash"] == DBNull.Value ? "0" : r["DiaCash"].ToString());
                                DiamondNo = Convert.ToSingle(r["DiaNo"] == DBNull.Value ? "0" : r["DiaNo"].ToString());
                                PlCash = Convert.ToSingle(r["PlCash"] == DBNull.Value ? "0" : r["PlCash"].ToString());
                                PlNo = Convert.ToSingle(r["PlNo"] == DBNull.Value ? "0" : r["PlNo"].ToString());
                                TotalAmount = Convert.ToSingle(r["TotalAmt"] == DBNull.Value ? "0" : r["TotalAmt"].ToString());
                                GoldCash = Convert.ToSingle(r["MetalCash"].ToString() == "" ? "0" : r["MetalCash"].ToString());
                                TaxPerc1 = Convert.ToSingle(r["TaxPerc"].ToString() == "" ? "0" : r["TaxPerc"].ToString());
                                TaxAmount = Convert.ToSingle(r["TaxAmount"].ToString() == "" ? "0" : r["TaxAmount"].ToString());



                                p.NewLine = true;
                                p.PrintAlignment = PrintAlign.Left;
                                p.PrintString("Prodcode   : " + ProdcodeId.ToString(), 40);
                                p.PrintString("ItemName   : " + ItemName, 40);
                                p.PrintString("Description: " + ModelName, 40);
                                p.PrintString("Gwt        : " + Gwt.ToString(), 40);
                                p.PrintString("NetWt      : " + Netwt.ToString(), 40);
                                p.PrintString("GoldCash   : " + GoldCash.ToString(), 40);
                                p.PrintString("StoneWt    : " + StoneWt.ToString() + "(Cts)", 40);
                                p.PrintString("StoneRate  : " + StRt.ToString(), 40);
                                p.PrintString("StoneCash  : " + StoneCash.ToString(), 40);
                                p.PrintString("DiaNo      : " + DiamondNo.ToString(), 40);
                                p.PrintString("DiaWt      : " + Diawt.ToString(), 40);
                                p.PrintString("DiaCash    : " + DiaCash.ToString(), 40);
                                p.PrintString("PlNo       : " + PlNo.ToString(), 40);
                                p.PrintString("PlWt       : " + PlWt.ToString(), 40);
                                p.PrintString("PlCash     : " + PlCash.ToString(), 40);
                                p.PrintString("VA         : " + VA.ToString(), 40);
                                p.PrintString("TaxPerc    : " + TaxPerc1.ToString(), 40);
                                p.PrintString("TaxAmount  : " + TaxAmount.ToString(), 40);
                                p.PrintString("TotalAmount: " + TotalAmount.ToString(), 40);
                                p.PrintLine('-', 20);
                            }
                            p.PrintString("Total      : " + Total.ToString(), 40);
                        }
                    }
                }
            }
                    #endregion
            #region footer
            if (!ViewOnly)
            {
                p.Print();
            }
            else
            {
                p.CloseWriter();
            }
        }
            #endregion footer
        #endregion
        #region  Barcode Print V@2
        public static void PrintBarcodeGold(long prodcodeid)
        {
            long[] l = new long[1];
            l[0] = prodcodeid;
            PrintBarcodeGold(l);
        }
        public static void PrintBarcodeGold(long[] prodcodeid)
        {

            List<string> lines = new List<string>();
            int c = 1;
            foreach (long r in prodcodeid)
            {
                char c1 = '\u0002';

                DBConn = new Gramboo.DataController();

                using (DataTable dt = DBConn.GetData(new System.Data.SqlClient.SqlCommand("select * from STK.VProdCodeMaster where prodcodeid=" + r), "Data").Tables[0])
                {

                    if (dt.Rows.Count >= 1)
                    {

                        if (c % 2 == 1)
                        {

                            lines.Add(c1 + "m");
                            lines.Add(c1 + "f760");
                            lines.Add(c1 + "L");
                            lines.Add("D11");
                            lines.Add("H16");

                        }


                        float Gwt, stwt, netwt, va, stcash, nos, DiaNo, DiaWt;

                        string itemname = "";
                        // Prodcode=dt.Rows[0]["ProdCode"].ToString();
                        Gwt = Convert.ToSingle(dt.Rows[0]["Gwt"].ToString());
                        stwt = Convert.ToSingle(dt.Rows[0]["StWt"].ToString());
                        netwt = Convert.ToSingle(dt.Rows[0]["NetWt"].ToString());
                        stcash = Convert.ToSingle(dt.Rows[0]["StoneCash"].ToString());
                        itemname = dt.Rows[0]["Item Name"].ToString();
                        nos = Convert.ToSingle(dt.Rows[0]["Nos"].ToString());
                        DiaNo = Convert.ToSingle(dt.Rows[0]["DiaNo"].ToString());
                        DiaWt = Convert.ToSingle(dt.Rows[0]["DiaWt"].ToString());
                        va = Convert.ToSingle(dt.Rows[0]["VA%"].ToString());


                        if (c % 2 == 0 || prodcodeid.Length == c - 1)
                            lines.Add("C0510");

                        // lines.Add("391100202350190"+ Prodcode);
                        // lines.Add("1e2206001500045C" + Prodcode);
                        lines.Add("391100101500190" + itemname);
                        lines.Add("291100102000015" + dt.Rows[0]["Purity Name"].ToString() + "");
                        lines.Add("190000100400050 SC:" + stcash.ToString("F3") + "");
                        lines.Add("190000100600050 NW:" + netwt.ToString("f3") + "");
                        lines.Add("190000100800050 SW:" + stwt.ToString("f3") + "");
                        lines.Add("190000101000050 GW:" + Gwt.ToString("f3") + "/ Qty:" + nos.ToString());
                        lines.Add("391100202500190" + dt.Rows[0]["ProdCode"].ToString());
                        lines.Add("1e2106001600075C" + dt.Rows[0]["ProdCode"].ToString());
                        if (DiaNo != 0f || DiaWt != 0f)
                        {
                            lines.Add("190000100200050 DW:" + DiaNo.ToString("f0") + " / " + DiaWt.ToString("f3"));
                        }
                        else
                        {
                            lines.Add("291100100950015V99 " + va.ToString("F2") + "");
                        }


                        if (c % 2 == 0 || prodcodeid.Length == c - 1)
                        {
                            lines.Add("Q001");
                            lines.Add("E");
                        }

                        c++;
                    }
                }

            }
            if (c % 2 == 0)
            {
                lines.Add("Q001");
                lines.Add("E");
            }

            System.IO.File.WriteAllLines(System.IO.Path.GetTempPath().ToString() + "Barcode.txt", lines);

            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();

            System.IO.File.WriteAllLines(System.IO.Path.GetTempPath().ToString() + "Barcode.bat", new string[] { " Copy  " + (char)34 + System.IO.Path.GetTempPath().ToString() + "Barcode.txt " + (char)34 + " LPT1 " });
            myProcess.StartInfo.FileName = System.IO.Path.GetTempPath().ToString() + "Barcode.bat";

            myProcess.Start();

            myProcess.Close();
        }





        #endregion
        //#region Barcode Print project
        //public static void PrintBarcodeproject(long prodcodeid)
        //{
        //    long[] l = new long[1];
        //    l[0] = prodcodeid;
        //    PrintBarcodeproject(l);
        //}
        //public static void PrintBarcodeproject(long[] prodcodeid)
        //{

        //    List<string> lines = new List<string>();
        //    int c = 1;
        //    foreach (long r in prodcodeid)
        //    {
        //        char c1 = '\u0002';

        //        DBConn = new Gramboo.DataController();
        //        if ( project.Forms.STOCK.BarcodeDetails.txt_nos.Text == "")
        //            txt_nos.Text = "1";
        //        for (int j = 0; j <= Convert.ToInt16(txt_nos.Text) - 1; j++)
        //        {
        //            using (DataTable dt = DBConn.GetData(new System.Data.SqlClient.SqlCommand("select * from STK.VProdCodeMaster where prodcodeid=" + r), "Data").Tables[0])
        //            {

        //                if (dt.Rows.Count >= 1)
        //                {

        //                    if (c % 2 == 1)
        //                    {

        //                        lines.Add(c1 + "m");
        //                        lines.Add(c1 + "f760");
        //                        lines.Add(c1 + "L");
        //                        lines.Add("D11");
        //                        lines.Add("H16");

        //                    }


        //                    float Gwt, stwt, netwt, va, stcash, nos, DiaNo, DiaWt;

        //                    string itemname = "";
        //                    // Prodcode=dt.Rows[0]["ProdCode"].ToString();
        //                    Gwt = Convert.ToSingle(dt.Rows[0]["Gwt"].ToString());
        //                    stwt = Convert.ToSingle(dt.Rows[0]["StWt"].ToString());
        //                    netwt = Convert.ToSingle(dt.Rows[0]["NetWt"].ToString());
        //                    stcash = Convert.ToSingle(dt.Rows[0]["StoneCash"].ToString());
        //                    itemname = dt.Rows[0]["Item Name"].ToString();
        //                    nos = Convert.ToSingle(dt.Rows[0]["Nos"].ToString());
        //                    DiaNo = Convert.ToSingle(dt.Rows[0]["DiaNo"].ToString());
        //                    DiaWt = Convert.ToSingle(dt.Rows[0]["DiaWt"].ToString());
        //                    va = Convert.ToSingle(dt.Rows[0]["VA%"].ToString());


        //                    if (c % 2 == 0 || prodcodeid.Length == c - 1)
        //                        lines.Add("C0510");

        //                    // lines.Add("391100202350190"+ Prodcode);
        //                    // lines.Add("1e2206001500045C" + Prodcode);
        //                    lines.Add("391100101500190" + itemname);
        //                    lines.Add("291100102000015" + dt.Rows[0]["Purity Name"].ToString() + "");
        //                    lines.Add("190000100400050 SC:" + stcash.ToString("F3") + "");
        //                    lines.Add("190000100600050 NW:" + netwt.ToString("f3") + "");
        //                    lines.Add("190000100800050 SW:" + stwt.ToString("f3") + "");
        //                    lines.Add("190000101000050 GW:" + Gwt.ToString("f3") + "/ Qty:" + nos.ToString());
        //                    lines.Add("391100202500190" + dt.Rows[0]["ProdCode"].ToString());
        //                    lines.Add("1e2106001600075C" + dt.Rows[0]["ProdCode"].ToString());
        //                    if (DiaNo != 0f || DiaWt != 0f)
        //                    {
        //                        lines.Add("190000100200050 DW:" + DiaNo.ToString("f0") + " / " + DiaWt.ToString("f3"));
        //                    }
        //                    else
        //                    {
        //                        lines.Add("291100100950015V99 " + va.ToString("F2") + "");
        //                    }


        //                    if (c % 2 == 0 || prodcodeid.Length == c - 1)
        //                    {
        //                        lines.Add("Q001");
        //                        lines.Add("E");
        //                    }

        //                    c++;
        //                }
        //            }

        //        }
        //        if (c % 2 == 0)
        //        {
        //            lines.Add("Q001");
        //            lines.Add("E");
        //        }

        //        System.IO.File.WriteAllLines(System.IO.Path.GetTempPath().ToString() + "Barcode.txt", lines);

        //        System.Diagnostics.Process myProcess = new System.Diagnostics.Process();

        //        System.IO.File.WriteAllLines(System.IO.Path.GetTempPath().ToString() + "Barcode.bat", new string[] { " Copy  " + (char)34 + System.IO.Path.GetTempPath().ToString() + "Barcode.txt " + (char)34 + " LPT1 " });
        //        myProcess.StartInfo.FileName = System.IO.Path.GetTempPath().ToString() + "Barcode.bat";

        //        myProcess.Start();

        //        myProcess.Close();
        //    }





        //#endregion
        }
    }
