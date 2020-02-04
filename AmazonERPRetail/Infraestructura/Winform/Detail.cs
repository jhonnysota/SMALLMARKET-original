
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Infraestructura.Winform
{
    public partial class Detail : TabControl
    {
        public List<DataGridView> childGrid = new List<DataGridView>();
        public DataSet _cDataset;

        public Detail()
        {
            InitializeComponent();
        }

        public void Add(string tableName, string pageCaption)
        {
            TabPage tPage = new TabPage();
            // With...
            Text = pageCaption;
            this.TabPages.Add(tPage);
            DataGridView newGrid = new DataGridView();
            // With...
            newGrid.Dock = DockStyle.Fill;
            newGrid.DataSource = new DataView(_cDataset.Tables[tableName]);
            tPage.Controls.Add(newGrid);
            DataGridViewHelper.AplicarTema(newGrid);
            DataGridViewHelper.setGridRowHeader(newGrid);
            newGrid.RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridViewHelper.rowPostPaint_HeaderCount);
            childGrid.Add(newGrid);
            // TODO: #End Region ... Warning!!! not translated
            
        }
    }
}
