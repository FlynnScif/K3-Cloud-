using Kingdee.BOS.Core.Bill.PlugIn;
using Kingdee.BOS.Core.DynamicForm.PlugIn.Args;
using Kingdee.BOS.Core.Metadata.FieldElement;
using Kingdee.BOS.Core;
using Kingdee.BOS.Core.Metadata;
using Kingdee.BOS.Core.Metadata.EntityElement;
using Kingdee.BOS.Core.SqlBuilder;
using Kingdee.BOS.Orm.DataEntity;
using Kingdee.BOS.ServiceHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace FXJT.DATACHANGE
{
    [System.ComponentModel.Description("DAtachange事件")]
    public class Class11 : AbstractBillPlugIn
    {
        public override void DataChanged(DataChangedEventArgs e)
        {
            base.DataChanged(e);
            switch (e.Field.Key.ToUpper())
            {
                case "FMATERIALID"://输入FMATERIALID的时候
                    //this.View.Model.SetValue("FMaterialId2", this.View.Model.GetValue("FMATERIALID"), e.Row);
                    this.View.Model.SetValue("FMaterialId2", this.View.Model.GetValue("F_TP_DECIMAL1"), e.Row);
                    break;
                case "F_TP_DECIMAL"://输入ET的时候
                    DynamicObject assetorgid = this.View.Model.GetValue("FMATERIALID") as DynamicObject;
                    DynamicObject materobj = this.View.Model.GetValue("FMaterialId") as DynamicObject;
                    if (assetorgid != null)
                    {
                        long materid = Convert.ToInt64(assetorgid["id"]);
                        this.View.Model.SetValue("F_TP_Text", materid, e.Row);
                        this.View.Model.SetValue("F_TP_Base", materid, e.Row);

                    }


                    // string strOrgNumber = assetorgid["id"];
                    
                    break;
                default:
                    break;

            }
        }


    }
}
