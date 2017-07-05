using Kingdee.BOS.Core;
using Kingdee.BOS.Core.Bill.PlugIn;
using Kingdee.BOS.Core.DynamicForm.PlugIn;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Orm;
using Kingdee.BOS.Orm.Metadata;
using Kingdee.BOS.Core.Metadata;
using Kingdee.BOS.Orm.DataEntity;
using Kingdee.BOS.Core.Validation;
using Kingdee.BOS.Core.Metadata.FieldElement;
using Kingdee.BOS.Resource;
using Kingdee.BOS.App.Data;
using Kingdee.BOS;
using System.Data;
using Kingdee.BOS.Core.Metadata.EntityElement;
using Kingdee.BOS.Core.SqlBuilder;using Kingdee.BOS.Core;
using Kingdee.BOS.Core.Bill.PlugIn;
using Kingdee.BOS.Core.DynamicForm.PlugIn;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Orm;
using Kingdee.BOS.Orm.Metadata;
using Kingdee.BOS.Core.Metadata;
using Kingdee.BOS.Orm.DataEntity;
using Kingdee.BOS.Core.Validation;
using Kingdee.BOS.Core.Metadata.FieldElement;
using Kingdee.BOS.Resource;
using Kingdee.BOS.App.Data;
using Kingdee.BOS;
using System.Data;
using Kingdee.BOS.Core.Metadata.EntityElement;
using Kingdee.BOS.Core.SqlBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXJT3
{
    [System.ComponentModel.Description("赋值")]
    public class Class11 : AbstractBillPlugIn
    {

        public override void AfterEntryBarItemClick(AfterBarItemClickEventArgs e)
        {
            //为数量字段赋值10，数量字段的唯一标示是FQty，其动态绑定属性是Qty
            base.AfterEntryBarItemClick(e);
            //调用SetValue赋值（推荐）
            if (e.BarItemKey.Equals("De"))
            {
                int rows = this.Model.GetEntryRowCount("FSaleOrderEntry");
                for (int m = 0; m < rows; m++)
                {
                    
                    DynamicObject materobj = this.View.Model.GetValue("FMaterialId",m) as DynamicObject;
                    if (materobj != null)
                    { }
                    else
                    {
                    // this.View.Model.SetValue("FMaterialId2", this.Model.GetValue("FMaterialId"), m);
                        string fassid2, fassid3, fassid4, fassid8, fassid9;
                    DynamicObject F_TP_ASSISTANT2 = this.View.Model.GetValue("F_TP_ASSISTANT2", m) as DynamicObject;
                    if (F_TP_ASSISTANT2 != null) { 
                        string FTAS2 = F_TP_ASSISTANT2["id"].ToString();
                        fassid2 = FTAS2;
                    }
                    else { fassid2 = ""; }
                    
                    DynamicObject F_TP_ASSISTANT3 = this.View.Model.GetValue("F_TP_ASSISTANT3", m) as DynamicObject;
                    if (F_TP_ASSISTANT3 != null)
                    {
                        string FTAS3 = F_TP_ASSISTANT3["id"].ToString();
                        fassid3 = FTAS3;
                    }
                    else { fassid3 = ""; }
                    
                    DynamicObject F_TP_ASSISTANT4 = this.View.Model.GetValue("F_TP_ASSISTANT4", m) as DynamicObject;
                    if (F_TP_ASSISTANT4 != null)
                    {
                        string FTAS4 = F_TP_ASSISTANT4["id"].ToString();
                        fassid4 = FTAS4;
                    }
                    else { fassid4 = ""; }
                    DynamicObject F_TP_ASSISTANT8 = this.View.Model.GetValue("F_TP_ASSISTANT8", m) as DynamicObject;
                    if (F_TP_ASSISTANT8 != null)
                    {
                        string FTAS8 = F_TP_ASSISTANT8["id"].ToString();
                        fassid8 = FTAS8;
                    }
                    else { fassid8 = ""; }
                    DynamicObject F_TP_ASSISTANT9 = this.View.Model.GetValue("F_TP_ASSISTANT9", m) as DynamicObject;
                    if (F_TP_ASSISTANT9 != null)
                    {
                        string FTAS9 = F_TP_ASSISTANT9["id"].ToString();
                        fassid9 = FTAS9;
                    }
                    else { fassid9 = ""; }
                    var F_TP_Decimal = this.View.Model.GetValue("F_TP_Decimal", m);
                    var F_TP_Decimal1 = this.View.Model.GetValue("F_TP_Decimal1", m);
                    var F_TP_Decimal2 = this.View.Model.GetValue("F_TP_Decimal2", m);
                    var F_TP_Decimal3 = this.View.Model.GetValue("F_TP_Decimal3", m);
                    var F_TP_Text = this.View.Model.GetValue("F_TP_Text", m);
                    string sql = string.Format("select FMATERIALID from T_BD_MATERIAL where  F_TP_ASSISTANT2  = '{0}' and F_TP_ASSISTANT3  = '{1}'  and F_TP_ASSISTANT4  = '{2}'   and F_TP_ASSISTANT8  = '{3}'  and F_TP_ASSISTANT9  = '{4}'   and F_TP_Decimal   = (case {5}   when '0' then F_TP_Decimal  else {5}  end) and F_TP_Decimal1  = (case {6}  when '0' then F_TP_Decimal1 else {6} end)   and F_TP_Decimal2  = (case {7}  when '0' then F_TP_Decimal2 else {7} end)	 and F_TP_Decimal3  like (case {8}  when '0' then F_TP_Decimal3 else {8} end)",
                       fassid2,fassid3,fassid4,fassid8,fassid9, F_TP_Decimal, F_TP_Decimal1, F_TP_Decimal2, F_TP_Decimal3);
                    //DBUtils.ExecuteDynamicObject(this.Context, sql);
                    DataSet res = Kingdee.BOS.ServiceHelper.DBServiceHelper.ExecuteDataSet(this.Context, sql);
                    if (res.Tables[0].Rows.Count ==1)
                    {
                        int F_TP_Text2 = Convert.ToInt32(res.Tables[0].Rows[0]["FMATERIALID"].ToString());
                        //this.View.Model.SetValue("FMaterialId", Convert.ToInt64(F_TP_Text2), m);
                        this.View.Model.SetValue("F_TP_Base", Convert.ToInt64(F_TP_Text2), m);
                        this.View.InvokeFieldUpdateService("F_TP_Base", m);
                    }
                   // this.View.Model.SetValue("FMaterialId", Convert.ToInt64(F_TP_Text), m);
                    }
                    
                    
                }
                this.View.UpdateView("FSaleOrderEntry");

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FXJT3
{
    [System.ComponentModel.Description("赋值")]
    public class Class11 : AbstractBillPlugIn
    {

        public override void AfterEntryBarItemClick(AfterBarItemClickEventArgs e)
        {
            //为数量字段赋值10，数量字段的唯一标示是FQty，其动态绑定属性是Qty
            base.AfterEntryBarItemClick(e);
            //调用SetValue赋值（推荐）
            if (e.BarItemKey.Equals("De"))
            {
                int rows = this.Model.GetEntryRowCount("FSaleOrderEntry");
                for (int m = 0; m < rows; m++)
                {
                    
                    DynamicObject materobj = this.View.Model.GetValue("FMaterialId") as DynamicObject;
                    if (materobj != null)
                    { }
                    else
                    {
                    // this.View.Model.SetValue("FMaterialId2", this.Model.GetValue("FMaterialId"), m);
                    var F_TP_ASSISTANT2 = this.View.Model.GetValue("F_TP_ASSISTANT2", m);
                    var F_TP_ASSISTANT3 = this.View.Model.GetValue("F_TP_ASSISTANT3", m);
                    var F_TP_ASSISTANT4 = this.View.Model.GetValue("F_TP_ASSISTANT4", m);
                    var F_TP_ASSISTANT8 = this.View.Model.GetValue("F_TP_ASSISTANT8", m);
                    var F_TP_ASSISTANT9 = this.View.Model.GetValue("F_TP_ASSISTANT9", m);
                    var F_TP_Decimal = this.View.Model.GetValue("F_TP_Decimal", m);
                    var F_TP_Decimal1 = this.View.Model.GetValue("F_TP_Decimal1", m);
                    var F_TP_Decimal2 = this.View.Model.GetValue("F_TP_Decimal2", m);
                    var F_TP_Decimal3 = this.View.Model.GetValue("F_TP_Decimal3", m);
                    var F_TP_Text = this.View.Model.GetValue("F_TP_Text", m);
                    string sql = string.Format("select fnumber from T_BD_MATERIAL where  F_TP_ASSISTANT2  like {0} and F_TP_ASSISTANT3  like {1}  and F_TP_ASSISTANT4  like {2}   and F_TP_ASSISTANT8  like {3} and F_TP_ASSISTANT9  like {4}   and F_TP_Decimal   = (case {5}   when '0' then F_TP_Decimal  else {5}  end) and F_TP_Decimal1  = (case {6}  when '0' then F_TP_Decimal1 else {6} end)   and F_TP_Decimal2  = (case {7}  when '0' then F_TP_Decimal2 else {7} end)	 and F_TP_Decimal3  like (case {8}  when '0' then F_TP_Decimal3 else {8} end)",
                        F_TP_ASSISTANT2, F_TP_ASSISTANT3, F_TP_ASSISTANT4,F_TP_ASSISTANT8, F_TP_ASSISTANT9, F_TP_Decimal, F_TP_Decimal1, F_TP_Decimal2, F_TP_Decimal3);
                    //DBUtils.ExecuteDynamicObject(this.Context, sql);
                    DataSet res = Kingdee.BOS.ServiceHelper.DBServiceHelper.ExecuteDataSet(this.Context, sql);
                    if (res.Tables[0].Rows.Count ==1)
                    {
                        int F_TP_Text2 = Convert.ToInt32(res.Tables[0].Rows[0]["FMATERIALID"].ToString());
                        this.View.Model.SetValue("F_TP_Base", Convert.ToInt64(F_TP_Text2), m);
                    }
                    this.View.Model.SetValue("FMaterialId", Convert.ToInt64(F_TP_Text), m);
                    }
                    
                    
                }
                this.View.UpdateView("FSaleOrderEntry");

            }
        }
    }
}
