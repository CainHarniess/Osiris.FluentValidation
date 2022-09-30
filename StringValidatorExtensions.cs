using FluentValidation;
using Osiris.System.Extensions;

namespace Osiris.FluentValidation;


public static class StringValidatorExtensions
{
    public static IRuleBuilderOptions<T, string?> StringLengthRange<T>(this IRuleBuilder<T, string?> ruleBuilder,
                                                                       int minLength, int maxLength)
    {
        return ruleBuilder.MinimumLength(minLength).MaximumLength(maxLength);
    }

    public static IRuleBuilderOptions<T, string?> NotNullEmptyNorWhiteSpace<T>(this IRuleBuilder<T, string?> ruleBuilder)
    {
        return ruleBuilder.NotNull().NotEmpty().Must(testString => !testString!.IsNullEmptyOrWhiteSpace());
    }
}