using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InstrumentProductScope
{
    public partial class InstrumentProductScopeControl : System.Web.UI.UserControl
    {
        public Repeater InstrumentRepeater { get { return rptInstruments; } }
        public List<Instument2ProductScope> Instruments
        {
            get { return ViewState["Instruments"] as List<Instument2ProductScope>; }
            set
            {
                ViewState["Instruments"] = value;
                BindData();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initially bind the data if this is the first load
                BindData();
            }
        }

        private void BindData()
        {
            if (Instruments != null)
            {
                rptInstruments.DataSource = Instruments;
                rptInstruments.DataBind();
            }
        }
    }
}