using System.Collections.Generic;

namespace SlackHooks.Models
{
    /// <summary>
    /// Column.
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Name.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Fields.
        /// </summary>
        public virtual List<Field> Fields { get; protected set; } = new List<Field>();
    }
}