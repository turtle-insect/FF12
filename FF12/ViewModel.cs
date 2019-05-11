using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF12
{
	class ViewModel
	{
		public PlayTime PlayTime { get; set; } = new PlayTime();
		public uint Gil
		{
			get { return SaveData.Instance().ReadNumber(0x08, 4); }
			set { Unit.WriteNumber(0x08, 4, value, 0, 99999999); }
		}
	}
}
