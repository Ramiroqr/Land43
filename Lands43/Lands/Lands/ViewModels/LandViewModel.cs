namespace Lands.ViewModels
{
    using Lands.Models;
    class LandViewModel
    {
        #region MyRegion
        public Land Land
        {
            set;
            get;
        }

        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            this.Land = land;
        } 
        #endregion
    }
}
