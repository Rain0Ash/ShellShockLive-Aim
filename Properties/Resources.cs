// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace ssl_aimbot.Properties
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (ssl_aimbot.Properties.Resources.resourceMan == null)
          ssl_aimbot.Properties.Resources.resourceMan = new ResourceManager("ssl_aimbot.Properties.Resources", typeof (ssl_aimbot.Properties.Resources).Assembly);
        return ssl_aimbot.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return ssl_aimbot.Properties.Resources.resourceCulture;
      }
      set
      {
        ssl_aimbot.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
