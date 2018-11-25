using Planner.Models.DateTime;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Planner.Views
{
    /// <summary>
    /// Interaction logic for DayMatrix.xaml
    /// </summary>
    public partial class DayMatrix : UserControl
    {
        public DayMatrix()
        {
            InitializeComponent();
        }

        public CalendarDayViewModel this[int x, int y]
        {
            get
            {

            }
        }

        public ColumnDefinitionCollection Columns
        {
            get => Grid.ColumnDefinitions;
        }

        public RowDefinitionCollection Rows
        {
            get => Grid.RowDefinitions;
        }
    }
}
