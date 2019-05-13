using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FF12
{
	class ViewModel
	{
		public ObservableCollection<Charactor> Party { get; set; } = new ObservableCollection<Charactor>();

		public ObservableCollection<Item> Consumable { get; set; } = new ObservableCollection<Item>();
		public ObservableCollection<Item> Weapon { get; set; } = new ObservableCollection<Item>();

		public PlayTime PlayTime { get; set; } = new PlayTime();
		public uint Gil
		{
			get { return SaveData.Instance().ReadNumber(0x08, 4); }
			set { Unit.WriteNumber(0x08, 4, value, 0, 99999999); }
		}

		public uint Step
		{
			get { return SaveData.Instance().ReadNumber(0x0C, 4); }
			set { Unit.WriteNumber(0x0C, 4, value, 0, 99999999); }
		}

		public ViewModel()
		{
			String[] names = { "VAAN", "PENELO", "BALTHIER", "FRAN", "BASCH", "ASHE" };
			for(uint i = 0; i < names.Length; i++)
			{
				Party.Add(new Charactor(0x2210 + i * 2280, names[i]));
			}

			for(uint i = 0; i < 64; i++)
			{
				Consumable.Add(new Item(0xDACC + i * 2, 0x6948, 0));
			}

			for(uint i = 0; i < 200; i++)
			{
				Weapon.Add(new Item(0xDB4C + i * 2, 0x69CA, 0x1001));
			}
		}

		public void ItemCount()
		{
			uint count = 0;
			foreach(var item in Consumable)
			{
				if (item.ID != 0xFFFF) count++;
			}
			SaveData.Instance().WriteNumber(0xE9B8, 4, count);

			count = 0;
			foreach (var item in Weapon)
			{
				if (item.ID != 0xFFFF) count++;
			}
			SaveData.Instance().WriteNumber(0xE9BC, 4, count);
		}
	}
}
