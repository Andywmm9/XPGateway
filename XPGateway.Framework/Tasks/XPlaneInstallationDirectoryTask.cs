using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace XPGateway.Framework.Tasks
{
    /// <summary>
    /// A task responsible for finding the installation location of X-Plane.
    /// </summary>
    public class XPlaneInstallationDirectoryTask
    {
        private const string XPlaneInstallFileName = "x-plane_install_11.txt";

        public string GetXPlaneInstallationPath()
        {
            var path = GetAppDataPath() + Path.DirectorySeparatorChar + XPlaneInstallFileName;

            if (File.Exists(path))
                return File.ReadLines(path).Last();

            return null;
        }

        private string GetAppDataPath()
        {
            var userPath = Environment.GetEnvironmentVariable(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? "LOCALAPPDATA" : "Home");

            var assy = Assembly.GetEntryAssembly();
            var companyName = assy.GetCustomAttributes<AssemblyCompanyAttribute>().FirstOrDefault();
            var path = System.IO.Path.Combine(userPath, companyName.Company);

            return path;
        }
    }
}