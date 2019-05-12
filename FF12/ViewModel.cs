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
		}
	}
}
