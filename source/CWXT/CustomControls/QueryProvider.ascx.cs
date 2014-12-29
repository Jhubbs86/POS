using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI;
using System.Text;

using Wicresoft.BusinessObject;

namespace CWXT.CustomControls
{
    /// <summary>
    ///		Summary description for QueryProvider.
    /// </summary>
    public partial class QueryProvider : System.Web.UI.UserControl
    {
        /// <summary>
        /// Create the QueryProvider Control in the queryHolder
        /// </summary>
        protected System.Web.UI.WebControls.PlaceHolder queryHolder;


        /// <summary>
        /// Present the QueryProvider Control with a BusinessObjectView object
        /// </summary>
        public BusinessObjectView BusinessObjectView;


        /// <summary>
        /// Indicates the window which opens the current window
        /// </summary>
        protected string openerId;


        protected override void OnInit(EventArgs e)
        {
            string pageid = Request.QueryString[Enums.Constants.PageID];
            openerId = (pageid == null) ? string.Empty : pageid;
            base.OnInit(e);
        }


        /// <summary>
        /// Initialize the QueryProvider Control with a specified BusinessObjectView
        /// </summary>
        /// <param name="bov">BusinessObjectView object</param>
        public void InitQueryProvider(BusinessObjectView bov)
        {
            if (bov == null)
                throw new NullReferenceException("QueryProvider need a BusinessObjectView to work correctly.");

            this.BusinessObjectView = bov;
            this.queryHolder.Controls.Add(this.GenerateQueryContainer());
            this.RecoverQueryStatus();
        }


        /// <summary>
        /// Initialize the QueryProvider Control with a specified BusinessObjectView Name
        /// </summary>
        /// <param name="businessObjectViewName"></param>
        public void InitQueryProvider(string businessObjectViewName)
        {
            BusinessView.Common common = new BusinessView.Common();
            this.InitQueryProvider(common.GetBusinessObjectViewFromName(businessObjectViewName));
        }


        /// <summary>
        /// Generate filter according to each query item
        /// </summary>
        public BusinessFilter GetBusinessFilter()
        {
            string filterDescription;
            return this.GetBusinessFilter(out filterDescription);
        }


        /// <summary>
        /// Generate filter according to each query item(along with filter description)
        /// </summary>
        public BusinessFilter GetBusinessFilter(out string filterDescription)
        {
            BusinessFilter queryFilter = new BusinessFilter(this.BusinessObjectView.BusinessObjectName);
            HtmlTable queryTable = this.queryHolder.FindControl("__queryTable") as HtmlTable;
            AndOr filterJunction = GetFilterJunction(queryTable);
            StringBuilder queryDesc = new StringBuilder();

            // queryTable的最后一行是queryType（满足全部、满足任一）
            for (int i = 0; i < queryTable.Rows.Count - 1; i++)
            {
                HtmlTableRow queryItem = queryTable.FindControl("__queryitem_" + i.ToString()) as HtmlTableRow;
                HtmlInputCheckBox checkbox = queryTable.FindControl("__checkbox_" + i.ToString()) as HtmlInputCheckBox;

                if (checkbox.Checked)
                {
                    LiteralControl desc = queryTable.FindControl("__desc_" + i.ToString()) as LiteralControl;
                    ViewItemDisplayType itemType = (ViewItemDisplayType)int.Parse(queryItem.Attributes["displayType"]);

                    if (itemType == ViewItemDisplayType.CheckBox)
                    {
                        // Filter
                        HtmlInputCheckBox boolCtl = queryTable.FindControl("__bool_" + i.ToString()) as HtmlInputCheckBox;

                        if (queryItem.Attributes["isVirtual"] != "true")
                            queryFilter.AddFilterItem(queryItem.Attributes["fieldName"],
                                Convert.ToInt32(boolCtl.Checked).ToString(), Operation.Equal, FilterType.NumberType, queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);
                        else
                            queryFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + "=" + Convert.ToInt32(boolCtl.Checked).ToString(), queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);

                        // Desc
                        queryDesc.AppendFormat("{0}：{1}.", desc.Text, boolCtl.Checked);
                    }
                    else if (itemType == ViewItemDisplayType.Literal)
                    {
                        // Filter
                        HtmlInputText textbox = queryTable.FindControl("__textbox_" + i.ToString()) as HtmlInputText;
                        if (textbox.Value != string.Empty)
                        {
                            GlobalFacade.PageContext pgCtx = GlobalFacade.SystemContext.GetContext().GetPageContext(this.openerId);
                            pgCtx.Parms.Clear();
                            RadioButtonList FuzzyEnquiry = queryTable.FindControl("__Fuzzytxt_" + i.ToString()) as RadioButtonList;
                            if (queryItem.Attributes["isVirtual"] != "true")
                            {
                                if (FuzzyEnquiry != null)
                                {
                                    if (FuzzyEnquiry.SelectedIndex == 0)
                                        queryFilter.AddFilterItem(queryItem.Attributes["fieldName"], textbox.Value.Replace("'", "''"), Operation.Like, FilterType.StringType, queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);
                                    else
                                        queryFilter.AddFilterItem(queryItem.Attributes["fieldName"], textbox.Value.Replace("'", "''"), Operation.Equal, FilterType.StringType, queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);
                                }
                                else
                                    queryFilter.AddFilterItem(queryItem.Attributes["fieldName"], textbox.Value.Replace("'", "''"), Operation.Like, FilterType.StringType, queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);
                            }
                            else
                            {
                                if (FuzzyEnquiry != null)
                                {
                                    if (FuzzyEnquiry.SelectedIndex == 0)
                                        queryFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + " LIKE '%" + textbox.Value.Replace("'", "''") + "%'", queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);
                                    else
                                        queryFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + " = '" + textbox.Value.Replace("'", "''") + "'", queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);
                                }
                                else
                                    queryFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + " LIKE '%" + textbox.Value.Replace("'", "''") + "%'", queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);
                            }

                            //							if(queryItem.Attributes["isVirtual"] != "true")
                            //								queryFilter.AddFilterItem(queryItem.Attributes["fieldName"], 
                            //									textbox.Value.Replace("'", "''"), Operation.Like, FilterType.StringType, filterJunction);	// 2007-4-5, Tony, 将单引号替换成两个单引号，避免查询时报错
                            //							else
                            //							{
                            //								/* Andy Modify 2008-07-30 只有Client的Mobile、TelePhone、ChineseName、EnglishName用前匹配模糊查询 */
                            //								if(this.BusinessObjectView.BusinessObjectName.ToLower() == "client")
                            //								{
                            //									if( queryItem.Attributes["fieldName"].ToLower().Trim().IndexOf("mobile") == -1 && 
                            //										queryItem.Attributes["fieldName"].ToLower().Trim().IndexOf("telephone") == -1 && 
                            //										queryItem.Attributes["fieldName"].ToLower().Trim().IndexOf("chinesename") == -1 && 
                            //										queryItem.Attributes["fieldName"].ToLower().Trim().IndexOf("englishname") == -1)
                            //									{
                            //										queryFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + " LIKE '%" + textbox.Value.Replace("'", "''") + "%'", filterJunction);// 2007-4-5, Tony, 将单引号替换成两个单引号，避免查询时报错
                            //									}
                            //									else
                            //										queryFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + " LIKE '" + textbox.Value.Replace("'", "''") + "%'", filterJunction);	
                            //								}
                            //								else
                            //									queryFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + " LIKE '%" + textbox.Value.Replace("'", "''") + "%'", filterJunction);// 2007-4-5, Tony, 将单引号替换成两个单引号，避免查询时报错
                            //							}

                            // Desc
                            queryDesc.AppendFormat("{0}：{1}.", desc.Text, textbox.Value);
                        }
                    }
                    else if (itemType == ViewItemDisplayType.DateTime)
                    {
                        // Filter
                        HtmlInputText beginTime = queryTable.FindControl("__beginTime_" + i.ToString()) as HtmlInputText;
                        HtmlInputText endTime = queryTable.FindControl("__endTime_" + i.ToString()) as HtmlInputText;
                        BusinessFilter subFilter = new BusinessFilter(this.BusinessObjectView.BusinessObjectName);

                        if (queryItem.Attributes["isVirtual"] != "true")
                        {
                            if (beginTime.Value != string.Empty)
                                subFilter.AddFilterItem(queryItem.Attributes["fieldName"],
                                    beginTime.Value, Operation.NotSmaller, FilterType.StringType, AndOr.AND);


                            if (endTime.Value != string.Empty)
                                subFilter.AddFilterItem(queryItem.Attributes["fieldName"],
                                    endTime.Value, Operation.Smaller, FilterType.StringType, AndOr.AND);
                            //endTime.Value, Operation.NotLarger, FilterType.StringType, AndOr.AND); 
                        }
                        else
                        {
                            if (beginTime.Value != string.Empty)
                                subFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + ">= '" + beginTime.Value + "'", AndOr.AND);

                            if (endTime.Value != string.Empty)
                                subFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + "< '" + endTime.Value + "'", AndOr.AND);
                            //subFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + "<= '" + endTime.Value + "'", AndOr.AND); 
                        }
                        queryFilter.AddFilter(subFilter, queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);

                        if (beginTime.Value != string.Empty || endTime.Value != string.Empty)
                        {
                            // Desc
                            queryDesc.AppendFormat("{0}：从{1}至{2}.", desc.Text, beginTime.Value, endTime.Value);
                        }
                    }
                    else if (itemType == ViewItemDisplayType.SingleObject)
                    {
                        // Filter
                        GridPicker ucGridPicker = queryTable.FindControl("__ucGridPicker_" + i.ToString()) as GridPicker;
                        if (ucGridPicker.SelectedValue != string.Empty)
                        {
                            if (queryItem.Attributes["isVirtual"] != "true")
                                queryFilter.AddFilterItem(queryItem.Attributes["fieldName"], ucGridPicker.SelectedValue, Operation.Equal, FilterType.NumberType, queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);
                            else
                                queryFilter.AddCustomerFilter(queryItem.Attributes["fieldName"] + " = " + ucGridPicker.SelectedValue, queryFilter.Filter != string.Empty ? filterJunction : AndOr.AND);
                            // Desc
                            queryDesc.AppendFormat("{0}：{1}.", desc.Text, ucGridPicker.SelectedText);
                        }
                    }
                }
            }

            if (queryDesc.Length != 0)
                filterDescription = queryDesc.AppendFormat("（{0}）", (filterJunction == AndOr.AND) ? "满足全部条件" : "满足任一条件").ToString();
            else
                filterDescription = string.Empty;

            BusinessFilter parentQueryFilter = new BusinessFilter(this.BusinessObjectView.BusinessObjectName);
            parentQueryFilter.AddCustomerFilter("1=1", AndOr.AND);
            parentQueryFilter.AddFilter(queryFilter, AndOr.AND);

            this.SaveQueryStatus();
            return parentQueryFilter;
        }


        public void ClearQueryStatus()
        {
            GlobalFacade.PageContext pgCtx = GlobalFacade.SystemContext.GetContext().GetPageContext(this.openerId);
            pgCtx.Parms.Clear();
            GlobalFacade.SystemContext.GetContext().SavePageContext(this.openerId, pgCtx);
        }


        private bool IsNeedQueryStatus()
        {
            // 只记录第一层的状态
            return this.Request.QueryString["__level"] == "1";
        }


        private void RecoverQueryStatus()
        {
            if (!this.IsNeedQueryStatus())
                return;

            //Response.Write(this.openerId);
            GlobalFacade.PageContext pgCtx = GlobalFacade.SystemContext.GetContext().GetPageContext(this.openerId);
            if (pgCtx.Parms.Count == 0)
                return;

            HtmlTable queryTable = this.queryHolder.FindControl("__queryTable") as HtmlTable;
            RadioButtonList queryType = queryTable.FindControl("__queryType") as RadioButtonList;

            queryType.SelectedIndex = Convert.ToInt32(pgCtx.Parms[queryType.UniqueID]);

            // queryTable的最后一行是queryType（满足全部、满足任一）
            for (int i = 0; i < queryTable.Rows.Count - 1; i++)
            {
                HtmlTableRow queryItem = queryTable.FindControl("__queryitem_" + i.ToString()) as HtmlTableRow;
                HtmlInputCheckBox checkbox = queryTable.FindControl("__checkbox_" + i.ToString()) as HtmlInputCheckBox;
                LiteralControl desc = queryTable.FindControl("__desc_" + i.ToString()) as LiteralControl;

                HtmlInputCheckBox boolCtl = queryTable.FindControl("__bool_" + i.ToString()) as HtmlInputCheckBox;
                HtmlInputText textbox = queryTable.FindControl("__textbox_" + i.ToString()) as HtmlInputText;
                HtmlInputText beginTime = queryTable.FindControl("__beginTime_" + i.ToString()) as HtmlInputText;
                HtmlInputText endTime = queryTable.FindControl("__endTime_" + i.ToString()) as HtmlInputText;
                GridPicker ucGridPicker = queryTable.FindControl("__ucGridPicker_" + i.ToString()) as GridPicker;

                //ViewItemDisplayType itemType = (ViewItemDisplayType)int.Parse(queryItem.Attributes["displayType"]);

                if (pgCtx.Parms[checkbox.UniqueID] != null)
                    checkbox.Checked = Convert.ToBoolean(pgCtx.Parms[checkbox.UniqueID]);

                if (boolCtl != null && pgCtx.Parms[boolCtl.UniqueID] != null)
                {
                    boolCtl.Checked = Convert.ToBoolean(pgCtx.Parms[boolCtl.UniqueID]);
                    continue;
                }

                if (textbox != null && pgCtx.Parms[textbox.UniqueID] != null)
                {
                    textbox.Value = pgCtx.Parms[textbox.UniqueID].ToString();

                    RadioButtonList FuzzyEnquiry = queryTable.FindControl("__Fuzzytxt_" + i.ToString()) as RadioButtonList;
                    if (FuzzyEnquiry != null && pgCtx.Parms[FuzzyEnquiry.UniqueID] != null)
                        FuzzyEnquiry.SelectedIndex = Convert.ToInt32(pgCtx.Parms[FuzzyEnquiry.UniqueID]);
                    continue;
                }

                if (beginTime != null && endTime != null && pgCtx.Parms[beginTime.UniqueID] != null && pgCtx.Parms[endTime.UniqueID] != null)
                {
                    beginTime.Value = pgCtx.Parms[beginTime.UniqueID].ToString();
                    endTime.Value = pgCtx.Parms[endTime.UniqueID].ToString();
                    continue;
                }

                if (ucGridPicker != null && pgCtx.Parms[ucGridPicker.UniqueID] != null)
                {
                    if (pgCtx.Parms[ucGridPicker.UniqueID].ToString() != string.Empty)
                        ucGridPicker.SelectedValue = pgCtx.Parms[ucGridPicker.UniqueID].ToString();
                    continue;
                }
            }
        }


        private void SaveQueryStatus()
        {
            if (!this.IsNeedQueryStatus())
                return;

            GlobalFacade.PageContext pgCtx = GlobalFacade.SystemContext.GetContext().GetPageContext(this.openerId);

            HtmlTable queryTable = this.queryHolder.FindControl("__queryTable") as HtmlTable;
            RadioButtonList queryType = queryTable.FindControl("__queryType") as RadioButtonList;

            pgCtx.Parms[queryType.UniqueID] = queryType.SelectedIndex;

            // queryTable的最后一行是queryType（满足全部、满足任一）
            for (int i = 0; i < queryTable.Rows.Count - 1; i++)
            {
                HtmlTableRow queryItem = queryTable.FindControl("__queryitem_" + i.ToString()) as HtmlTableRow;
                HtmlInputCheckBox checkbox = queryTable.FindControl("__checkbox_" + i.ToString()) as HtmlInputCheckBox;
                LiteralControl desc = queryTable.FindControl("__desc_" + i.ToString()) as LiteralControl;

                HtmlInputCheckBox boolCtl = queryTable.FindControl("__bool_" + i.ToString()) as HtmlInputCheckBox;
                HtmlInputText textbox = queryTable.FindControl("__textbox_" + i.ToString()) as HtmlInputText;
                HtmlInputText beginTime = queryTable.FindControl("__beginTime_" + i.ToString()) as HtmlInputText;
                HtmlInputText endTime = queryTable.FindControl("__endTime_" + i.ToString()) as HtmlInputText;
                GridPicker ucGridPicker = queryTable.FindControl("__ucGridPicker_" + i.ToString()) as GridPicker;

                //ViewItemDisplayType itemType = (ViewItemDisplayType)int.Parse(queryItem.Attributes["displayType"]);

                pgCtx.Parms[checkbox.UniqueID] = checkbox.Checked;

                if (boolCtl != null)
                {
                    pgCtx.Parms[boolCtl.UniqueID] = boolCtl.Checked;
                    continue;
                }

                if (textbox != null)
                {
                    pgCtx.Parms[textbox.UniqueID] = textbox.Value;

                    RadioButtonList FuzzyEnquiry = queryTable.FindControl("__Fuzzytxt_" + i.ToString()) as RadioButtonList;
                    if (FuzzyEnquiry != null)
                        pgCtx.Parms[FuzzyEnquiry.UniqueID] = Convert.ToInt32(FuzzyEnquiry.SelectedIndex);
                    continue;
                }

                if (beginTime != null && endTime != null)
                {
                    pgCtx.Parms[beginTime.UniqueID] = beginTime.Value;
                    pgCtx.Parms[endTime.UniqueID] = endTime.Value;
                    continue;
                }

                if (ucGridPicker != null)
                {
                    pgCtx.Parms[ucGridPicker.UniqueID] = ucGridPicker.SelectedValue;
                    continue;
                }
            }
            GlobalFacade.SystemContext.GetContext().SavePageContext(this.openerId, pgCtx);
        }


        private HtmlContainerControl GenerateQueryContainer()
        {
            HtmlTable queryTable = new HtmlTable();
            queryTable.ID = "__queryTable";
            queryTable.CellPadding = 3;
            queryTable.CellSpacing = 0;
            queryTable.Attributes.Add("class", "detailInfo");

            // 生成查询项
            ViewItemCollection queryItems = GetQueryItemCollection();
            for (int i = 0; i < queryItems.Count; i++)
            {
                queryTable.Rows.Add(GenerateQueryItem(queryItems[i], i));
            }

            // 生成查询类型（AND OR）
            queryTable.Rows.Add(GenerateQueryTypeBar());

            return queryTable;
        }


        private HtmlTableRow GenerateQueryTypeBar()
        {
            HtmlTableRow queryTypeRow = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();
            cell.ColSpan = 3;

            RadioButtonList queryType = new RadioButtonList();
            queryType.ID = "__queryType";
            queryType.Font.Size = FontUnit.Point(9);
            queryType.RepeatDirection = RepeatDirection.Horizontal;
            queryType.Items.Add(new ListItem("满足全部条件"));
            queryType.Items.Add(new ListItem("满足任一条件"));
            queryType.SelectedIndex = 0;

            cell.Controls.Add(queryType);
            queryTypeRow.Cells.Add(cell);

            return queryTypeRow;
        }

        private void CreateTextbox(HtmlTableCell cell, int rowIndex)
        {
            HtmlInputText textBox = new HtmlInputText();
            textBox.ID = "__textbox_" + rowIndex.ToString();
            textBox.Attributes.Add("onclick", "QueryItemClicked()");
            textBox.Style.Add("width", "45%");
            cell.Controls.Add(textBox);
        }

        private void CreateFuzzyEnquiry(HtmlTableCell cell, int rowIndex, ViewItem vi)
        {
            RadioButtonList R = new RadioButtonList();
            R.Items.Add(new ListItem("模糊查询"));
            R.Items.Add(new ListItem("精确查询"));
            R.ID = "__Fuzzytxt_" + rowIndex.ToString();
            R.SelectedIndex = (vi.FuzzyEnquiry == true) ? 0 : 1;
            R.RepeatDirection = RepeatDirection.Horizontal;
            R.RepeatLayout = RepeatLayout.Flow;
            R.Attributes.Add("onclick", "QueryItemClicked()");
            cell.Controls.Add(R);
        }

        private void CreateCheckbox(HtmlTableCell cell, int rowIndex)
        {
            HtmlInputCheckBox boolCtl = new HtmlInputCheckBox();
            boolCtl.ID = "__bool_" + rowIndex.ToString();
            boolCtl.Attributes.Add("onclick", "QueryItemClicked();");
            cell.Controls.Add(boolCtl);
        }

        private void CreateDatePeriodPicker(HtmlTableCell cell, int rowIndex)
        {
            HtmlInputText beginTime = new HtmlInputText();
            HtmlInputText endTime = new HtmlInputText();

            beginTime.ID = "__beginTime_" + rowIndex.ToString();
            endTime.ID = "__endTime_" + rowIndex.ToString();

            beginTime.Attributes.Add("onfocus", "QueryItemClicked();calendar();");
            endTime.Attributes.Add("onfocus", "QueryItemClicked();calendar();");

            Label lblBeginTime = new Label();
            lblBeginTime.Text = "起始时间：";

            Label lblSeperator = new Label();
            lblSeperator.Text = "&nbsp;&nbsp;&nbsp;&nbsp;";

            Label lblEndTime = new Label();
            lblEndTime.Text = "结束时间：";

            cell.Controls.Add(lblBeginTime);
            cell.Controls.Add(beginTime);
            cell.Controls.Add(lblSeperator);
            cell.Controls.Add(lblEndTime);
            cell.Controls.Add(endTime);
        }

        private void CreateGridPicker(HtmlTableCell cell, int rowIndex, string defaultView)
        {
            GridPicker ucGridPicker = this.LoadControl("GridPicker.ascx") as GridPicker;
            ucGridPicker.BusinessObjectViewName = defaultView;
            ucGridPicker.ID = "__ucGridPicker_" + rowIndex.ToString();
            ucGridPicker.Width = "45%";
            cell.Controls.Add(ucGridPicker);
            cell.Attributes.Add("onclick", "QueryItemClicked();");
        }

        private HtmlTableRow GenerateQueryItem(ViewItem vi, int rowIndex)
        {
            HtmlTableRow queryItem = new HtmlTableRow();
            HtmlTableCell checkBoxCell = new HtmlTableCell();
            HtmlTableCell descCell = new HtmlTableCell();
            HtmlTableCell itemCell = new HtmlTableCell();

            checkBoxCell.Width = "1%";
            descCell.Width = "18%";
            queryItem.ID = "__queryitem_" + rowIndex.ToString();
            queryItem.Cells.Add(checkBoxCell);
            queryItem.Cells.Add(descCell);
            queryItem.Cells.Add(itemCell);
            queryItem.Attributes.Add("fieldName", vi.FieldName);
            queryItem.Attributes.Add("displayType", Convert.ToString((int)vi.DisplayType));
            queryItem.Attributes.Add("isVirtual", vi.IsVirtual.ToString().ToLower());

            HtmlInputCheckBox checkBox = new HtmlInputCheckBox();
            checkBox.ID = "__checkbox_" + rowIndex.ToString();
            checkBoxCell.Controls.Add(checkBox);

            LiteralControl literal = new LiteralControl(vi.DisplayName);
            literal.ID = "__desc_" + rowIndex.ToString();
            descCell.Controls.Add(literal);
            descCell.Attributes.Add("onclick", "QueryItemDescClicked()");
            descCell.Attributes.Add("nowrap", "true");

            if (vi.DisplayType == ViewItemDisplayType.Literal)
            {
                CreateTextbox(itemCell, rowIndex);

                if (vi.IsVirtual == true)
                {
                    if (vi.FieldType == "StringField")
                        CreateFuzzyEnquiry(itemCell, rowIndex, vi);
                }
                else
                {
                    if (this.BusinessObjectView.BusinessObject.GetType().GetField(vi.FieldName).FieldType.Name == "StringField")
                        CreateFuzzyEnquiry(itemCell, rowIndex, vi);
                }
            }
            else if (vi.DisplayType == ViewItemDisplayType.DateTime)
            {
                CreateDatePeriodPicker(itemCell, rowIndex);
            }
            else if (vi.DisplayType == ViewItemDisplayType.CheckBox)
            {
                CreateCheckbox(itemCell, rowIndex);
            }
            else if (vi.DisplayType == ViewItemDisplayType.SingleObject)
            {
                CreateGridPicker(itemCell, rowIndex, vi.FKDefaultViewName);
            }
            return queryItem;
        }


        private ViewItemCollection GetQueryItemCollection()
        {
            ViewItemCollection queryItems = new ViewItemCollection();
            ViewItemCollection allItems = this.BusinessObjectView.VisibleColumnCollection;

            for (int i = 0; i < allItems.Count; i++)
            {
                ViewItem vi = allItems[i];
                if (vi.HasFilter)
                    queryItems.Add(vi);
            }
            return queryItems;
        }

        private AndOr GetFilterJunction(HtmlTable queryTable)
        {
            RadioButtonList queryType = queryTable.FindControl("__queryType") as RadioButtonList;
            return (queryType.SelectedIndex == 1) ? AndOr.OR : AndOr.AND;
        }
    }
}
