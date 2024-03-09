using Microsoft.Win32;
using System;
using System.IO;
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

namespace LR2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //"Save"
            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
            CommandBindings.Add(saveCommand);

            // "Open"
            CommandBinding openCommand = 
                new CommandBinding(ApplicationCommands.Open, execute_Open, canExecute_Open);
            CommandBindings.Add(openCommand);

            //"Delete"
            CommandBinding deleteCommand = 
                new CommandBinding(ApplicationCommands.Delete, execute_Delete, canExecute_Delete);
            CommandBindings.Add(deleteCommand);

        }
        //Save
        void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Trim().Length > 0)
                e.CanExecute = true; 
            else 
                e.CanExecute = false;
        }
        void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            System.IO.File.WriteAllText("C:\\University\\THIRD year\\ІІ СЕМЕСТР\\U_Interfaces\\LR2\\myFile.txt", inputTextBox.Text);
            MessageBox.Show("The file was saved!");
        }
        // Open
        private void canExecute_Open(object sender, CanExecuteRoutedEventArgs e)
        {
            
            e.CanExecute = true; 
        }

        private void execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    string fileContent = File.ReadAllText(filePath);
                    inputTextBox.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка читання файлу: " + ex.Message);
                }
            }
        }

        // Delete
        private void canExecute_Delete(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Trim().Length > 0)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void execute_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.Text = string.Empty;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
