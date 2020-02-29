﻿namespace Platform::Ranges
{
    struct Range<T> : IEquatable<Range<T>>
    {

        public: T Minimum = 0;

        public: T Maximum = 0;

        public: Range(T minimumAndMaximum)
        {
            Minimum = minimumAndMaximum;
            Maximum = minimumAndMaximum;
        }

        public: Range(T minimum, T maximum)
        {
            Platform::Ranges::EnsureExtensions::MaximumArgumentIsGreaterOrEqualToMinimum(Platform::Exceptions::Ensure::Always, minimum, maximum, this->nameof(maximum));
            Minimum = minimum;
            Maximum = maximum;
        }

        public: override const char* ToString() { return ((std::string)((std::string)"[").append(Minimum).append(", ").data()).append(Maximum).append("]").data(); }

        public: bool Contains(T value) { return Minimum <= value && Maximum >= value; }

        public: bool Contains(Range<T> range) { return this->Contains(range.Minimum) && this->Contains(range.Maximum); }

        public: bool Equals(Range<T> other) { return Minimum == other.Minimum && Maximum == other.Maximum; }

        public: static implicit operator std::tuple<T, T>(Range<T> range) { return {range.Minimum, range.Maximum}; }

        public: static implicit operator Range<T>(std::tuple<T, T> tuple) { return new Range<T>(tuple.Item1, tuple.Item2); }

        public: bool Equals(void *obj) override { return obj is Range<T> range ? this->Equals(range) : false; }

        public: override std::int32_t GetHashCode() { return {Minimum, Maximum}.GetHashCode(); }

        public: static bool operator ==(Range<T> left, Range<T> right) { return left.Equals(right); }

        public: static bool operator !=(Range<T> left, Range<T> right) { return !(left == right); }
    };
}
