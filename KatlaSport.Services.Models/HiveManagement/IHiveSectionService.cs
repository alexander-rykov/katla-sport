using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Represents a hive section service.
    /// </summary>
    public interface IHiveSectionService
    {
        /// <summary>
        /// Gets a list of hive sections.
        /// </summary>
        /// <returns>A <see>
        ///         <cref>Task{List{HiveSectionListItem}}</cref>
        ///     </see>
        ///     .</returns>
        Task<List<HiveSectionListItem>> GetHiveSectionsAsync();

        /// <summary>
        /// Gets a hive section.
        /// </summary>
        /// <param name="id">A hive section identifier.</param>
        /// <returns>A <see cref="Task{HiveSection}"/>.</returns>
        Task<HiveSection> GetHiveSectionAsync(int id);

        /// <summary>
        /// Gets a list of hive sections for specified hive.
        /// </summary>
        /// <param name="hiveId">A hive identifier.</param>
        /// <returns>A <see>
        ///         <cref>Task{List{HiveSectionListItem}}</cref>
        ///     </see>
        ///     .</returns>
        Task<List<HiveSectionListItem>> GetHiveSectionsAsync(int hiveId);

        /// <summary>
        /// Creates a new hive section.
        /// </summary>
        /// <param name="createSectionRequest">A <see cref="UpdateHiveSectionRequest"/>.</param>
        /// <returns>A <see cref="Task{HiveSection}"/>.</returns>
        Task<HiveSection> CreateHiveSectionAsync(UpdateHiveSectionRequest createSectionRequest);

        /// <summary>
        /// Updates an existed hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <param name="updateSectionRequest">A <see cref="UpdateHiveSectionRequest"/>.</param>
        /// <returns>A <see cref="Task{Hive}"/>.</returns>
        Task<HiveSection> UpdateHiveSectionAsync(int hiveSectionId, UpdateHiveSectionRequest updateSectionRequest);

        /// <summary>
        /// Deletes an existed hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <returns><see cref="Task"/>.</returns>
        Task DeleteHiveSectionAsync(int hiveSectionId);

        /// <summary>
        /// Sets deleted status for a hive section.
        /// </summary>
        /// <param name="hiveSectionId">A hive section identifier.</param>
        /// <param name="deletedStatus">Status.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task SetStatusAsync(int hiveSectionId, bool deletedStatus);
    }
}
