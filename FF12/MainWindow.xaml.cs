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
using Microsoft.Win32;

namespace FF12
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Window_PreviewDragOver(object sender, DragEventArgs e)
		{
			e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
		}

		private void Window_Drop(object sender, DragEventArgs e)
		{
			String[] files = e.Data.GetData(DataFormats.FileDrop) as String[];
			if (files == null) return;
			if (!System.IO.File.Exists(files[0])) return;

			if (SaveData.Instance().Open(files[0], false))
			{
				DataContext = new ViewModel();
			}
		}

		private void MenuItemFileOpen_Click(object sender, RoutedEventArgs e)
		{
			FileOpen(false);
		}

		private void MenuItemFileOpenForce_Click(object sender, RoutedEventArgs e)
		{
			FileOpen(true);
		}

		private void FileOpen(bool force)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().Open(dlg.FileName, force))
			{
				DataContext = new ViewModel();
			}
		}

		private void MenuItemFileSave_Click(object sender, RoutedEventArgs e)
		{
			(DataContext as ViewModel)?.ItemCount();
			SaveData.Instance().Save();
		}

		private void MenuItemFileSaveAs_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			(DataContext as ViewModel)?.ItemCount();
			SaveData.Instance().SaveAs(dlg.FileName);
		}

		private void MenuItemFileImport_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new OpenFileDialog();
			if (dlg.ShowDialog() == false) return;

			if (SaveData.Instance().Import(dlg.FileName)) DataContext = new ViewModel();
		}

		private void MenuItemFileExport_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new SaveFileDialog();
			if (dlg.ShowDialog() == false) return;

			SaveData.Instance().Export(dlg.FileName);
		}

		private void MenuItemFileExit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
		{
			new AboutWindow().ShowDialog();
		}

		private void ButtonChoiceConsumable_Click(object sender, RoutedEventArgs e)
		{
			ItemChoice((sender as Button)?.DataContext as Item, ChoiceWindow.eType.eConsumable);
		}

		private void ButtonChoiceWeapon_Click(object sender, RoutedEventArgs e)
		{
			ItemChoice((sender as Button)?.DataContext as Item, ChoiceWindow.eType.eWeapon);
		}

		private void ButtonChoiceArmmor_Click(object sender, RoutedEventArgs e)
		{
			ItemChoice((sender as Button)?.DataContext as Item, ChoiceWindow.eType.eArmmor);
		}

		private void ButtonChoiceAccessorie_Click(object sender, RoutedEventArgs e)
		{
			ItemChoice((sender as Button)?.DataContext as Item, ChoiceWindow.eType.eAccessorie);
		}

		private void ItemChoice(Item item, ChoiceWindow.eType type)
		{
			if (item == null) return;
			ChoiceWindow dlg = new ChoiceWindow();
			dlg.Type = type;
			dlg.ID = item.ID;
			dlg.ShowDialog();

			if (dlg.ID == item.ID) return;

			item.Count = 0;
			item.ID = dlg.ID;
			item.Count = 1;
		}
	}
}
