using System;
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

namespace TakeAnyNoteRemake
{
    /// <summary>
    /// Interaction logic for NoteW.xaml
    /// </summary>
    public partial class NoteW : Window
    {
        public bool EditMode = false;
        public Note? SelectedNote = null;

        public NoteW()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbx_NoteText.Text))
            {
                if (!EditMode)
                {
                    MainWindow.notesList.Add(new Note(tbx_NoteText.Text, DateTime.Now));
                }
                else
                {
                    SelectedNote!.text = tbx_NoteText.Text;
                }
            }
            MainWindow.UpdateNotesContainer();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (EditMode)
            {
                this.tbx_NoteText.Text = SelectedNote?.text;
            }
        }
    }
}