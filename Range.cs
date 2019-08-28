﻿using System;
using System.Collections.Generic;
using Platform.Exceptions;

namespace Platform.Ranges
{
    /// <summary>
    /// <para>Represents a range between minumum and maximum values.</para>
    /// <para>Представляет диапазон между минимальным и максимальным значениями.</para>
    /// </summary>
    /// <remarks>
    /// <para>Based on <a href="http://stackoverflow.com/questions/5343006/is-there-a-c-sharp-type-for-representing-an-integer-range">the question at StackOveflow</a>.</para>
    /// <para>Основано на <a href="http://stackoverflow.com/questions/5343006/is-there-a-c-sharp-type-for-representing-an-integer-range">вопросе в StackOveflow</a>.</para>
    /// </remarks>
    public struct Range<T> : IEquatable<Range<T>>
    {
        private static readonly Comparer<T> _comparer = Comparer<T>.Default;
        private static readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;

        /// <summary>
        /// <para>Returns minimum value of the range.</para>
        /// <para>Возвращает минимальное значение диапазона.</para>
        /// </summary>
        public readonly T Minimum;

        /// <summary>
        /// <para>Returns maximum value of the range.</para>
        /// <para>Возвращает максимальное значение диапазона.</para>
        /// </summary>
        public readonly T Maximum;

        /// <summary>
        /// <para>Initializes a new instance of the Range class.</para>
        /// <para>Инициализирует новый экземпляр класса Range.</para>
        /// </summary>
        /// <param name="minimumAndMaximum"><para>Single value for both Minimum and Maximum fields.</para><para>Одно значение для полей Minimum и Maximum.</para></param>
        public Range(T minimumAndMaximum)
        {
            Minimum = minimumAndMaximum;
            Maximum = minimumAndMaximum;
        }

        /// <summary>
        /// <para>Initializes a new instance of the Range class.</para>
        /// <para>Инициализирует новый экземпляр класса Range.</para>
        /// </summary>
        /// <param name="minimum"><para>The minimum value of the range.</para><para>Минимальное значение диапазона.</para></param>
        /// <param name="maximum"><para>The maximum value of the range.</para><para>Максимальное значение диапазона.</para></param>
        /// <exception cref="ArgumentException"><para>Thrown when the maximum is less than the minimum.</para><para>Выбрасывается, когда максимум меньше минимума.</para></exception>
        public Range(T minimum, T maximum)
        {
            Ensure.Always.MaximumArgumentIsGreaterOrEqualToMinimum(minimum, maximum, nameof(maximum));
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// <para>Presents the Range in readable format.</para>
        /// <para>Представляет диапазон в удобном для чтения формате.</para>
        /// </summary>
        /// <returns><para>String representation of the Range.</para><para>Строковое представление диапазона.</para></returns>
        public override string ToString() => $"[{Minimum}, {Maximum}]";

        /// <summary>
        /// <para>Determines if the provided value is inside the range.</para>
        /// <para>Определяет, находится ли указанное значение внутри диапазона.</para>
        /// </summary>
        /// <param name="value"><para>The value to test.</para><para>Значение для проверки.</para></param>
        /// <returns><para>True if the value is inside Range, else false.</para><para>True, если значение находится внутри диапазона, иначе false.</para></returns>
        public bool ContainsValue(T value) => _comparer.Compare(Minimum, value) <= 0 && _comparer.Compare(Maximum, value) >= 0;

        /// <summary>
        /// <para>Determines if this Range is inside the bounds of another range.</para>
        /// <para>Определяет, находится ли этот диапазон в пределах другого диапазона.</para>
        /// </summary>
        /// <param name="range"><para>The parent range to test on.</para><para>Родительский диапазон для проверки.</para></param>
        /// <returns><para>True if range is inclusive, else false.</para><para>True, если диапазон включен, иначе false.</para></returns>
        public bool IsInsideRange(Range<T> range) => range.ContainsRange(this);

        /// <summary>
        /// <para>Determines if another range is inside the bounds of this range.</para>
        /// <para>Определяет, находится ли другой диапазон внутри границ этого диапазона.</para>
        /// </summary>
        /// <param name="range"><para>The child range to test.</para><para>Дочерний диапазон для проверки.</para></param>
        /// <returns><para>True if range is inside, else false.</para><para>True, если диапазон находится внутри, иначе false.</para></returns>
        public bool ContainsRange(Range<T> range) => ContainsValue(range.Minimum) && ContainsValue(range.Maximum);

        /// <summary>
        /// <para>Indicates whether the current range is equal to another range.</para>
        /// <para>Определяет, равен ли текущий диапазон другому диапазону.</para>
        /// </summary>
        /// <param name="other"><para>A range to compare with this range.</para><para>Диапазон для сравнения с этим диапазоном.</para></param>
        /// <returns><para>True if the current range is equal to the other range; otherwise, false.</para><para>True, если текущий диапазон равен другому диапазону; иначе false.</para></returns>
        public bool Equals(Range<T> other) => _equalityComparer.Equals(Minimum, other.Minimum) && _equalityComparer.Equals(Maximum, other.Maximum);

        /// <summary>
        /// <para>Creates a new <see cref="ValueTuple{T,T}"/> struct initialized with <see cref="Range{T}.Minimum"/> as <see cref="ValueTuple{T,T}.Item1"/> and <see cref="Range{T}.Maximum"/> as <see cref="ValueTuple{T,T}.Item2"/>.</para>
        /// <para>Создает новую структуру <see cref="ValueTuple{T,T}"/>, инициализированную с помощью <see cref="Range{T}.Minimum"/> как <see cref="ValueTuple{T,T}.Item1"/> и <see cref="Range{T}.Maximum"/> как <see cref="ValueTuple{T,T}.Item2"/>.</para>
        /// </summary>
        /// <param name="range"><para>The range of <typeparamref name="T"/>.</para><para>Диапазон значений <typeparamref name="T"/>.</para></param>
        public static implicit operator ValueTuple<T, T>(Range<T> range) => (range.Minimum, range.Maximum);

        /// <summary>
        /// <para>Creates a new <see cref="Range{T}"/> struct initialized with <see cref="ValueTuple{T,T}.Item1"/> as <see cref="Range{T}.Minimum"/> and <see cref="ValueTuple{T,T}.Item2"/> as <see cref="Range{T}.Maximum"/>.</para>
        /// <para>Создает новую структуру <see cref="Range{T}"/>, инициализированную с помощью <see cref="ValueTuple{T,T}.Item1"/> как <see cref="Range{T}.Minimum"/> и <see cref="ValueTuple{T,T}.Item2"/> как <see cref="Range{T}.Maximum"/>.</para>
        /// </summary>
        /// <param name="tuple"><para>The tuple.</para><para>Кортеж.</para></param>
        public static implicit operator Range<T>(ValueTuple<T, T> tuple) => new Range<T>(tuple.Item1, tuple.Item2);
    }
}
