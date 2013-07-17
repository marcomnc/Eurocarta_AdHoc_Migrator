// ----------------------------------------------------------------------------
// <copyright file="ProgressHandler.cs" company="AdHocMigrator">
//   Paolo Mosca
// </copyright>
// <summary>
//   Gestore avanzamento di una fase della migrazione
// </summary>
// ----------------------------------------------------------------------------

namespace AdHocMigrator.Data
{
    /// <summary>
    /// Evento per segnalare l'avanzamento della migrazione
    /// </summary>
    /// <param name="sender">
    /// oggetto che lancia l'evento
    /// </param>
    /// <param name="value">
    /// valore tra 0 e 100
    /// </param>
    public delegate void ProgressHandler(object sender, int value);
}
