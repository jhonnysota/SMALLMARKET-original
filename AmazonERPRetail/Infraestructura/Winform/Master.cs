using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Infraestructura.Winform
{
    public partial class Master : DataGridView
    {

        public List<Int32> rowCurrent = new List<Int32>();
        public int rowDefaultHeight = 22;
        public int rowExpandedHeight = 300;
        public int rowDefaultDivider = 0;
        static int rowExpandedDivider = 300 - 22;
        static int rowDividerMargin = 5;
        public Boolean collapseRow;
        public Detail childView = new Detail() { Height = rowExpandedDivider - rowDividerMargin * 2, Visible = false };

        DataSet _cDataset;
        string _foreignKey;
        string _filterFormat;

        enum rowHeaderIcons
        {
            expand = 0,
            collapse = 1,
        }

        public Master(DataSet cDataset)
        {
            this.Controls.Add(childView);
            InitializeComponent();
            _cDataset = cDataset;
            childView._cDataset = cDataset;
            DataGridViewHelper.AplicarTema(this);
            Dock = DockStyle.Fill;
        }

        public void setParentSource(string tableName, string foreignKey)
        {
            this.DataSource = new DataView(_cDataset.Tables[tableName]);
            DataGridViewHelper.setGridRowHeader(this);
            _foreignKey = foreignKey;

            if (((_cDataset.Tables[tableName].Columns[foreignKey].DataType == Type.GetType("System.Int32"))
                        || (_cDataset.Tables[tableName].Columns[foreignKey].DataType == Type.GetType("System.Double"))
                        || (_cDataset.Tables[tableName].Columns[foreignKey].DataType == Type.GetType("System.Decimal"))))
            {
                _filterFormat = (foreignKey + "={0}");
            }
            else
            {
                _filterFormat = (foreignKey + "=\'{0}\'");
            }

        }

        public void pruebacab_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Rectangle rect = new Rectangle(((rowDefaultHeight - 16)
                            / 2), ((rowDefaultHeight - 16)
                            / 2), 16, 16);
            if (rect.Contains(e.Location))
            {
                if (rowCurrent.Contains(e.RowIndex))
                {
                    rowCurrent.Clear();
                    this.Rows[e.RowIndex].Height = rowDefaultHeight;
                    this.Rows[e.RowIndex].DividerHeight = rowDefaultDivider;
                }
                else
                {
                    if (!(rowCurrent.Count == 0))
                    {
                        int eRow = rowCurrent[0];
                        rowCurrent.Clear();
                        this.Rows[eRow].Height = rowDefaultHeight;
                        this.Rows[eRow].DividerHeight = rowDefaultDivider;
                        this.ClearSelection();
                        collapseRow = true;
                        this.Rows[eRow].Selected = true;
                    }

                    rowCurrent.Add(e.RowIndex);
                    this.Rows[e.RowIndex].Height = rowExpandedHeight;
                    this.Rows[e.RowIndex].DividerHeight = rowExpandedDivider;
                }

                this.ClearSelection();
                collapseRow = true;
                this.Rows[e.RowIndex].Selected = true;
            }
            else
            {
                collapseRow = false;
            }
        }

        public void pruebacab_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // set childview control
            Rectangle rect = new Rectangle((e.RowBounds.X
                            + ((rowDefaultHeight - 16)
                            / 2)), (e.RowBounds.Y
                            + ((rowDefaultHeight - 16)
                            / 2)), 16, 16);
            if (collapseRow)
            {
                if (rowCurrent.Contains(e.RowIndex))
                {
                    ((DataGridView)sender).Rows[e.RowIndex].DividerHeight = (((DataGridView)sender).Rows[e.RowIndex].Height - rowDefaultHeight);
                    e.Graphics.DrawImage(imgList.Images[(int)rowHeaderIcons.collapse], rect);
                    childView.Location = new Point((e.RowBounds.Left + ((DataGridView)sender).RowHeadersWidth), (e.RowBounds.Top
                                    + (rowDefaultHeight + 5)));
                    childView.Width = (e.RowBounds.Right - ((DataGridView)sender).RowHeadersWidth);
                    childView.Height = (((DataGridView)sender).Rows[e.RowIndex].DividerHeight - 10);
                    childView.Visible = true;
                }
                else
                {
                    childView.Visible = false;
                    e.Graphics.DrawImage(imgList.Images[(int)rowHeaderIcons.expand], rect);
                }

                collapseRow = false;
            }
            else if (rowCurrent.Contains(e.RowIndex))
            {
                ((DataGridView)sender).Rows[e.RowIndex].DividerHeight = (((DataGridView)sender).Rows[e.RowIndex].Height - rowDefaultHeight);
                e.Graphics.DrawImage(imgList.Images[(int)rowHeaderIcons.collapse], rect);
                childView.Location = new Point((e.RowBounds.Left + ((DataGridView)sender).RowHeadersWidth), (e.RowBounds.Top
                                + (rowDefaultHeight + 5)));
                childView.Width = (e.RowBounds.Right - ((DataGridView)sender).RowHeadersWidth);
                childView.Height = (((DataGridView)sender).Rows[e.RowIndex].DividerHeight - 10);
                childView.Visible = true;
            }
            else
            {
                e.Graphics.DrawImage(imgList.Images[(int)rowHeaderIcons.expand], rect);
            }

            DataGridViewHelper.rowPostPaint_HeaderCount(sender, e);
        }

        public void pruebacab_Scroll(object sender, ScrollEventArgs e)
        {
            if (!(rowCurrent.Count == 0))
            {
                collapseRow = true;
                this.ClearSelection();
                this.Rows[rowCurrent[0]].Selected = true;
            }

        }

        public void pruebacab_SelectionChanged(object sender, EventArgs e)
        {
            if (!(this.RowCount == 0))
            {
                if (rowCurrent.Contains(this.CurrentRow.Index))
                {
                    foreach (DataGridView cGrid in childView.childGrid)
                    {
                        ((DataView)(cGrid.DataSource)).RowFilter = string.Format(_filterFormat, this[_foreignKey, this.CurrentRow.Index].Value);
                    }

                }

            }

        }

    }
}
