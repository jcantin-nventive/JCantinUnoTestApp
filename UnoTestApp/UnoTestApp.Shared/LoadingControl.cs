using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UnoTestApp
{
	public partial class LoadingControl : Control
	{
		private const string PART_ContentPresenterName = "ContentPresenter";

		private ContentPresenter _contentPresenter;

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			_contentPresenter = (ContentPresenter)GetTemplateChild(PART_ContentPresenterName);
		}

		public DataTemplate ContentTemplate
		{
			get { return (DataTemplate)GetValue(ContentTemplateProperty); }
			set { SetValue(ContentTemplateProperty, value); }
		}

		public static readonly DependencyProperty ContentTemplateProperty =
			DependencyProperty.Register("ContentTemplate", typeof(DataTemplate), typeof(LoadingControl), new PropertyMetadata(null));

		public ICommand LoadContent => new LoadContentCommand(this);

		public class LoadContentCommand : ICommand
		{
			private LoadingControl _loadingControl;

			public LoadContentCommand(LoadingControl parent)
			{
				_loadingControl = parent;
			}

			public event EventHandler CanExecuteChanged;

			public bool CanExecute(object obj) => true;

			public void Execute(object obj)
			{
				_loadingControl._contentPresenter.Visibility = Visibility.Visible;
			}
		}
	}
}
