using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FF12
{
	class Technique : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private readonly uint mIndex;

		public Technique(uint index)
		{
			mIndex = index;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(0xE0E4 + mIndex * 2, 2); }
			set
			{
				SaveData.Instance().WriteNumber(0xE0E4 + mIndex * 2, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public bool Learning
		{
			get
			{
				if (ID == 0xFFFF) return false;
				return SaveData.Instance().ReadBit(0x711C + (ID - 0x4000) / 8, (ID - 0x4000) % 8);
			}
			set
			{
				if (ID == 0xFFFF) return;
				SaveData.Instance().WriteBit(0x711C + (ID - 0x4000) / 8, (ID - 0x4000) % 8, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Learning)));
			}
		}
	}
}
