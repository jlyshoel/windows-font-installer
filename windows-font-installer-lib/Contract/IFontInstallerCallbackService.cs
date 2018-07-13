using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace JLyshoel.FontInstaller.Contract
{
    /// <summary>
    /// Callback service for font installer
    /// </summary>
    public interface IFontInstallerCallbackService
    {

        [OperationContract(IsOneWay = true)]
        void FontInstalledCallback(bool installedOk, string message);
    }
}
