namespace Geocode.Interfaces
{
    public interface IGeoDataImport
    {
        /// <summary>
        /// Runs data import via EF core from the file in the data directory
        /// </summary>
        Task<bool> ImportData();
    }
}
