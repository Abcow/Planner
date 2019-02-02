
using System.Windows;
using System.Windows.Controls;

namespace Planner.NetCore.UI.Controls
{
    public partial class CalendarDayView : UserControl
    {
        private Alignment _labelAlignment;
        private FrameworkElement _label;
        private static readonly RowDefinition CONTENT_ROW = new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) };
        private static readonly ColumnDefinition CONTENT_COLUMN = new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) };
        private static readonly RowDefinition LABEL_ROW = new RowDefinition() { Height = GridLength.Auto };
        private static readonly ColumnDefinition LABEL_COLUMN = new ColumnDefinition() { Width = GridLength.Auto };
        private static readonly FrameworkElement EMPTY_CONTROL = new Grid() { Width=0, Height=0 };

        public CalendarDayView()
        {
            InitializeComponent();
            _label = EMPTY_CONTROL;
            LabelAlignment = Alignment.None;
        }

        #region Label

        public FrameworkElement Label
        {
            get { return (FrameworkElement)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value ?? EMPTY_CONTROL); }
        }
        
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(FrameworkElement), typeof(CalendarDayView), new PropertyMetadata(LabelChanged));

        private static void LabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendarDayView = (d as CalendarDayView);
            if (calendarDayView == null) return;

            calendarDayView.UpdateLabel();
        }

        #endregion
        
        #region LabelAlignment

        public Alignment LabelAlignment
        {
            get { return (Alignment)GetValue(LabelAlignmentProperty); }
            set { SetValue(LabelAlignmentProperty, value); }
        }
        
        public static readonly DependencyProperty LabelAlignmentProperty =
            DependencyProperty.Register("LabelAlignment", typeof(Alignment), typeof(CalendarDayView), new PropertyMetadata(LabelAlignmentChanged));

        private static void LabelAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var calendarDayView = (d as CalendarDayView);
            if (calendarDayView == null) return;

            calendarDayView.UpdateGrid();
        }

        #endregion
        
        #region EventTemplate

        public DataTemplate EventTemplate
        {
            get { return (DataTemplate)GetValue(EventTemplateProperty); }
            set { SetValue(EventTemplateProperty, value); }
        }
        
        public static readonly DependencyProperty EventTemplateProperty =
            DependencyProperty.Register("EventTemplate", typeof(DataTemplate), typeof(CalendarDayView), new PropertyMetadata(0));

        #endregion

        #region EventContainer

        public ItemsPanelTemplate EventContainer
        {
            get { return (ItemsPanelTemplate)GetValue(EventContainerProperty); }
            set { SetValue(EventContainerProperty, value); }
        }

        public static readonly DependencyProperty EventContainerProperty =
            DependencyProperty.Register("EventContainer", typeof(ItemsPanelTemplate), typeof(CalendarDayView), new PropertyMetadata(0));

        #endregion

        private void UpdateGrid()
        {
            switch (LabelAlignment)
            {
                case Alignment.None:
                    Grid.RowDefinitions.Clear();
                    Grid.RowDefinitions.Add(CONTENT_ROW);
                    Grid.ColumnDefinitions.Clear();
                    Grid.ColumnDefinitions.Add(CONTENT_COLUMN);

                    Grid.SetRow(Events, 0);
                    Grid.SetColumn(Events, 0);
                    break;

                case Alignment.Right:
                    Grid.RowDefinitions.Clear();
                    Grid.RowDefinitions.Add(CONTENT_ROW);
                    Grid.ColumnDefinitions.Clear();
                    Grid.ColumnDefinitions.Add(CONTENT_COLUMN);
                    Grid.ColumnDefinitions.Add(LABEL_COLUMN);

                    Grid.SetRow(Events, 0);
                    Grid.SetColumn(Events, 0);
                    break;

                case Alignment.Top:
                    Grid.RowDefinitions.Clear();
                    Grid.RowDefinitions.Add(LABEL_ROW);
                    Grid.RowDefinitions.Add(CONTENT_ROW);
                    Grid.ColumnDefinitions.Clear();
                    Grid.ColumnDefinitions.Add(CONTENT_COLUMN);

                    Grid.SetRow(Events, 1);
                    Grid.SetColumn(Events, 0);
                    break;

                case Alignment.Bottom:
                    Grid.RowDefinitions.Clear();
                    Grid.RowDefinitions.Add(CONTENT_ROW);
                    Grid.RowDefinitions.Add(LABEL_ROW);
                    Grid.ColumnDefinitions.Clear();
                    Grid.ColumnDefinitions.Add(CONTENT_COLUMN);
                    
                    Grid.SetRow(Events, 0);
                    Grid.SetColumn(Events, 0);
                    break;

                case Alignment.Left:
                    Grid.RowDefinitions.Clear();
                    Grid.RowDefinitions.Add(CONTENT_ROW);
                    Grid.ColumnDefinitions.Clear();
                    Grid.ColumnDefinitions.Add(LABEL_COLUMN);
                    Grid.ColumnDefinitions.Add(CONTENT_COLUMN);

                    Grid.SetRow(Events, 0);
                    Grid.SetColumn(Events, 1);
                    break;
            }

            UpdateLabel();
        }

        private void UpdateLabel()
        {

            switch (LabelAlignment)
            {
                case Alignment.None:
                    Label.Visibility = Visibility.Hidden;
                    break;

                case Alignment.Right:
                    Grid.SetRow(Label, 0);
                    Grid.SetColumn(Label, 1);
                    Label.Visibility = Visibility.Visible;
                    break;

                case Alignment.Top:
                    Grid.SetRow(Label, 0);
                    Grid.SetColumn(Label, 0);
                    Label.Visibility = Visibility.Visible;
                    break;

                case Alignment.Bottom:
                    Grid.SetRow(Label, 1);
                    Grid.SetColumn(Label, 0);
                    Label.Visibility = Visibility.Visible;
                    break;

                case Alignment.Left:
                    Grid.SetRow(Label, 0);
                    Grid.SetColumn(Label, 0);
                    Label.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
