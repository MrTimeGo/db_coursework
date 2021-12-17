﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp.Views.GradeViews
{
    /// <summary>
    /// Interaction logic for GradeSearchResultDialog.xaml
    /// </summary>
    public partial class GradeSearchResultDialog : Window, ISearchResultDialog
    {
        public GradeSearchResultDialog()
        {
            InitializeComponent();
            Table = table;
        }

        public ListView Table { get; set; }

    }
}
