using System;

namespace SlackHooks.Enums
{
    /// <summary>
    /// Mark Down Type.
    /// </summary>
    [Flags]
    public enum MarkDownType
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0, 

        /// <summary>
        /// Text.
        /// </summary>
        Text = 1 << 0,
        
        /// <summary>
        /// Pretext.
        /// </summary>
        Pretext = 1 << 1,

        /// <summary>
        /// Fields.
        /// </summary>
        Fields = 1 << 2
    }
}