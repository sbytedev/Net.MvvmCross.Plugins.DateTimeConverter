using MvvmCross;
using MvvmCross.Binding.Binders;
using MvvmCross.Converters;
using MvvmCross.IoC;
using MvvmCross.Plugin;

// ReSharper disable once CheckNamespace
namespace SByteDev.MvvmCross.Plugins.DateTimeConverter
{
    [MvxPlugin]
    [Preserve(AllMembers = true)]
    public sealed class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.IoCProvider.CallbackWhenRegistered<IMvxValueConverterRegistry>(FillValueConverters);
        }

        private void FillValueConverters(IMvxValueConverterRegistry registry)
        {
            registry.Fill(GetType().Assembly);
        }
    }
}