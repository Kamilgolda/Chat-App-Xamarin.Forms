using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zadApi.Views.Templates
{
    public partial class ItemTemplate : ContentView
    {
        public static readonly BindableProperty GenderColorProperty = BindableProperty.Create("GenderColor", typeof(string), typeof(ItemTemplate),string.Empty);
        public string GenderColor
        {
            get { return GetValue(GenderColorProperty).ToString(); }
            set
            {
                SetValue(GenderColorProperty, value);
            }
        }
        public ItemTemplate()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(GenderColor))
            {
                if (BindingContext == null)
                {
                    Color c = new Color();

                    Stack.BackgroundColor = Color.YellowGreen;
                }
            }
        }
    }
}