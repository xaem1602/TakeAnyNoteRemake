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
using System.Text.Json;
using System.IO;

namespace TakeAnyNoteRemake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static public List<Note> notesList = new List<Note>();
        static public string jsonDataFile = "notes.json";
        static public StackPanel? notesPanel;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            notesPanel = notesContainer;
            UpdateListNotes();
            UpdateNotesContainer();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            UpdateJsonFile();  
            Application.Current.Shutdown();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            NoteW noteW = new NoteW();
            noteW.ShowDialog();
        }

        private void tbxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxSearch.Clear();
        }

        private void tbxSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            tbxSearch.Text = "Search for a note...";
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            notesList.ForEach(x => MessageBox.Show(x.text));
        }

        static public void UpdateNotesContainer()
        {
            notesPanel?.Children.Clear();
            notesList.ForEach(x =>
            {
                NoteUC noteUC = new NoteUC()
                {
                    NoteText = x.text,
                    NoteDateTime = x.date,
                    Height = 100,
                    Margin = new Thickness(0, 10, 0, 10)
                };
                notesPanel?.Children.Add(noteUC);
            });
        }

        private void UpdateJsonFile()
        {
            string jsonDataString = JsonSerializer.Serialize<List<Note>>(notesList);
            File.WriteAllText(jsonDataFile, jsonDataString);
        }

        private void UpdateListNotes()
        {
            string jsonDataString = File.ReadAllText(jsonDataFile);
            notesList = JsonSerializer.Deserialize<List<Note>>(jsonDataString)!;
        }
    }
}
