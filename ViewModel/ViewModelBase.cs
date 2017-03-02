using System;
using FreshMvvm;
using PropertyChanged;

namespace FormsTestApp
{
	[ImplementPropertyChanged]
	public class ViewModelBase : FreshBasePageModel
	{
		public ViewModelBase()
		{
		}
	}
}
