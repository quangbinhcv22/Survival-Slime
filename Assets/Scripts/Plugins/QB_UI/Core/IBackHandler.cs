namespace Plugins.QB_UI.Core
{
    public interface IBackHandler
    {
        /// <summary>
        /// Returned result indicates whether to execute the Container's flow afterwards 
        /// </summary>
        /// <returns></returns>
        bool OnBack();
    }
}