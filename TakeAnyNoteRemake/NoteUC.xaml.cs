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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TakeAnyNoteRemake
{
    /// <summary>
    /// Interaction logic for NoteUC.xaml
    /// </summary>
    public partial class NoteUC : UserControl
    {
        public NoteUC()
        {
            InitializeComponent();
        }

        public DateTime NoteDateTime
        {
            get
            {
                return DateTime.Parse(lbl_Note_DateTime.Text!);
            }

            set
            {
                lbl_Note_DateTime.Text = value.ToShortDateString() + " " + value.ToShortTimeString();
            }
        }

        public string? NoteText
        {
            get
            {
                return lbl_Note_Text.Text;
            }

            set
            {
                lbl_Note_Text.Text=value; 
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Note note = MainWindow.notesList.FirstOrDefault(x => x.text == NoteText)!;

            MainWindow.notesList.Remove(note);
            MainWindow.UpdateNotesContainer();

            //MessageBox.Show(note.text);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NoteW noteW = new NoteW();
            noteW.EditMode = true;
            noteW.SelectedNote = MainWindow.notesList.FirstOrDefault(x => x.text == this.NoteText);
            noteW.ShowDialog();


            //MessageBox.Show("edit");
        }
    }
}
