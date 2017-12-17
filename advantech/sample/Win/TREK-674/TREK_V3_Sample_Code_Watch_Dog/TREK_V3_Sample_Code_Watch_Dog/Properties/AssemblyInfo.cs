using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 組件的一般資訊是由下列的屬性集控制
// 變更這些屬性的值即可修改組件的相關
// 資訊。
[assembly: AssemblyTitle("Watchdog Sample")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Watchdog Sample")]
[assembly: AssemblyCopyright("Copyright c  2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

//  將 ComVisible 設定為 false 會使得這個組件中的型別
// 對 COM 元件而言為不可見。如果您需要從 COM 存取這個組件中
// 的型別，請在該型別上將 ComVisible 屬性設定為 true。
[assembly: ComVisible(false)]

// 下列 GUID 為專案公開 (Expose) 至 COM 時所要使用的 typelib ID
[assembly: Guid("a1d51b87-dc7c-4562-96cd-099c1cae3b8c")]

// 組件的版本資訊是由下列四項值構成:
//
//      主要版本
//      次要版本
//      組建編號
//      修訂編號
//
[assembly: AssemblyVersion("1.0.0.0")]

// 下列屬性將會抑制 FxCop 警告 "CA2232 : Microsoft.Usage : 將 STAThreadAttribute 加入組件"
// 因為裝置應用程式不支援 STA 執行緒。
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2232:MarkWindowsFormsEntryPointsWithStaThread")]
