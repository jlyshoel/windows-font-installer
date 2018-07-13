using System;
using System.ServiceModel;

namespace JLyshoel.FontInstaller.Contract
{

    /// <summary>
    /// Font installer service interface
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IFontInstallerCallbackService))]
    public interface IFontInstallerService
    {
        [OperationContract]
        string InstallFont(string fontFilePath);
    }

}

