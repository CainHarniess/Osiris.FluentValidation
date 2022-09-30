using FluentValidation;

namespace Osiris.FluentValidation.Testing
{
    public static class StubFluentValidator
    {
        public static InlineValidator<T> Create<T>()
        {
            return new InlineValidator<T>();
        }

        public static InlineValidator<T> CreatePassing<T>()
        {
            var stub = Create<T>();
            stub.RuleFor(x => x).Must(x => true);
            return stub;
        }

        public static InlineValidator<T> CreateFailing<T>()
        {
            var stub = Create<T>();
            stub.RuleFor(x => x).Must(x => false);
            return stub;
        }
    }
}
