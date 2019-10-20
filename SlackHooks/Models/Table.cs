using System.Collections.Generic;

namespace SlackHooks.Models
{
    /// <summary>
    /// Table.
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Columns.
        /// </summary>
        public virtual List<Column> Columns { get; protected set; } = new List<Column>();
    }
}