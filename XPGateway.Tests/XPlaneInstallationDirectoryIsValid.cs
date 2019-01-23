using NUnit.Framework;
using XPGateway.Framework.Tasks;

namespace XPGateway.Tests
{
    [TestFixture]
    public class XPlaneInstallationDirectoryIsValid
    {
        private readonly XPlaneInstallationDirectoryTask _xPlaneinstallationDirectoryTask;

        public XPlaneInstallationDirectoryIsValid()
        {
            _xPlaneinstallationDirectoryTask = new XPlaneInstallationDirectoryTask();
        }

        [Test]
        public void CheckThatXPlaneDirectoryIsNotEmpty()
        {
            Assert.NotNull(_xPlaneinstallationDirectoryTask.GetXPlaneInstallationPath(false), "X-Plane directory shouldn't be empty.");
        }
    }
}
