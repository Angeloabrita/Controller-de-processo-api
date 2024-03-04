using ProcessController.Interfaces;

namespace ProcessController.Services
{
    /// <summary>
    /// Class that implements calculations for availability, quality, performance, and OEE indicators.
    /// </summary>
    public class IndicatorCalc : IAvaibleCalc, IOeeCalc, IPerformanceCalc, IQualityCalc
    {
        /// <summary>
        /// Calculates the OEE (Overall Equipment Effectiveness) based on availability, performance, and quality parameters.
        /// </summary>
        /// <param name="avaible">Equipment availability.</param>
        /// <param name="performance">Equipment performance.</param>
        /// <param name="quality">Production quality.</param>
        /// <returns>The calculated OEE value.</returns>
        public int OeeCalc(int avaible, int performance, int quality)
        {
            return avaible * performance * quality;
        }

        /// <summary>
        /// Calculates production quality based on the number of good and bad parts produced.
        /// </summary>
        /// <param name="good_part">Number of good parts produced.</param>
        /// <param name="bad_part">Number of bad parts produced.</param>
        /// <returns>The percentage of good parts.</returns>
        public int QualityCal(int good_part, int bad_part)
        {
            return (good_part / (good_part + bad_part)) * 100;
        }

        /// <summary>
        /// Calculates equipment availability based on available time and working time.
        /// </summary>
        /// <param name="time_avaible">Equipment available time.</param>
        /// <param name="time_work">Equipment working time.</param>
        /// <returns>The availability percentage.</returns>
        public int AvailibityCalc(int time_avaible, int time_work)
        {
            return (time_work / time_avaible) * 100;
        }

        /// <summary>
        /// Calculates production performance based on current and estimated production.
        /// </summary>
        /// <param name="actual_prodution">Current production.</param>
        /// <param name="estimative_prodution">Estimated production.</param>
        /// <returns>The performance percentage.</returns>
        public int PerformanceCalc(int actual_prodution, int estimative_prodution)
        {
            return actual_prodution / estimative_prodution * 100;
        }
    }
}
