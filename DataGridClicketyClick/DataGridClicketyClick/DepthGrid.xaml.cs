﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace DataGridClicketyClick
{
    /// <summary>
    /// Interaction logic for DepthGrid.xaml
    /// </summary>
    public partial class DepthGrid : UserControl
    {
         DataTable table = new DataTable();
           
        public DepthGrid()
        {
            InitializeComponent();
           // DataTable table = new DataTable();
            table.Columns.Add("BidQty", typeof(double));
            table.Columns.Add("Price", typeof(double));
            table.Columns.Add("AskQty", typeof(double));

            foreach (int i in Enumerable.Range(0, 9))
            {
                table.Rows.Add(3000 + i, 100 + i, 50000 + i);
            }
            this.DataContext = this;
        }

        public DataTable DepthTable
        {
            get
            {
                return table;
            }
            
        }

        public string Pants
        {
            get { return "Bind!"; }
        }

        private void DataGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = e.OriginalSource as TextBlock;
            if (textBlock != null)
            {
                BindingExpression binding = textBlock.GetBindingExpression(TextBlock.TextProperty);
                DataRowView rowView = ((System.Data.DataRowView)binding.DataItem);
                Console.WriteLine(string.Format("Clicked on {0}={1}\r\n\tRow Values={2}",  binding.ParentBinding.Path.Path, textBlock.Text, string.Join(",", rowView.Row.ItemArray)));

            }
        }
    }
}
