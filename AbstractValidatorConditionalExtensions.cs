using FluentValidation;
using System.Linq.Expressions;

namespace Osiris.FluentValidation;

public static class AbstractValidatorConditionalExtensions
{ 
    public static void NullIfElseNotNull<T, TProperty>(this AbstractValidator<T> validator,
       Func<T, bool> ruleCondition, Expression<Func<T, TProperty>> propertyExpression)
    {
        validator.When(ruleCondition, () =>
        {
            validator.RuleFor(propertyExpression).Null();
        }).Otherwise(() =>
        {
            validator.RuleFor(propertyExpression).NotNull();
        });
    }

    public static void NotNullIfElseNull<T, TProperty>(this AbstractValidator<T> validator,
       Func<T, bool> ruleCondition, Expression<Func<T, TProperty>> propertyExpression)
    {
        validator.When(ruleCondition, () =>
        {
            validator.RuleFor(propertyExpression).NotNull();
        }).Otherwise(() =>
        {
            validator.RuleFor(propertyExpression).Null();
        });
    }

    public static void NullIf<T, TProperty>(this AbstractValidator<T> validator,
       Func<T, bool> ruleCondition, Expression<Func<T, TProperty>> propertyExpression)
    {
        validator.When(ruleCondition, () =>
        {
            validator.RuleFor(propertyExpression).Null();
        });
    }

    public static void NotNullIf<T, TProperty>(this AbstractValidator<T> validator,
       Func<T, bool> ruleCondition, Expression<Func<T, TProperty>> propertyExpression)
    {
        validator.When(ruleCondition, () =>
        {
            validator.RuleFor(propertyExpression).NotNull();
        });
    }
}
