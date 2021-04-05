using System;

namespace StudioPasokon.ForEverProject.DataTypes
{
    /// <summary>
    /// Implementation of the non-null, non-empty and non-whitespace string type.
    /// </summary>
    public struct MandatoryString
    {
        /// <summary>
        /// This field contains the real string data.
        /// </summary>
        private string _internalString;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The string value to store in the <see cref="MandatoryString"> type.</param>
        public MandatoryString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "A mandatory string cannot be null, empty or fully whitespace");

            _internalString = value;
        }

        /// <inheritdoc />
        public override string ToString() => _internalString;

        /// <summary>
        /// Implecit conversion from a <see cref="MandatoryString"/> to an ordinary string.
        /// </summary>
        /// <param name="ms"></param>
        public static implicit operator string(MandatoryString ms) => ms.ToString();
    }
}
