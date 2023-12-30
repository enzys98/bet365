using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CEBet365Placer.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("CEBet365Placer.Properties.Resources", typeof(Resources).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static Bitmap bet365_sm => (Bitmap)ResourceManager.GetObject("bet365_sm", resourceCulture);

	internal static Bitmap coin2 => (Bitmap)ResourceManager.GetObject("coin2", resourceCulture);

	internal static Bitmap contact => (Bitmap)ResourceManager.GetObject("contact", resourceCulture);

	internal static Bitmap logo => (Bitmap)ResourceManager.GetObject("logo", resourceCulture);

	internal static Bitmap password_idle => (Bitmap)ResourceManager.GetObject("password_idle", resourceCulture);

	internal static Bitmap settings => (Bitmap)ResourceManager.GetObject("settings", resourceCulture);

	internal static Bitmap username_idle => (Bitmap)ResourceManager.GetObject("username_idle", resourceCulture);

	internal Resources()
	{
	}
}
