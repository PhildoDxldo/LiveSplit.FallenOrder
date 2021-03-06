﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveSplit.FallenOrder.Data
{
	public class SplitCollection
	{
		private int splitIndex;

		public Split[] Splits { get; set; }
		public Split CurrentSplit { get; private set; }

		public void OnStart()
		{
			CurrentSplit = Splits?[0];
		}

		public void OnSplit()
		{
			if (Splits == null || Splits.Length == 0)
			{
				return;
			}

			AdvanceSplit();
		}

		public void OnUndoSplit()
		{
			if (Splits == null || Splits.Length == 0)
			{
				return;
			}

			CurrentSplit = Splits[--splitIndex];
		}

		public void OnSkipSplit()
		{
			if (Splits == null || Splits.Length == 0)
			{
				return;
			}

			AdvanceSplit();
		}

		private void AdvanceSplit()
		{
			CurrentSplit = splitIndex < Splits.Length - 1 ? Splits[++splitIndex] : null;
		}

		public void OnReset()
		{
			if (Splits == null || Splits.Length == 0)
			{
				return;
			}

			CurrentSplit = null;
			splitIndex = 0;
		}
	}
}
