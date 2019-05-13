using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FF12
{
	class Item : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private readonly uint mIDAddress;
		private readonly uint mCountAddress;
		private readonly uint mOffset;

		public Item(uint id, uint count, uint offset)
		{
			mIDAddress = id;
			mCountAddress = count;
			mOffset = offset;
		}

		public uint ID
		{
			get { return SaveData.Instance().ReadNumber(mIDAddress, 2); }
			set
			{
				SaveData.Instance().WriteNumber(mIDAddress, 2, value);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
			}
		}

		public uint Count
		{
			get
			{
				if (ID == 0xFFFF) return 0;
				return SaveData.Instance().ReadNumber(mCountAddress + (ID - mOffset) * 2, 1);
			}
			set
			{
				if (ID == 0xFFFF) return;

				Unit.WriteNumber(mCountAddress + (ID - mOffset) * 2, 1, value, 0, 99);
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
			}
		}
	}
}
