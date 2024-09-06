using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InstrumentProductScope
{
    public partial class _Default : Page
    {
        protected override void Render(HtmlTextWriter writer)
        {
            foreach (RepeaterItem item in InstrumentProductScopeControl1.InstrumentRepeater.Items)
            {
                var lstOriginalProductScope = item.FindControl("lstOriginalProductScope") as ListBox;
                var lstProductScope = item.FindControl("lstProductScope") as ListBox;
                var hfInstrumentId = item.FindControl("hfInstrumentId") as HiddenField;

                if (hfInstrumentId != null)
                {
                    // Register hidden field values for event validation
                    Page.ClientScript.RegisterForEventValidation(hfInstrumentId.UniqueID, hfInstrumentId.Value);
                }

                if (lstOriginalProductScope != null)
                {
                    foreach (ListItem li in lstOriginalProductScope.Items)
                    {
                        Page.ClientScript.RegisterForEventValidation(lstOriginalProductScope.UniqueID, li.Value);
                    }
                }

                if (lstProductScope != null)
                {
                    foreach (ListItem li in lstProductScope.Items)
                    {
                        Page.ClientScript.RegisterForEventValidation(lstProductScope.UniqueID, li.Value);
                    }
                }
            }

            base.Render(writer);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the Instruments list
                var instruments = GetInstruments();
                InstrumentProductScopeControl1.Instruments = instruments;
                
            }
        }

        private List<Instument2ProductScope> GetInstruments()
        {
            return new List<Instument2ProductScope>
            {
                new Instument2ProductScope
                {
                    InstrumentId = 1, 
                    InsutrementName = "Derivatives",
                    OriginalProductScopeList = new List<ProductScope>
                    {
                        new ProductScope { ProductScopeId = 1, ProductScopeName = "PTAX-FI"},
                        new ProductScope { ProductScopeId = 2, ProductScopeName = "Origin-FI"},
                        new ProductScope { ProductScopeId = 3, ProductScopeName = "Origin-SWAP"}
                    },
                    ProductScopeList = new List<ProductScope>()
                },
                 new Instument2ProductScope
                {
                    InstrumentId = 2,
                    InsutrementName = "Fixed Income",
                    OriginalProductScopeList = new List<ProductScope>
                    {
                        new ProductScope { ProductScopeId = 1, ProductScopeName = "PTAX-FI"},
                        new ProductScope { ProductScopeId = 2, ProductScopeName = "Origin-FI"},
                        
                    },
                    ProductScopeList = new List<ProductScope>()
                    {
                        new ProductScope { ProductScopeId = 3, ProductScopeName = "Origin-SWAP"}
                    }
                },
            };
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            // This method is required to ensure that the controls are rendered properly.
            // If the page is performing event validation, this ensures that the controls
            // involved in postbacks are registered correctly.
        }

        //protected void btnSave_Click()
        //{
        //    foreach (RepeaterItem item in rptInstruments.Items)
        //    {
        //        var lstOriginalProductScope = item.FindControl("lstOriginalProductScope") as ListBox;
        //        var lstProductScope = item.FindControl("lstProductScope") as ListBox;

        //        Retrieve InstrumentId from some hidden field or use the index
        //        int instrumentId = Instruments[item.ItemIndex].InstrumentId;

        //        Update the ProductScopeList in the Instruments list
        //       Instruments[item.ItemIndex].ProductScopeList = new List<ProductScope>();

        //        foreach (ListItem listItem in lstProductScope.Items)
        //        {
        //            Instruments[item.ItemIndex].ProductScopeList.Add(new ProductScope
        //            {
        //                ProductScopeId = int.Parse(listItem.Value),
        //                ProductScopeName = listItem.Text
        //            });
        //        }
        //    }
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var updatedInstruments = new List<Instument2ProductScope>();

            foreach (RepeaterItem item in InstrumentProductScopeControl1.InstrumentRepeater.Items)
            {
                var hfInstrumentId = item.FindControl("hfInstrumentId") as HiddenField;
                var lstOriginalProductScope = item.FindControl("lstOriginalProductScope") as ListBox;
                var lstProductScope = item.FindControl("lstProductScope") as ListBox;

                if (hfInstrumentId != null && lstOriginalProductScope != null && lstProductScope != null)
                {
                    // Register the ListBox controls for event validation
                    Page.ClientScript.RegisterForEventValidation(lstOriginalProductScope.UniqueID);
                    Page.ClientScript.RegisterForEventValidation(lstProductScope.UniqueID);

                    var serializer = new JavaScriptSerializer();
                    var originalProductScopeList = lstOriginalProductScope.Items.Cast<ListItem>()
                                            .Select(i => new ProductScope
                                            {
                                                ProductScopeId = Convert.ToInt32(i.Value),
                                                ProductScopeName = i.Text
                                            }).ToList();

                    //var productScopeList = serializer.Deserialize<List<ProductScope>>(hfProductScopeList.Value);

                    var productScopeList = lstProductScope.Items.Cast<ListItem>()
                                            .Select(i => new ProductScope
                                            {
                                                ProductScopeId = Convert.ToInt32(i.Value),
                                                ProductScopeName = i.Text
                                            }).ToList();

                    var updatedInstrument = new Instument2ProductScope
                    {
                        InstrumentId = Convert.ToInt32(hfInstrumentId.Value),
                        InsutrementName = (item.FindControl("lblInstrumentName") as Label)?.Text,
                        OriginalProductScopeList = originalProductScopeList,
                        ProductScopeList = productScopeList
                    };

                    updatedInstruments.Add(updatedInstrument);
                }
            }

            SaveInstruments(updatedInstruments);
        }



        private void SaveInstruments(List<Instument2ProductScope> instruments)
        {
            // Implement the saving logic here
            // This could involve saving the data back to a database
        }


    }
}