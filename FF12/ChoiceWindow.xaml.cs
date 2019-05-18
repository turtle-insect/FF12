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

namespace FF12
{
	/// <summary>
	/// ChoiceWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class ChoiceWindow : Window
	{
		public enum eType
		{
			eConsumable,
			eWeapon,
			eArmor,
			eAccessorie,
			eMagic,
			eTechnique,
		};
		public uint ID { get; set; }
		public eType Type { get; set; } = eType.eConsumable;

		public ChoiceWindow()
		{
			InitializeComponent();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			CreateItemList("");
		}

		private void TextBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
		{
			CreateItemList(TextBoxFilter.Text);
		}

		private void ListBoxItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ButtonDecision.IsEnabled = ListBoxItem.SelectedIndex >= 0;
		}

		private void ButtonDecision_Click(object sender, RoutedEventArgs e)
		{
			var item = (NameValueInfo)ListBoxItem.SelectedItem;
			ID = item.Value;
			Close();
		}

		private void CreateItemList(String filter)
		{
			ListBoxItem.Items.Clear();
			var items = Info.Instance().Consumable;
			switch(Type)
			{
				case eType.eWeapon:
					items = Info.Instance().Weapon;
					break;

				case eType.eArmor:
					items = Info.Instance().Armor;
					break;

				case eType.eAccessorie:
					items = Info.Instance().Accessorie;
					break;

				case eType.eMagic:
					items = Info.Instance().Magic;
					break;

				case eType.eTechnique:
					items = Info.Instance().Technique;
					break;
			}

			foreach (var item in items)
			{
				if (String.IsNullOrEmpty(filter) || item.Name.IndexOf(filter) >= 0)
				{
					ListBoxItem.Items.Add(item);
				}
			}
		}
	}
}
