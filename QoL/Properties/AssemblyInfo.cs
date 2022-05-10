using System;
using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(QoL.BuildInfo.Description)]
[assembly: AssemblyDescription(QoL.BuildInfo.Description)]
[assembly: AssemblyCompany(QoL.BuildInfo.Company)]
[assembly: AssemblyProduct(QoL.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + QoL.BuildInfo.Author)]
[assembly: AssemblyTrademark(QoL.BuildInfo.Company)]
[assembly: AssemblyVersion(QoL.BuildInfo.Version)]
[assembly: AssemblyFileVersion(QoL.BuildInfo.Version)]
[assembly: MelonInfo(typeof(QoL.Loader), QoL.BuildInfo.Name, QoL.BuildInfo.Version, QoL.BuildInfo.Author, QoL.BuildInfo.DownloadLink)]
[assembly: MelonColor()]
[assembly: MelonGame(null, null)]